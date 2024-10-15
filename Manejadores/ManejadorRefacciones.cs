using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorRefacciones
    {
        Funciones f = new Funciones();
        public void Guardar(TextBox CB, TextBox Nombre, TextBox Marca,TextBox Desctipcion)
        {
            MessageBox.Show(f.Guardar($"insert into producto values ('{CB.Text}','{Nombre.Text}','{Marca.Text}','{Desctipcion.Text}')"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Borrar(int codigobarras, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {dato}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"delete from producto where codigobarras={codigobarras}");
                MessageBox.Show("Registro eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modificar(TextBox Nombre, TextBox Marca, TextBox Descripcion, int codigobarras)
        {
            MessageBox.Show(f.Modificar($"update producto set nombre='{Nombre.Text}',marca='{Marca.Text}',descipcion='{Descripcion.Text}' where codigobarras={codigobarras}"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        DataGridViewButtonColumn Boton(string t, Color co)
        {
            DataGridViewButtonColumn bo = new DataGridViewButtonColumn();
            bo.Text = t;
            bo.UseColumnTextForButtonValue = true;
            bo.FlatStyle = FlatStyle.Popup;
            bo.DefaultCellStyle.BackColor = co;
            bo.DefaultCellStyle.ForeColor = Color.White;
            return bo;
        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"select * from temp where idd like '%{filtro}%';", "temp").Tables[0];
            tabla.Columns.Insert(6, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(7, Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
    }
}
