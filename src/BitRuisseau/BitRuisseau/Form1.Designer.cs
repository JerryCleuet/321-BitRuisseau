namespace BitRuisseau
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainTitle = new Label();
            goToMediaPage = new Button();
            SuspendLayout();
            // 
            // MainTitle
            // 
            MainTitle.AutoSize = true;
            MainTitle.Font = new Font("Segoe UI", 20F);
            MainTitle.Location = new Point(40, 27);
            MainTitle.Name = "MainTitle";
            MainTitle.Size = new Size(294, 37);
            MainTitle.TabIndex = 0;
            MainTitle.Text = "Liste des médiathèques";
            MainTitle.Click += label1_Click;
            // 
            // goToMediaPage
            // 
            goToMediaPage.Location = new Point(340, 34);
            goToMediaPage.Name = "goToMediaPage";
            goToMediaPage.Size = new Size(109, 36);
            goToMediaPage.TabIndex = 1;
            goToMediaPage.Text = "button1";
            goToMediaPage.UseVisualStyleBackColor = true;
            goToMediaPage.Click += goToMediaPage_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 654);
            Controls.Add(goToMediaPage);
            Controls.Add(MainTitle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MainTitle;
        private Button goToMediaPage;
    }
}
