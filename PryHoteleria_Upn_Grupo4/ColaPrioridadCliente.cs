﻿using System;
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
        public void queueColaPrioridadCliente(int IdAt,int IdCl,int IdHa,string FeSo,string Des,int prio,int des_prio)
        {
            if (prio < 1 || prio > 3)
            {
                Console.WriteLine("Prioridad incorrecta");
            }

            Atencion_Cliente q = new Atencion_Cliente(IdAt,IdCl,IdHa,FeSo,Des,prio,des_prio);
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
                    if (prio <= t.Prioridad)
                    {
                        if (ant == null)
                        {
                            q.Sgte = CP_AtencionCliente;
                            CP_AtencionCliente = q;
                        }
                        else
                        {
                            q.Sgte = t;
                            ant.Sgte = q;
                        }
                        return;
                    }
                    ant = t;
                    t = t.Sgte;
                }
                ant.Sgte = q;
            }
        }
        public int DequeueColaPrioridadCliente()
        {
            if (CP_AtencionCliente == null)
            {
                Console.WriteLine("No hay elementos en la cola!!!");
                return 0;
            }

            int valor = CP_AtencionCliente.IdAtencion;
            CP_AtencionCliente = CP_AtencionCliente.Sgte;
            return valor;
        }

    }
}