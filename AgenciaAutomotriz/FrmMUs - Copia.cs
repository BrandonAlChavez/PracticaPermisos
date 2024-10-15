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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void tsbtnCrearUs_Click(object sender, EventArgs e)
        {
            FrmUsuarios fu = new FrmUsuarios();
            fu.MdiParent = this;
            fu.Show();
        }

        private void tsbtnModT_Click(object sender, EventArgs e)
        {
            FrmUTaller ft = new FrmUTaller();
            ft.MdiParent = this;
            ft.Show();
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
