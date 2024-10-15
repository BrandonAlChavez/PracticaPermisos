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
    public partial class FrmUHerramientas : Form
    {
        public static int codigobarras = 0;
        ManejadorTaller mt;
        public FrmUHerramientas()
        {
            InitializeComponent();
            mt = new ManejadorTaller();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmUTaller.codigoh == 0)
            {
                mt.Guardar(txtCH ,txtNombre, txtMedida, txtMarca, txtDes);
                txtNombre.Clear();
                txtMedida.Clear();
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
