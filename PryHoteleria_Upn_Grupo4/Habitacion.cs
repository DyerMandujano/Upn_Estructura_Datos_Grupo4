using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Habitacion
    {
        public static int contador = 1000;
        //ATRIBUTOS
        private int idHabitacion;
        private string tipoHabitacion;
        private int capacidad;
        private double precio_noche;
        private string serv_habitacion;
        private Habitacion h_sgt;


        //CONSTRUCTOR SIN PARAMETROS
        public Habitacion()
        {

        }

        //CONSTRUCTOR CON PARAMETROS
        public Habitacion(string tipoHab, int cap, double precio, string serv_hab)
        {
            Id = contador++;
            //PROPIEDADES - ARGUMENTOS
            Tipo_Habitacion = tipoHab;
            Capacidad = cap;
            Precio_Noche = precio;
            Serv_habitacion = serv_hab;
            //Inicializar el enlace en null
            H_Sgte = null;
            
        }

        //Propiedad para acceso al enlace siguiente
        public Habitacion H_Sgte
        {
            get { return h_sgt; }
            set { h_sgt = value; }
        }

        public int Id
        {
            get { return idHabitacion; }
            set { idHabitacion = value; }
        }

        public string Tipo_Habitacion
        {
            get {return tipoHabitacion;}
            set { tipoHabitacion = value;} 
        }

        public int Capacidad
        { 
            get { return capacidad;} 
            set { capacidad = value;} 
        }

        public double Precio_Noche
        {
            get { return precio_noche;}
            set { precio_noche = value;}
        }

        public string Serv_habitacion
        {
            get { return serv_habitacion;}
            set { serv_habitacion = value;}
        }

        

    }
}
