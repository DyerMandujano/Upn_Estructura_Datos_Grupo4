using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Reserva
    {
        public static int cont = 1000;
        public int idreserva;
        public int idhabitacion;
        public int idcliente;
        public DateTime fechainicio;
        public DateTime fechafin;
        public Reserva sgte;

        public Reserva()
        {

        }
        public Reserva(int IdHab, int IdCli, DateTime FecIni,DateTime FecFin)
        {
            IdReserva = cont++;
            IdHabitacion = IdHab;
            IdCliente = IdCli;
            FechaInicio = FecIni;
            FechaFin = FecFin;
            Sgte = null;
        }
        public Reserva Sgte
        {
            get { return sgte; }
            set { sgte = value; }
        }
        public int IdReserva
        {
            get { return idreserva; }
            set { idreserva = value; }
        }
        public int IdHabitacion
        {
            get { return idhabitacion; }
            set { idhabitacion = value;}
        }
        public int IdCliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }
        public DateTime FechaInicio
        {
            get { return fechainicio; }
            set { fechainicio = value; }
        }
        public DateTime FechaFin
        {
            get { return fechafin; }
            set { fechafin = value; }
        }
    }
}
