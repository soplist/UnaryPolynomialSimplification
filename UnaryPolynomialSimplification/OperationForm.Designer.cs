namespace UnaryPolynomialSimplification
{
    partial class OperationForm
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
            this.initialFormulaTextBox = new System.Windows.Forms.TextBox();
            this.simplifyButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // initialFormulaTextBox
            // 
            this.initialFormulaTextBox.Location = new System.Drawing.Point(23, 30);
            this.initialFormulaTextBox.Name = "initialFormulaTextBox";
            this.initialFormulaTextBox.Size = new System.Drawing.Size(327, 21);
            this.initialFormulaTextBox.TabIndex = 0;
            // 
            // simplifyButton
            // 
            this.simplifyButton.Location = new System.Drawing.Point(366, 30);
            this.simplifyButton.Name = "simplifyButton";
            this.simplifyButton.Size = new System.Drawing.Size(75, 23);
            this.simplifyButton.TabIndex = 1;
            this.simplifyButton.Text = "simplify";
            this.simplifyButton.UseVisualStyleBackColor = true;
            this.simplifyButton.Click += new System.EventHandler(this.simplifyButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(21, 72);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 12);
            this.resultLabel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 114);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.simplifyButton);
            this.Controls.Add(this.initialFormulaTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox initialFormulaTextBox;
        private System.Windows.Forms.Button simplifyButton;
        private System.Windows.Forms.Label resultLabel;
    }
}

