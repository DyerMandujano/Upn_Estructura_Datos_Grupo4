using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolMantenimiento
{
    class NodoMantenimiento
    {
        private Mantenimiento dato;
        private NodoMantenimiento n_izq;
        private NodoMantenimiento n_der;

        public NodoMantenimiento(Mantenimiento data)
        {
            Dato = data;
            N_Izq = null;
            N_Der = null;
        }

        public Mantenimiento Dato
        {
            get { return dato; }
            set { dato = value; }
        }

        public NodoMantenimiento N_Izq
        {
            get { return n_izq; }
            set { n_izq = value; }
        }

        public NodoMantenimiento N_Der
        {
            get { return n_der; }
            set { n_der = value; }
        }

    }
}
