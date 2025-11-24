namespace BitRuisseau
{
    partial class Form2
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
            mediaPageTitle = new Label();
            GoToMediatequesPage = new Button();
            mediaList = new Label();
            SuspendLayout();
            // 
            // mediaPageTitle
            // 
            mediaPageTitle.AutoSize = true;
            mediaPageTitle.Font = new Font("Segoe UI", 20F);
            mediaPageTitle.Location = new Point(35, 25);
            mediaPageTitle.Name = "mediaPageTitle";
            mediaPageTitle.Size = new Size(412, 37);
            mediaPageTitle.TabIndex = 0;
            mediaPageTitle.Text = "Liste des pistes audio disponibles";
            mediaPageTitle.Click += label1_Click;
            // 
            // GoToMediatequesPage
            // 
            GoToMediatequesPage.Location = new Point(453, 29);
            GoToMediatequesPage.Name = "GoToMediatequesPage";
            GoToMediatequesPage.Size = new Size(106, 42);
            GoToMediatequesPage.TabIndex = 1;
            GoToMediatequesPage.Text = "button1";
            GoToMediatequesPage.UseVisualStyleBackColor = true;
            GoToMediatequesPage.Click += GoToMediatequesPage_Click;
            // 
            // mediaList
            // 
            mediaList.AutoSize = true;
            mediaList.Location = new Point(35, 100);
            mediaList.Name = "mediaList";
            mediaList.Size = new Size(38, 15);
            mediaList.TabIndex = 3;
            mediaList.Text = "label1";
            mediaList.Click += mediaList_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 596);
            Controls.Add(mediaList);
            Controls.Add(GoToMediatequesPage);
            Controls.Add(mediaPageTitle);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label mediaPageTitle;
        private Button GoToMediatequesPage;
        private Label mediaList;
    }
}