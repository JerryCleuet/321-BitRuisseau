namespace BitRuisseau
{
    partial class MessageBoxMusic
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
            addTo = new Button();
            back = new Button();
            infosLabel = new Label();
            SuspendLayout();
            // 
            // addTo
            // 
            addTo.Location = new Point(433, 311);
            addTo.Name = "addTo";
            addTo.Size = new Size(175, 23);
            addTo.TabIndex = 0;
            addTo.Text = "Ajouter à la médiathèque";
            addTo.UseVisualStyleBackColor = true;
            addTo.Click += addTo_Click;
            // 
            // back
            // 
            back.Location = new Point(12, 311);
            back.Name = "back";
            back.Size = new Size(75, 23);
            back.TabIndex = 1;
            back.Text = "Retour";
            back.UseVisualStyleBackColor = true;
            back.Click += button2_Click;
            // 
            // infosLabel
            // 
            infosLabel.AutoSize = true;
            infosLabel.Location = new Point(251, 108);
            infosLabel.Name = "infosLabel";
            infosLabel.Size = new Size(38, 15);
            infosLabel.TabIndex = 2;
            infosLabel.Text = "label1";
            infosLabel.Click += infosLabel_Click;
            // 
            // MessageBoxMusic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 346);
            Controls.Add(infosLabel);
            Controls.Add(back);
            Controls.Add(addTo);
            Name = "MessageBoxMusic";
            Text = "MessageBoxMusic";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addTo;
        private Button back;
        private Label infosLabel;
    }
}