using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AgenciaAutomotriz
{
    public partial class FrmUTaller : Form
    {
        

        ManejadorTaller mh;
        public FrmUTaller()
        {
            InitializeComponent();
            mh = new ManejadorTaller();
        }

        public static List<Taller> taller = new List<Taller>();
        int fila = 0, columna = 0;
        public static int codigoh = 1, medida = 0;
        public static string nombre = "", marca = "", descripcion = "";

        private void btnModificar_Click(object sender, EventArgs e)
        {
            codigoh = int.Parse(dtgvHerramientas.Rows[fila].Cells[0].Value.ToString());
            nombre = dtgvHerramientas.Rows[fila].Cells[1].Value.ToString();
            medida = int.Parse(dtgvHerramientas.Rows[fila].Cells[2].Value.ToString());
            marca = dtgvHerramientas.Rows[fila].Cells[3].Value.ToString();
            descripcion = dtgvHerramientas.Rows[fila].Cells[4].Value.ToString();
            FrmUHerramientas fh = new FrmUHerramientas();
            fh.ShowDialog();
            Actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHerramientas_TextChanged(object sender, EventArgs e)
        {
            dtgvHerramientas.Visible = true;
            mh.Mostrar(dtgvHerramientas, txtHerramientas.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            codigoh = int.Parse(dtgvHerramientas.Rows[fila].Cells[0].Value.ToString());
            mh.Borrar(codigoh, dtgvHerramientas.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            codigoh = 0; nombre = ""; medida = 0; marca = ""; descripcion = "";
            dtgvHerramientas.Visible = false;
            FrmUHerramientas cu = new FrmUHerramientas();
            cu.ShowDialog();
            txtHerramientas.Focus();
        }

        private void dtgvHerramientas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 5:
                    {
                        codigoh = int.Parse(dtgvHerramientas.Rows[fila].Cells[0].Value.ToString());
                        mh.Borrar(codigoh, dtgvHerramientas.Rows[fila].Cells[2].Value.ToString());
                    }
                    break;
                case 6:
                    {
                        codigoh = int.Parse(dtgvHerramientas.Rows[fila].Cells[0].Value.ToString());
                        nombre = dtgvHerramientas.Rows[fila].Cells[1].Value.ToString();
                        medida = int.Parse(dtgvHerramientas.Rows[fila].Cells[2].Value.ToString());
                        marca = dtgvHerramientas.Rows[fila].Cells[3].Value.ToString();
                        descripcion = dtgvHerramientas.Rows[fila].Cells[4].Value.ToString();
           
                        FrmCraerUsuario cu = new FrmCraerUsuario();
                        cu.ShowDialog();
                    }
                    break;
            }
        }
        void Limpiar()
        {
            mh.Mostrar(dtgvHerramientas, "-1");
        }

        void Actualizar()
        {
            mh.Mostrar(dtgvHerramientas, taller.ToString());
        }
    }
}
