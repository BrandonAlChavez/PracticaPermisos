using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace AgenciaAutomotriz
{
    public partial class FrmURefacciones : Form
    {
        public static List<Refacciones> refacciones = new List<Refacciones>();
        int fila = 0, columna = 0;
        public static int codigobarras = 0;
        public static string nombre = "", descripcion = "",marca ="";
        ManejadorRefacciones mr;
        public FrmURefacciones()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            codigobarras = int.Parse(dtgvPro.Rows[fila].Cells[0].Value.ToString());
            mr.Borrar(codigobarras, dtgvPro.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            codigobarras = 0; nombre = ""; marca = ""; descripcion = "";
            dtgvPro.Visible = false;
            FrmUProducto cu = new FrmUProducto();
            cu.ShowDialog();
            txtPro.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            codigobarras = int.Parse(dtgvPro.Rows[fila].Cells[0].Value.ToString());
            nombre = dtgvPro.Rows[fila].Cells[1].Value.ToString();
            descripcion = dtgvPro.Rows[fila].Cells[2].Value.ToString();
            marca = dtgvPro.Rows[fila].Cells[3].Value.ToString();
            FrmUProducto dm = new FrmUProducto();
            dm.ShowDialog();
            Actualizar();
        }
        void Limpiar()
        {
            mr.Mostrar(dtgvPro, "-1");
        }

        void Actualizar()
        {
            mr.Mostrar(dtgvPro, refacciones.ToString());
        }
    }
}
