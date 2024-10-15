using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Taller
    {
        public Taller(int codigoh, string nombre, int medida, string marca, string descripcion)
        {
            Codigoh = codigoh;
            Nombre = nombre;
            Medida = medida;
            Marca = marca;
            Descripcion = descripcion;
        }

        public int Codigoh { get; set; }
        public string Nombre { get; set; }
        public int Medida { get; set; }
        public string Marca { get; set; }
        public string Descripcion {  get; set; }
    }
}
