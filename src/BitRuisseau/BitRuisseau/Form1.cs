namespace BitRuisseau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Chemin du dossier des médias
            string path = Path.Combine(Environment.CurrentDirectory, "medias"); ;
            MainTitle.Text = "Liste des médiathèques";
            goToMediaPage.Text = "Liste des médias";
            List<string> mediatheques = new List<string>();

            if(mediatheques.Count == 0)
            {
                Button createMediathequeBtn = new();
                createMediathequeBtn.Text = "Créer une nouvelle médiathèque";
                createMediathequeBtn.Location = new Point(100, 100);
                createMediathequeBtn.Width = 200;
                this.Controls.Add(createMediathequeBtn);
                createMediathequeBtn.Click += (sender, e) =>
                {
                    MediathequeBox box = new("Création d'une médiathèque");
                    box.ShowDialog();
                };
            }

            foreach (var mediatheque in mediatheques)
            {
                Button mediathequeBtn = new();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void goToMediaPage_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.FormClosed += (s, args) => this.Show();
            this.Hide();
            f2.Show();
        }
    }
}
