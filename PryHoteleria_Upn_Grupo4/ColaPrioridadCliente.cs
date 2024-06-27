using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class ColaPrioridadCliente
    {
        public Atencion_Cliente CP_AtencionCliente;

        public ColaPrioridadCliente()
        {
            CP_AtencionCliente = null;
        }
        public void queueColaPrioridadCliente(int IdCl,int IdHa,string FeSo,string Des,int prio,string des_prio)
        {
            if (prio < 1 || prio > 3)
            {
                Console.WriteLine("Prioridad incorrecta");
            }

            Atencion_Cliente q = new Atencion_Cliente(IdCl,IdHa,FeSo,Des,prio,des_prio);
            Atencion_Cliente t = CP_AtencionCliente;
            Atencion_Cliente ant = null;
            if (CP_AtencionCliente == null)
            {
                CP_AtencionCliente= q;
            }
            else
            {
                while (t != null)
                {
                    if ((prio <= t.Prioridad) && (t == CP_AtencionCliente))
                    {
                        q.Sgte = CP_AtencionCliente;
                        CP_AtencionCliente = q;
                        return;
                    }
                    if (prio <= t.Prioridad && prio > ant.Prioridad)
                    {
                        q.Sgte = t;
                        ant.Sgte = q;
                        return;
                    }
                    ant = t;
                    t = t.Sgte;
                }
                ant.Sgte = q;
                return;    
            }
        }
        public int DequeueColaPrioridadCliente()
        {
            if (CP_AtencionCliente == null)
            {
                Console.WriteLine("No hay elementos en la cola!!!");
                Console.ReadKey();
                return 0;
            }

            int valor = CP_AtencionCliente.IdAtencion;
            CP_AtencionCliente = CP_AtencionCliente.Sgte;
            Console.WriteLine("Se elimino de la COLA Correctamente!!");
            Console.ReadKey();
            return valor;
        }
        public Atencion_Cliente DequeueColaPrioCliente()
        {
            if (CP_AtencionCliente == null)
            {
                Console.WriteLine("No hay elementos en la cola!!!");
                Console.ReadKey();
                return null;
            }
            Atencion_Cliente t = CP_AtencionCliente;
            CP_AtencionCliente = CP_AtencionCliente.Sgte;
            Console.WriteLine("Se elimino de la COLA Correctamente!!");
            Console.ReadKey();
            return t;
        }
        public void muestraColaPrioridad()
        {
            Atencion_Cliente t = CP_AtencionCliente;
            if (t == null)
            {
                Console.Write("No hay elementos en la cola");
                return;
            }
            Console.WriteLine(" ╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║                                                Atención Cliente                                                           ║");
            Console.WriteLine(" ╠═════════════╦═══════════╦════════════════╦═════════════════╦═══════════════════════╦═══════════════╦══════════════════════╣");
            Console.WriteLine(" ║   Atencion  ║  Cliente  ║   Habitacion   ║ Fecha Solicitud ║      Descripcion      ║   Prioridad   ║  Descrip Prioridad   ║");
            while (t != null)
            {
                Console.WriteLine(" ╠═════════════╬═══════════╬════════════════╬═════════════════╬═══════════════════════╬═══════════════╬══════════════════════╣");
                Console.WriteLine(" ║{0,13}║{1,11}║{2,16}║{3,17}║{4,23}║{5,15}║{6,22}║", t.IdAtencion, t.IdCliente, t.IdHabitacion, t.FechaSolicitud, t.Descripcion, t.Prioridad, t.Descripcion_Prioridad);
                t = t.Sgte;
            }
            Console.WriteLine(" ╚═════════════╩═══════════╩════════════════╩═════════════════╩═══════════════════════╩═══════════════╩══════════════════════╝");
        }

    }
}
