using ResgistroPersonaDetalle.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResgistroPersonaDetalle
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RPersonaDetalle rPersonaDetalle = new RPersonaDetalle();
            rPersonaDetalle.Show();
            rPersonaDetalle.MdiParent = this;

        }
    }
}
