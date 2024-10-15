using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Manejadores
{
    public class ManejadorLogin
    {
        Funciones f = new Funciones();
        public string[] validar(string nic, string clave)
        {
            string[] resultado = new string[2];
            DataSet r = f.Mostrar($"call validar('{nic}'," +
                $"'{Sha1(clave)}')", "users");
            DataTable dt = r.Tables[0];
            resultado[0] = dt.Rows[0]["rs"].ToString();
            resultado[1] = dt.Rows[0]["rol"].ToString();
            return resultado;
        }
        public static string Sha1(string texto)
        {
            SHA1 sha1 = SHA1Managed.Create();
            byte[] textOriginal = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
    }
}
