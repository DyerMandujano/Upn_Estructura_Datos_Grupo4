using PryHoteleria_Upn_Grupo4.ArbolMantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.arbololMantenimiento
{
    class ArbolMtn
    {
        private NodoMantenimiento arbol_mante;

        public NodoMantenimiento Arbol_Mant
        {
            get { return arbol_mante; }
            set { arbol_mante = value; }
        }

        public ArbolMtn()
        {
            Arbol_Mant = null;
        }

        public void insertaNodo(Mantenimiento new_mant)
        {
            string valorRaiz;
            NodoMantenimiento q = new NodoMantenimiento(new_mant);
            NodoMantenimiento t = Arbol_Mant;
            int nivel = 0;

            if (Arbol_Mant == null)
            {
                Arbol_Mant = q;
            }
            else
            {
                while (t != null)
                {
                    nivel++;
                    valorRaiz = t.Dato.Tipo_Mant;

                    if (new_mant.Tipo_Mant.CompareTo(valorRaiz) == -1)
                    {
                        if (t.N_Izq != null)
                        {
                            t = t.N_Izq;
                        }
                        else
                        {
                            q.Dato.Nivel = nivel;
                            t.N_Izq = q;
                            return;
                        }
                    }
                    else
                    {
                        if (t.N_Der != null)
                        {
                            t = t.N_Der;
                        }
                        else
                        {
                            q.Dato.Nivel = nivel;
                            t.N_Der = q;
                            return;
                        }
                    }
                }
            }
        }

        public void muestraArbol(NodoMantenimiento arbol, int cont)
        {
            if (arbol == null)
            {
                return;
            }
            else
            {
                muestraArbol(arbol.N_Der, cont + 1);
                for (int i = 0; i < cont; i++)
                {
                    Console.Write("      ");
                }
                Console.WriteLine(arbol.Dato.Nivel + "." + arbol.Dato.Tipo_Mant);
                muestraArbol(arbol.N_Izq, cont + 1);
            }
        }

        public void busquedaTipoMantenimiento(string buscar_mant)
        {
            string valorRaiz;
            NodoMantenimiento t = Arbol_Mant;
            int nivel = 0;

            if (Arbol_Mant == null)
            {
                Console.WriteLine("Arbol vacio, no se puede ejecutar la operacion");
            }
            else
            {
                while (t != null)
                {
                    nivel++;
                    valorRaiz = t.Dato.Tipo_Mant;
                    if (buscar_mant.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("\tMANTENIMIENTO ENCONTRADO ");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine(" IdMantenimiento     : " + t.Dato.Id);
                        Console.WriteLine(" IdHabitacion        : " + t.Dato.IdHabit);
                        Console.WriteLine(" IdEmpleado         : " + t.Dato.IdEmple);
                        Console.WriteLine(" Fecha de Mantenimiento  : " + t.Dato.Fecha_Mant);
                        Console.WriteLine(" Tipo de Mantenimiento  : " + t.Dato.Tipo_Mant);
                        Console.WriteLine(" Descripción  : " + t.Dato.Descrip_Mant);
                        Console.WriteLine(" Nivel      : " + t.Dato.Nivel);
                        Console.WriteLine("--------------------------");
                    }

                    if (buscar_mant.CompareTo(valorRaiz) == -1)
                    {
                        if (t.N_Izq != null)
                        {
                            t = t.N_Izq;
                        }
                        else
                        {
                            Console.WriteLine("El Tipo de Mantenimiento "+ buscar_mant+ " NO se encuentra en el arbol!!");
                            return;
                        }
                    }
                    else
                    {
                        if (t.N_Der != null)
                        {
                            t = t.N_Der;
                        }
                        else
                        {
                            Console.WriteLine("El Tipo de Mantenimiento " + buscar_mant + " NO se encuentra en el arbol!!");
                            return;
                        }
                    }
                }
            }
        }

    }

}

