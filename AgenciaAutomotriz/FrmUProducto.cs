using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace AgenciaAutomotriz
{
    public partial class FrmUProducto : Form
    {
        ManejadorRefacciones mf;
        public FrmUProducto()
        {
            InitializeComponent();
            mf = new ManejadorRefacciones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmURefacciones.codigobarras == 0)
            {
                mf.Guardar(txtCB,txtNombre, txtMarca, txtDes);
                txtCB.Focus();
                txtNombre.Clear();
                txtMarca.Clear();
                txtDes.Clear();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
