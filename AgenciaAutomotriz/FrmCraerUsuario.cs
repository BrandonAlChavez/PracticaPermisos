using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AgenciaAutomotriz
{
    public partial class FrmCraerUsuario : Form
    {
        public static int idu = 0;
        public static bool s1, s2, s3;

        ManejadorUsuarios mu;
        public FrmCraerUsuario()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmUsuarios.idu == 0)
            {
                mu.Guardar(txtNIC,txtClave,cmbRol,txtNombre,txtAP,txtAM, dtpFecha, txtRFC,chkInsertar,chkMod,chkEliminar);
                txtNIC.Clear();
                txtClave.Clear();
                txtNombre.Clear();
                txtAP.Clear();
                txtAM.Clear();
                dtpFecha.Focus();
                cmbRol.Focus();
                chkInsertar.Focus();
                chkMod.Focus();
                chkEliminar.Focus();
            }
            FrmUsuarios fu  = new FrmUsuarios();
            fu.CheckParaRecibir2 = chkMod.Text;
            fu.CheckParaRecibir3 = chkEliminar.Text;
            fu.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkInsertar_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
