namespace GoogleImageScraper
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxQuery = new TextBox();
            numericUpDownCount = new NumericUpDown();
            btnStart = new Button();
            progressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCount).BeginInit();
            SuspendLayout();
            // 
            // textBoxQuery
            // 
            textBoxQuery.Location = new Point(209, 12);
            textBoxQuery.Name = "textBoxQuery";
            textBoxQuery.PlaceholderText = "Enter search query";
            textBoxQuery.Size = new Size(369, 23);
            textBoxQuery.TabIndex = 0;
            // 
            // numericUpDownCount
            // 
            numericUpDownCount.Location = new Point(331, 57);
            numericUpDownCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCount.Name = "numericUpDownCount";
            numericUpDownCount.Size = new Size(120, 23);
            numericUpDownCount.TabIndex = 1;
            numericUpDownCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnStart
            // 
            btnStart.Location = new Point(349, 175);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(163, 99);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(468, 23);
            progressBar.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar);
            Controls.Add(btnStart);
            Controls.Add(numericUpDownCount);
            Controls.Add(textBoxQuery);
            Name = "Form1";
            Text = "Google Image Scraper";
            ((System.ComponentModel.ISupportInitialize)numericUpDownCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}