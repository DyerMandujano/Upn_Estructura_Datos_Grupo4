using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    class NodoServicio
    {
        //Nodo
        public int IdServicio { get; set; }
        public string Nombre_servi { get; set; }
        public string Descripcion { get; set; }
        public string Horario { get; set; }
        public decimal Precio { get; set; }
        public NodoServicio Siguiente { get; set; }
     
    }
}
