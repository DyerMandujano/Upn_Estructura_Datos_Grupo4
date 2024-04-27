﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Lista_Empleados
    {
        private Empleados lista_emple;
        public Empleados ListaEmpleados
        {
            get { return lista_emple; }
            set { lista_emple = value; }
        }
        public Lista_Empleados()
        {
            ListaEmpleados = null;
        }
        public bool ListaVacia()
        {
            if (ListaEmpleados == null)
            {
                return true;
            }
            else return false;
        }
        public void InsertarEmpleadoInicio(string nom, string apell, string dni, string correo, string telefono, string direccion, string sueldo)
        {
            Empleados q = new Empleados(nom, apell, dni, correo, telefono, direccion, sueldo);

            if (ListaEmpleados == null)
            {
                ListaEmpleados = q;
            }
            else
            {
                q.Emple_Sgt = ListaEmpleados;

                ListaEmpleados = q;
            }
        }
        public void InsertarEmpleadoFinal(string nom, string apell, string dni, string correo, string telefono, string direccion, string sueldo)
        {
            Empleados q = new Empleados(nom, apell, dni, correo, telefono, direccion, sueldo);

            if (ListaEmpleados == null)
            {
                ListaEmpleados = q;
            }
            else
            {
                Empleados p = ListaEmpleados;

                while (p.Emple_Sgt != null)
                {
                    p = p.Emple_Sgt;
                }
                p.Emple_Sgt = q;
            }
        }
        public void EliminarEmpleadoInicio()
        {
            if (ListaVacia())
            {
                Console.WriteLine("La lista esta vacia!");
                return;
            }
            else
            {
                ListaEmpleados = ListaEmpleados.Emple_Sgt;
                Console.WriteLine("\nEmpleado inicial eliminado!");
            }
        }
        public void EliminarEmpleadoFinal()
        {
            if (ListaVacia())
            {
                Console.WriteLine("La lista esta vacia!");
                return;
            }
            else
            {
                if (ListaEmpleados.Emple_Sgt == null)
                {
                    ListaEmpleados = ListaEmpleados.Emple_Sgt;
                }
                else
                {
                    Empleados p = ListaEmpleados;

                    Empleados nd_ant = new Empleados();

                    while (p.Emple_Sgt != null)
                    {
                        nd_ant = p;

                        p = p.Emple_Sgt;
                    }
                    nd_ant.Emple_Sgt = null;
                }
                Console.WriteLine("\nEmpleado final eliminado!");
            }
        }
        public void EliminarEmpleadoPorID(int id)
        {
            if (ListaVacia())
            {
                Console.WriteLine("La lista esta vacia!");
                return;
            }
            bool buscado = false;
            Empleados p = ListaEmpleados;
            Empleados ant = new Empleados();

            while (p != null)
            {
                if (p.Id == id)
                {
                    if (p == ListaEmpleados)
                    {
                        ListaEmpleados = ListaEmpleados.Emple_Sgt;
                    }
                    else
                    {
                        ant.Emple_Sgt = p.Emple_Sgt;
                    }
                    Console.WriteLine("Empleado con ID " + id + " eliminado Correctamente!");
                    buscado = true;
                    break;
                }
                ant = p;

                p = p.Emple_Sgt;
            }
            if (!buscado)
            {
                Console.WriteLine("No se encontró ningún empleado con el ID que ingreso");
            }
        }
        public void EliminarListaCompleta()
        {
            ListaEmpleados = null;
            Console.WriteLine("Lista completamente eliminada");
        }
        public void BuscarEmpleadoPorDNI(string dni)
        {
            Empleados p = ListaEmpleados;

            while ((p != null) && (p.Dni != dni))
            {
                Console.WriteLine(p.Dni);

                p = p.Emple_Sgt;
            }
            if (p == null)

                Console.WriteLine("El DNI " + dni + " no se encuentra en la lista");

            else
            {
                Console.WriteLine("************************************************************************************************************************************************");
                Console.WriteLine("*|    ID    |      Nombre      |    Apellido    |    DNI    |            Correo             |    Teléfono    |    Dirección    |    Sueldo    |*");
                Console.WriteLine("************************************************************************************************************************************************");


                Console.WriteLine("*|{0,10}|{1,18}|{2,16}|{3,11}|{4,31}|{5,16}|{6,17}|{7,14}|*", p.Id, p.Nom, p.Apell, p.Dni, p.Correo, p.Telefono, p.Direccion, p.Sueldo);
                Console.WriteLine("************************************************************************************************************************************************");
            }
        }
        public void ImprimirEmpleados()
        {
            Empleados p = ListaEmpleados;
            if (ListaVacia())
            {
                Console.WriteLine("La lista esta vacia!");
                return;
            }

            Console.WriteLine("************************************************************************************************************************************************");
            Console.WriteLine("*|    ID    |      Nombre      |    Apellido    |    DNI    |            Correo             |    Teléfono    |    Dirección    |    Sueldo    |*");
            Console.WriteLine("************************************************************************************************************************************************");
            while (p != null)
            {
                Console.WriteLine("*|{0,10}|{1,18}|{2,16}|{3,11}|{4,31}|{5,16}|{6,17}|{7,14}|*", p.Id, p.Nom, p.Apell, p.Dni, p.Correo, p.Telefono, p.Direccion, p.Sueldo);
                p = p.Emple_Sgt;
                Console.WriteLine("************************************************************************************************************************************************");
            }

        }
    }
}
