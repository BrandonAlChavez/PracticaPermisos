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
    public partial class Form1 : Form
    {
        ManejadorLogin ml;
        public Form1()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string[] r = new string[2];
            r = ml.validar(txtUsuarioL.Text, txtContraseña.Text);
            if (r[0].Equals("Correcto"))
            {
                this.Hide();
                switch (r[1])
                {
                    case "Lector":
                        {
                            FrmMenuUs z = new FrmMenuUs();
                            z.Show();
                        }
                        break;
                    case "admin":
                        {
                            FrmMenuAdmin a = new FrmMenuAdmin();
                            a.Show();
                        }
                        break;
                }
            }
            else
                MessageBox.Show("Error al introducir datos");
        }
    }
}
