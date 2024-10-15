using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorUsuarios
    {
        Funciones f = new Funciones();
        public void Guardar(TextBox Nic, TextBox Clave, ComboBox Rol, TextBox Nombre, TextBox Apellidop,TextBox ApellidoM,DateTimePicker Fecha,TextBox RFC,CheckBox S1,CheckBox S2, CheckBox S3)
        {
            string password = cSha1(Clave.Text);
            MessageBox.Show(f.Guardar($"insert into users values (null,'{Nic.Text}','{password}','{Rol.Text}','{Nombre.Text}','{Apellidop.Text}','{ApellidoM.Text}','{Fecha.Value.ToString("yyyy-MM-dd HH:mm:ss")}','{RFC.Text}',{S1.Checked},{S2.Checked}," +
                $"{S3.Checked})"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        public void Borrar1(int id, string dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {dato}", "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"delete from users where idu={id}");
                MessageBox.Show("Registro eliminado", "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            tabla.DataSource = f.Mostrar($"SELECT Nombre,Apellidop,Apellidom,Fecha,RFC from users where Nombre like '%{filtro}%'; ", "users").Tables[0];
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
        public void LlenarComboDev(ComboBox combo)
        {
            combo.DataSource = f.Mostrar("select idp,l.titulo from prestamos as p join libros as l on p.fkidl=l.idl order by l.titulo ", "prestamos").Tables[0];
            combo.DisplayMember = "l.titulo";
            combo.ValueMember = "idp";
        }
        public string cSha1(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashbytes = sha1.ComputeHash(inputBytes);
                return BitConverter.ToString(hashbytes).Replace("-","").ToLower();
            }
        }
    }
}
