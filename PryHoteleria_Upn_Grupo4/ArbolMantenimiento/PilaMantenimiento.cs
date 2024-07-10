using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolMantenimiento
{
    class PilaMantenimiento
    {
        private Mantenimiento pila_mant;

        public Mantenimiento Pila_Mant
        {
            get { return pila_mant; }
            set { pila_mant = value; }
        }

        public PilaMantenimiento() 
        {
            Pila_Mant = null;
        }

        public void push(Mantenimiento p_m)
        {
            if (Pila_Mant == null)
            {
                Pila_Mant = p_m;
                Pila_Mant.M_Sgte = null;
            }
            else
            {
                p_m.M_Sgte = Pila_Mant;
                Pila_Mant = p_m;
            }
        }
        public void muestraPila()
        {
            Mantenimiento t = Pila_Mant;
            
            while (t != null)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("\tDATOS CHECKIN ... ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" Id Mantenimiento      : " + t.Id);
                Console.WriteLine(" Id Habitacion         : " + t.IdHabit);
                Console.WriteLine(" Id Empleado           : " + t.IdEmple);
                Console.WriteLine(" Fecha de Mantenimiento: " + t.Fecha_Mant);
                Console.WriteLine(" Tipo Mantenimiento    : " + t.Tipo_Mant);
                Console.WriteLine(" Descripcion           : " + t.Descrip_Mant);
                Console.WriteLine("--------------------------\n");
                t = t.M_Sgte;
            }
        }

    }
}
