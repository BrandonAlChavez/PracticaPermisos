using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgenciaAutomotriz
{
    public partial class FrmMenuAdmin : Form
    {
        public FrmMenuAdmin()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmUsuarios fu = new FrmUsuarios();
            fu.MdiParent = this;
            fu.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmURefacciones fr = new FrmURefacciones();
            fr.MdiParent = this;
            fr.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmUTaller ft = new FrmUTaller();
            ft.MdiParent = this;
            ft.Show();
        }
    }
}
