using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class PilaAtencionCliente
    {
        public Atencion_Cliente Pila_AtencionCliente;

        public PilaAtencionCliente()
        {
            Pila_AtencionCliente = null;
        }

        public void push(Atencion_Cliente v)
        {
            if (Pila_AtencionCliente == null)
            {
                Pila_AtencionCliente = v;
                Pila_AtencionCliente.sgte = null;
            }
            else
            {
                v.sgte = Pila_AtencionCliente;
                Pila_AtencionCliente = v;
            }
        }

        public Atencion_Cliente pop()
        {
            if (Pila_AtencionCliente == null)
            {
                Console.WriteLine("La pila está vacía!");
                return null;
            }
            else
            {
                return Pila_AtencionCliente;
            }
        }

        public void muestraPilaAtencionCliente()
        {
            Atencion_Cliente t = Pila_AtencionCliente;
            Console.WriteLine(" ╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║                                               Atención Cliente                                                            ║");
            Console.WriteLine(" ╠═════════════╦═══════════════╦════════════════╦═════════════════╦═══════════════╦═══════════════╦══════════════════════════╣");
            Console.WriteLine(" ║   Atencion  ║    Cliente    ║   Habitacion   ║ Fecha Solicitud ║  Descripcion  ║   Prioridad   ║  Descripcion Prioridad   ║");
            while (t != null)
            {
                Console.WriteLine(" ╠═════════════╬═══════════════╬════════════════╬═════════════════╬═══════════════╬═══════════════╬══════════════════════════╣");
                Console.WriteLine(" ║{0,13}║{1,15}║{2,16}║{3,17}║{4,15}║{5,15}║{6,26}║", t.IdAtencion, t.IdCliente, t.IdHabitacion, t.FechaSolicitud, t.Descripcion, t.Prioridad, t.Descripcion_Prioridad);
                t = t.Sgte;
            }
            Console.WriteLine(" ╚═════════════╩═══════════════╩════════════════╩═════════════════╩═══════════════╩═══════════════╩══════════════════════════╝");
        }
    }
}
