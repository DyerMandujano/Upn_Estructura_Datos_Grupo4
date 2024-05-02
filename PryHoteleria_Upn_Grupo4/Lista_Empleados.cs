using System;
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
        //Cambiado a lista doble
        public void InsertarEmpleadoInicio(string nom, string dni, string correo, string telefono, string direccion, string cargo, string sueldo)
        {
            Empleados q = new Empleados(nom, dni, correo, telefono, direccion, cargo, sueldo);

            if (ListaEmpleados == null)
            {
                ListaEmpleados = q;
            }
            else
            {
                q.Emple_Sgt = ListaEmpleados;
                ListaEmpleados.Emple_Ant = q;
                ListaEmpleados = q;
            }
        }
        //codigo cambiado
        public void InsertarEmpleadoFinal(string nom, string dni, string correo, string telefono, string direccion, string cargo, string sueldo)
        {
            Empleados q = new Empleados(nom, dni, correo, telefono, direccion, cargo, sueldo);

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
                q.Emple_Ant = p;
            }
        }
        public void EliminarEmpleadoInicio()
        {
            if (ListaVacia())
            {
                Console.WriteLine(" La lista esta vacia!");
                return;
            }
            else
            {
                ListaEmpleados = ListaEmpleados.Emple_Sgt;
                Console.WriteLine("\n Empleado inicial eliminado!");
            }
        }
        //cambiado a lista doble
        public void EliminarEmpleadoFinal()
        {
            if (ListaVacia())
            {
                Console.WriteLine(" La lista esta vacia!");
                return;
            }
            else
            {
                if (ListaEmpleados.Emple_Sgt == null)
                {
                    ListaEmpleados = null;
                }
                else
                {
                    Empleados p = ListaEmpleados;

                    while (p.Emple_Sgt != null)
                    {
                        p = p.Emple_Sgt;
                    }
                    p.Emple_Ant.Emple_Sgt = null;
                }
                Console.WriteLine("\n Empleado final eliminado!");
            }
        }
        //cambiado a lista doble
        public void EliminarEmpleadoPorID(int id)
        {
            if (ListaVacia())
            {
                Console.WriteLine(" La lista esta vacia!");
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
                    Console.WriteLine(" Empleado con ID " + id + " eliminado Correctamente!");
                    buscado = true;
                    break;
                }
                ant = p;

                p = p.Emple_Sgt;
            }
            if (!buscado)
            {
                Console.WriteLine(" No se encontró ningún empleado con el ID que ingreso");
            }
        }
        public void EliminarListaCompleta()
        {
            ListaEmpleados = null;
            Console.WriteLine(" Lista completamente eliminada");
        }
        public void BuscarEmpleadoPorDNI(string dni)
        {
            Empleados p = ListaEmpleados;

            while ((p != null) && (p.Dni != dni))
            {
                Console.WriteLine(" " + p.Dni);

                p = p.Emple_Sgt;
            }
            if (p == null)
            {
                Console.WriteLine(" El DNI " + dni + " no se encuentra en la lista");
            }
            else
            {
                Console.WriteLine(" ************************************************************************************************************************************************");
                Console.WriteLine(" *|    ID    |      Nombre      |    Apellido    |    DNI    |            Correo             |    Teléfono    |    Dirección    |    Sueldo    |*");
                Console.WriteLine(" ************************************************************************************************************************************************");

                Console.WriteLine(" *|{0,10}|{1,18}|{2,16}|{3,11}|{4,31}|{5,16}|{6,17}|{7,14}|*", p.Id, p.Nom, p.Dni, p.Correo, p.Telefono, p.Direccion, p.Cargo, p.Sueldo);
                Console.WriteLine(" ************************************************************************************************************************************************");
            }
        }
        public void ImprimirEmpleados()
        {
            Empleados p = ListaEmpleados;
            if (ListaVacia())
            {
                Console.WriteLine(" La lista esta vacia!");
                return;
            }

            Console.WriteLine(" ************************************************************************************************************************************************");
            Console.WriteLine(" *|    ID    |      Nombre      |    DNI    |            Correo             |    Teléfono    |    Dirección    |      Cargo      |    Sueldo   |*");
            Console.WriteLine(" ************************************************************************************************************************************************");
            while (p != null)
            {
                Console.WriteLine(" *|{0,10}|{1,18}|{2,16}|{3,11}|{4,31}|{5,16}|{6,17}|{7,14}|*", p.Id, p.Nom, p.Dni, p.Correo, p.Telefono, p.Direccion, p.Cargo, p.Sueldo);
                p = p.Emple_Sgt;
                Console.WriteLine(" ************************************************************************************************************************************************");
            }
        }
    }
}
