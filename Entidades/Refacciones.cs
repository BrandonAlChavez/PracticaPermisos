using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Refacciones
    {
        public Refacciones(int codigobarras, string nombre, string descripción, string marca)
        {
            Codigobarras = codigobarras;
            Nombre = nombre;
            Descripción = descripción;
            Marca = marca;
        }

        public int Codigobarras {  get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Marca { get; set; }
    }
}
