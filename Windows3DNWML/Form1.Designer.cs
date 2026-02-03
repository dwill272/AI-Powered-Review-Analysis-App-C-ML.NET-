namespace Windows3DNWML
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnGuess = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblConfidence = new System.Windows.Forms.Label();
            this.btnRetrain = new System.Windows.Forms.Button();
            this.rbPositive = new System.Windows.Forms.RadioButton();
            this.rbNegative = new System.Windows.Forms.RadioButton();
            this.lblCompare = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(196, 176);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(488, 22);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // btnGuess
            // 
            this.btnGuess.Location = new System.Drawing.Point(690, 175);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(75, 23);
            this.btnGuess.TabIndex = 1;
            this.btnGuess.Text = "Guess";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(824, 113);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(60, 20);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result:";
            this.lblResult.Click += new System.EventHandler(this.lblResult_Click);
            // 
            // lblConfidence
            // 
            this.lblConfidence.AutoSize = true;
            this.lblConfidence.Location = new System.Drawing.Point(824, 235);
            this.lblConfidence.Name = "lblConfidence";
            this.lblConfidence.Size = new System.Drawing.Size(98, 20);
            this.lblConfidence.TabIndex = 3;
            this.lblConfidence.Text = "Confidence:";
            this.lblConfidence.Click += new System.EventHandler(this.lblConfidence_Click);
            // 
            // btnRetrain
            // 
            this.btnRetrain.Location = new System.Drawing.Point(384, 315);
            this.btnRetrain.Name = "btnRetrain";
            this.btnRetrain.Size = new System.Drawing.Size(113, 47);
            this.btnRetrain.TabIndex = 4;
            this.btnRetrain.Text = "Retrain";
            this.btnRetrain.UseVisualStyleBackColor = true;
            this.btnRetrain.Click += new System.EventHandler(this.btnRetrain_Click);
            // 
            // rbPositive
            // 
            this.rbPositive.AutoSize = true;
            this.rbPositive.Location = new System.Drawing.Point(552, 293);
            this.rbPositive.Name = "rbPositive";
            this.rbPositive.Size = new System.Drawing.Size(76, 20);
            this.rbPositive.TabIndex = 5;
            this.rbPositive.TabStop = true;
            this.rbPositive.Text = "Positive";
            this.rbPositive.UseVisualStyleBackColor = true;
            this.rbPositive.CheckedChanged += new System.EventHandler(this.rbPositive_CheckedChanged);
            // 
            // rbNegative
            // 
            this.rbNegative.AutoSize = true;
            this.rbNegative.Location = new System.Drawing.Point(552, 368);
            this.rbNegative.Name = "rbNegative";
            this.rbNegative.Size = new System.Drawing.Size(104, 25);
            this.rbNegative.TabIndex = 6;
            this.rbNegative.TabStop = true;
            this.rbNegative.Text = "Negative";
            this.rbNegative.UseVisualStyleBackColor = true;
            this.rbNegative.CheckedChanged += new System.EventHandler(this.rbNegative_CheckedChanged);
            // 
            // lblCompare
            // 
            this.lblCompare.AutoSize = true;
            this.lblCompare.Location = new System.Drawing.Point(746, 330);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(83, 20);
            this.lblCompare.TabIndex = 7;
            this.lblCompare.Text = "Compare:";
            this.lblCompare.Click += new System.EventHandler(this.lblCompare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 659);
            this.Controls.Add(this.lblCompare);
            this.Controls.Add(this.rbNegative);
            this.Controls.Add(this.rbPositive);
            this.Controls.Add(this.btnRetrain);
            this.Controls.Add(this.lblConfidence);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblConfidence;
        private System.Windows.Forms.Button btnRetrain;
        private System.Windows.Forms.RadioButton rbPositive;
        private System.Windows.Forms.RadioButton rbNegative;
        private System.Windows.Forms.Label lblCompare;
    }
}

