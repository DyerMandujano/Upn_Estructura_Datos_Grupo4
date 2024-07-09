using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolCheckIn
{
    class NodoCheckIn
    {
        public static int contador = 1;
        private int id_checkin;
        private CheckIn dato;
        private NodoCheckIn n_izq;
        private NodoCheckIn n_der;

        public NodoCheckIn(CheckIn data)
        {
            Id_CheckIn = contador++;
            Dato = data;
            N_Izq = null;
            N_Der = null;
        }

        public int Id_CheckIn
        {
            get { return id_checkin; }
            set { id_checkin = value;}
        }

        public CheckIn Dato
        {
            get { return dato; }
            set { dato = value; }
        }

        public NodoCheckIn N_Izq
        {
            get { return n_izq; }
            set { n_izq = value; }
        }

        public NodoCheckIn N_Der
        {
            get { return n_der; }
            set { n_der = value; }
        }
    }
}
