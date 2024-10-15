using Entidades;
using Manejadores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgenciaAutomotriz
{
    public partial class FrmUsuarios : Form
    {
        ManejadorUsuarios mu;
        public FrmUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios ();
        }

        public static List<Users> usuarios = new List<Users>();
        int fila = 0, columna = 0;
        public static int idu = 1;
        public static string nic = "", clave = "", rol = "", nombre = "",apellidop="", apellidom = "", Fecha = "", rfc = "";

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            idu = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
            mu.Borrar1(idu, dtgvUsuarios.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            Actualizar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            idu = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
            nic = dtgvUsuarios.Rows[fila].Cells[1].Value.ToString();
            nombre = dtgvUsuarios.Rows[fila].Cells[2].Value.ToString();
            apellidop = dtgvUsuarios.Rows[fila].Cells[3].Value.ToString();
            apellidom = dtgvUsuarios.Rows[fila].Cells[4].Value.ToString();

            FrmUHerramientas fh = new FrmUHerramientas();
            fh.ShowDialog();
            Actualizar();
        }

        public static Boolean s1, s2, s3;
        private void txtUsuarios_TextChanged(object sender, EventArgs e)
        {
            dtgvUsuarios.Visible = true;
            mu.Mostrar(dtgvUsuarios, txtUsuarios.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            idu = 0; nic = ""; clave = ""; rol = ""; nombre = ""; apellidop = ""; apellidom = ""; Fecha = ""; rfc = ""; s1 =false; s2 = false; s3 = false;
            dtgvUsuarios.Visible = false;
            FrmCraerUsuario cu = new FrmCraerUsuario();
            cu.ShowDialog();
            txtUsuarios.Focus();
        }

        private void dtgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 12:
                    {
                        idu = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
                        mu.Borrar1(idu, dtgvUsuarios.Rows[fila].Cells[1].Value.ToString());
                    }
                    break;
                case 13:
                    {
                        idu = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
                        nic = dtgvUsuarios.Rows[fila].Cells[1].Value.ToString();
                        clave = dtgvUsuarios.Rows[fila].Cells[2].Value.ToString();
                        rol = dtgvUsuarios.Rows[fila].Cells[3].Value.ToString();
                        nombre = dtgvUsuarios.Rows[fila].Cells[0].Value.ToString();
                        apellidop = dtgvUsuarios.Rows[fila].Cells[1].Value.ToString();
                        apellidom =dtgvUsuarios.Rows[fila].Cells[2].Value.ToString();
                        Fecha = dtgvUsuarios.Rows[fila].Cells[3].Value.ToString();
                        rfc = dtgvUsuarios.Rows[fila].Cells[4].Value.ToString();
                        s1 = Boolean.Parse(dtgvUsuarios.Rows[fila].Cells[9].Value.ToString());
                        s2 = Boolean.Parse(dtgvUsuarios.Rows[fila].Cells[10].Value.ToString());
                        s3 = Boolean.Parse(dtgvUsuarios.Rows[fila].Cells[10].Value.ToString());

                        FrmCraerUsuario cu = new FrmCraerUsuario();
                        cu.ShowDialog();
                    }
                    break;
            }
        }
        public void ToggleButton(bool isCheck)
        {
            btnAgregar.Enabled = isCheck;
        }
        public string CheckParaRecibir2
        {
            get { return chkS2.Text; }
            set { chkS2.Text = value; }
        }
        public string CheckParaRecibir3
        {
            get { return chkS3.Text; }
            set { chkS3.Text = value; }
        }
        void Limpiar()
        {
            mu.Mostrar(dtgvUsuarios, "-1");
        }

        void Actualizar()
        {
            mu.Mostrar(dtgvUsuarios, usuarios.ToString());
        }
    }
}
