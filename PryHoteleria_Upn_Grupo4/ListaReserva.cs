using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class ListaReserva
    {
        private Reserva Lista_reser;

        public Reserva listareserva
        {
            get { return Lista_reser; }
            set { Lista_reser = value; }
        }
        public ListaReserva()
        {
            listareserva = null;
        }
        public bool VerificarListaVacia()
        {
            return listareserva == null;
        }
        public void queue(int idhabitacion, int idcliente, DateTime fechainicio, DateTime fechafin)
        {
            Reserva t = new Reserva(idhabitacion, idcliente, fechainicio, fechafin);

            if (listareserva == null)
            {
                listareserva = t;
            }
            else
            {
                Reserva q = listareserva;
                while (q.sgte != null)
                {
                    q = q.sgte;
                }
                q.sgte = t;
            }
        }

        public Reserva dequeue(bool showOutput = true)
        {
            if (listareserva == null)
            {
                if (showOutput)
                {
                    Console.WriteLine("No hay reservas!");
                }
                return null;
            }
            Reserva t = listareserva;
            listareserva = listareserva.sgte;
            if (showOutput)
            {
                Console.WriteLine("Elemento eliminado satisfactoriamente!");
            }
            return t;
        }
        public void Mostrar()
        {
            Reserva t = listareserva;
            Console.WriteLine("|-------------------------------------------------------------------------------|");
            Console.WriteLine("|                                 Reservación                                   |");
            Console.WriteLine("|-------------------------------------------------------------------------------|");
            Console.WriteLine("|  ID Reserva | ID Habitacion |   ID Cliente   | Fecha Inicial  |  Fecha final  |");
            Console.WriteLine("|-------------------------------------------------------------------------------|");
            while (t != null)
            {
                Console.Write("|"+t.IdReserva + "\t" + t.idhabitacion + "\t" + t.idcliente + "\t"+ t.fechainicio.ToString("dd/MM/yyyy") + "\t"+ t.fechafin.ToString("dd/MM/yyyy") + "|\n");
                t = t.sgte;
            }
            Console.WriteLine("|-------------------------------------------------------------------------------|");
            
        }
        
    }
}
