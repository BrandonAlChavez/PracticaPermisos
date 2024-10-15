using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Users
    {
        public Users(int idU, string nic, string clave, string rol, string nombre, string apellidop, string apellidom, string fecha, string rFC, bool s1, bool s2, bool s3)
        {
            IdU = idU;
            Nic = nic;
            Clave = clave;
            Rol = rol;
            Nombre = nombre;
            Apellidop = apellidop;
            Apellidom = apellidom;
            Fecha = fecha;
            RFC = rFC;
            S1 = s1;
            S2 = s2;
            S3 = s3;
        }

        public int IdU { get; set; }
        public string Nic { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Fecha { get; set; }
        public string RFC { get; set; }
        public Boolean S1 { get; set; }
        public Boolean S2 { get; set; }
        public Boolean S3 { get; set; }
    }
}
