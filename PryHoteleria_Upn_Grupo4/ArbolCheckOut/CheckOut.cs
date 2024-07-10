using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolCheckOut
{
    class CheckOut
    {
        private string nombre_cli;
        private string dni_cli;
        private int id_habi;
        private string fecha_checkout;
        private string met_pago;
        private string nom_met_pago;
        private double mont_total;
        //Nivel que tiene el nodo en el Arbol
        private int nivel;

        public CheckOut()
        { 

        }

        public CheckOut(string nom_cli, string dni, int idhabi, string fecha_checkout, string metodo_pago, string nom_met_pago, double montototal)
        {
            Nombre_Cli = nom_cli;
            Dni_Cli = dni;
            Id_Habi = idhabi;
            FechaCheckOut = fecha_checkout;
            MetodoPago = metodo_pago;
            Nom_MetodoPago = nom_met_pago;
            Monto = montototal;
            Nivel = 0;
        }

        public string Nombre_Cli
        {
            get { return nombre_cli; }
            set { nombre_cli = value; }
        }
        public string Dni_Cli
        {
            get { return dni_cli; }
            set { dni_cli = value; }
        }
        public int Id_Habi
        {
            get { return id_habi; }
            set { id_habi = value; }
        }
        public string FechaCheckOut
        {
            get { return fecha_checkout; }
            set { fecha_checkout = value; }
        }
        public string MetodoPago
        {
            get { return met_pago; }
            set { met_pago = value; }
        }
        public string Nom_MetodoPago
        {
            get { return nom_met_pago; }
            set { nom_met_pago = value; }
        }
        public double Monto
        {
            get { return mont_total; }
            set { mont_total = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
    }
}
