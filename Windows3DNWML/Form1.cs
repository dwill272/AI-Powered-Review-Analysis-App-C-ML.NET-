using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.ML.DataOperationsCatalog;

namespace Windows3DNWML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        // Helper classes


        // Defines a class to represent the input data, mapping
        public class SentimentData
        {
            [LoadColumn(0)]
            public string SentimentText { get; set; }

            [LoadColumn(1)]
            public bool Label { get; set; }
        }

        // Defines a class to hold the model's prediction results, including the predicted sentiment and its probability.
        public class SentimentPrediction
        {
            [ColumnName("PredictedLabel")]
            public bool Prediction { get; set; }

            [ColumnName("Probability")]
            public float Probability { get; set; }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            try
{


                // Gets the user input, trims spaces, and checks if it's empty; if so, shows a message and stops further processing.
                var text = txtInput.Text.Trim();
    if (string.IsNullOrWhiteSpace(text))
    {
        lblResult.Text = "Result: Please enter a review.";
        lblConfidence.Text = "Confidence:";
        return;
    }

                // Creates an ML context and loads the sentiment dataset from a text file, specifying no header and tab as the separator.
                var ml = new MLContext();
    var data = ml.Data.LoadFromTextFile<SentimentData>(
        path: "yelp_labelled.txt",
        hasHeader: false,
        separatorChar: '\t'
    );
                // Trains a model to figure out if text is positive or negative.
                var model = ml.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.SentimentText))
                    .Append(ml.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features"))
                    .Fit(data);

                // Uses the model to guess if the input text is positive or negative.
                var result = ml.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model)
                    .Predict(new SentimentData { SentimentText = text });

                // Displays the prediction as "Positive" or "Negative" and shows the confidence percentage of the prediction.
                lblResult.Text = result.Prediction ? "Result: Positive" : "Result: Negative";
    lblConfidence.Text = $"Confidence: {Math.Round((result.Prediction ? result.Probability : 1 - result.Probability) * 100, 2)}%";
}
            //errors appearing
catch (Exception ex)
{
    lblResult.Text = "Result: Error during prediction.";
    lblConfidence.Text = "Confidence:";
    MessageBox.Show(ex.ToString(), "Error");
}

        }

        private void lblResult_Click(object sender, EventArgs e) { }
        private void lblConfidence_Click(object sender, EventArgs e) { }
        private void lblCompare_Click(object sender, EventArgs e) { }
        private void rbNegative_CheckedChanged(object sender, EventArgs e) { }
        private void rbPositive_CheckedChanged(object sender, EventArgs e) { }




        private void btnRetrain_Click(object sender, EventArgs e) {


           try
{
    var text = txtInput.Text.Trim();
    if (string.IsNullOrWhiteSpace(text))
    {
        lblCompare.Text = "Compare: Please enter a review first.";
        return;
    }

     // Checks which radio button the user selected for the label and sets userLabel accordingly; shows a message if none are selected.
                bool userLabel;
    if (rbPositive.Checked)
        userLabel = true;
    else if (rbNegative.Checked)
        userLabel = false;
    else
    {
        lblCompare.Text = "Compare: Please select Positive or Negative.";
        return;
    }

                // Creates an ML.NET context with a fixed seed so results are repeatable each time the program runs.
                var ml = new MLContext(seed: 1);

    // Load original Yelp dataset
    var data = ml.Data.LoadFromTextFile<SentimentData>(
        path: "yelp_labelled.txt",
        hasHeader: false,
        separatorChar: '\t'
    );

    // Combine original + new labeled example
    var combinedData = ml.Data.LoadFromEnumerable(
        ml.Data.CreateEnumerable<SentimentData>(data, reuseRowObject: false)
        .Concat(new[] { new SentimentData { SentimentText = text, Label = userLabel } })
    );

                // Shuffles the dataset rows to mix positive and negative examples, helping the model learn patterns fairly and avoid bias from the original order.
                data = ml.Data.ShuffleRows(data);
    combinedData = ml.Data.ShuffleRows(combinedData);

                // Sets up a pipeline to turn text into numbers and train a model to detect sentiment.
                var pipeline = ml.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.SentimentText))
                    .Append(ml.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features"));

                // Splits the original dataset into a training set (80%) and a test set (20%).
                var originalSplit = ml.Data.TrainTestSplit(data, testFraction: 0.2);

                // Trains the model using the pipeline on the training part of the original data.
                var originalModel = pipeline.Fit(originalSplit.TrainSet);

                // Checks/tests how well the trained model works using the test data.
                var originalMetrics = ml.BinaryClassification.Evaluate(originalModel.Transform(originalSplit.TestSet));



                // Splits the combined dataset (original + new input) into training (80%) and testing (20%) sets.
                var combinedSplit = ml.Data.TrainTestSplit(combinedData, testFraction: 0.2);

                // Trains a new model using the pipeline on the training part of the combined data.
                var newModel = pipeline.Fit(combinedSplit.TrainSet);

                // Evaluates the new model on the test set and calculates its accuracy and other metrics.
                var newMetrics = ml.BinaryClassification.Evaluate(newModel.Transform(combinedSplit.TestSet));



                // Display results
                lblCompare.Text = $"Original Accuracy: {originalMetrics.Accuracy:P2}\n" +
                      $"New Accuracy: {newMetrics.Accuracy:P2}";
}
catch (Exception ex)
{
    lblCompare.Text = "Compare: Error during retraining.";
    MessageBox.Show(ex.ToString(), "Error");
}


        }

       

    }
}
