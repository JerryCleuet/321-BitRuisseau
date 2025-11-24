using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitRuisseau
{
    public partial class MessageBoxMusic : Form
    {
        public MessageBoxMusic(string infos)
        {
            InitializeComponent();
            infosLabel.Text = infos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addTo_Click(object sender, EventArgs e)
        {

        }
        private void infosLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
