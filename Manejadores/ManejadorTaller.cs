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
    public class ManejadorTaller
    {
        Funciones f = new Funciones();
        
        public void Guardar(TextBox CH, TextBox Nombre, TextBox Medida,TextBox Marca, TextBox Descripcion)
        {
            MessageBox.Show(f.Guardar($"insert into herramientas values ('{CH.Text}','{Nombre.Text}','{Medida.Text}','{Marca.Text}','{Descripcion.Text}')"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Borrar(int codigoh, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {dato}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"delete from herramientas where CodigoH={codigoh}");
                MessageBox.Show("Registro eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modificar(System.Windows.Forms.TextBox Nombre, System.Windows.Forms.TextBox Medida, System.Windows.Forms.TextBox Marca, System.Windows.Forms.TextBox Descripcion, int CodigoH)
        {
            MessageBox.Show(f.Modificar($"update herramientas set nombre='{Nombre.Text}',medida='{Medida.Text}',marca='{Marca.Text}',descripcion='{Descripcion.Text}' where CodigoH={CodigoH}"),
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
            tabla.DataSource = f.Mostrar($"select * from herramientas where nombre like '%{filtro}%';", "herramientas").Tables[0];
            tabla.Columns.Insert(6, Boton("Borrar", Color.Red));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
        
    }
}
