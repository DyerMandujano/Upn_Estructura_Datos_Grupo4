using PryHoteleria_Upn_Grupo4.ArbolCheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolCheckOut
{
    class NodoCheckOut
    {
        public static int contador = 1;
        private int id_checkout;
        private CheckOut dato;
        private NodoCheckOut n_izq;
        private NodoCheckOut n_der;

        public NodoCheckOut(CheckOut data)
        {
            Id_CheckOut = contador++;
            Dato = data;
            N_Izq = null;
            N_Der = null;
        }

        public int Id_CheckOut
        {
            get { return id_checkout; }
            set { id_checkout = value; }
        }

        public CheckOut Dato
        {
            get { return dato; }
            set { dato = value; }
        }

        public NodoCheckOut N_Izq
        {
            get { return n_izq; }
            set { n_izq = value; }
        }

        public NodoCheckOut N_Der
        {
            get { return n_der; }
            set { n_der = value; }
        }
    }
}
