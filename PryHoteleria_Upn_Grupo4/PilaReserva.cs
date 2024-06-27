using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class PilaReserva
    {
        public Reserva pila;

        public PilaReserva()
        {
            pila = null;
        }

        public void push(Reserva v)
        {
            if (pila == null)
            {
                pila = v;
                pila.sgte = null;
            }
            else
            {
                v.sgte = pila;
                pila = v;
            }
        }

        public Reserva pop()
        {
            if (pila == null)
            {
                Console.WriteLine("La pila está vacía!");
                return null;
            }
            else
            {
                return pila;
            }
        }
        public void muestraPila()
        {
            Reserva t = pila;
            Console.WriteLine(" ╔═══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║                                 Reservación                                   ║");
            Console.WriteLine(" ╠═════════════╦═══════════════╦════════════════╦════════════════╦═══════════════╣");
            Console.WriteLine(" ║  ID Reserva ║ ID Habitacion ║   ID Cliente   ║ Fecha Inicial  ║  Fecha final  ║");

            while (t != null)
            {
                Console.WriteLine(" ╠═════════════╬═══════════════╬════════════════╬════════════════╬═══════════════╣");
                Console.WriteLine(" ║{0,13}║{1,15}║{2,16}║{3,16}║{4,15}║", t.IdReserva, t.idhabitacion, t.idcliente, t.fechainicio.ToString("dd/MM/yyyy"), t.fechafin.ToString("dd/MM/yyyy"));
                t = t.Sgte;
                //Console.Write(" ║" + t.IdReserva + "\t" + t.IdHabitacion + "\t" + t.IdCliente + "\t" + t.FechaInicio.ToString("dd/MM/yyyy") + "\t" + t.FechaFin.ToString("dd/MM/yyyy") + "|\n");
                //t = t.Sgte;
            }
            Console.WriteLine(" ╚═════════════╩═══════════════╩════════════════╩════════════════╩═══════════════╝");
        }
    }
}
    
