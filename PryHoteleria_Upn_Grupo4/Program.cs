﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Program
    {
        
        //op es la variable para manejar las opciones del menú general
        //opC es una variable para majear las opciones que va a tener el menu de los clientes
        static int C_id, op, opC;
        //Variables a utilizar para los datos del Cliente.
        static string C_nombre, C_dni, C_f_nac, C_email, C_telf;

        //
        static int Empleado_id, opcion, opcion_empleados;

        static string Empleado_nom, Empleado_apell, Empleado_dni, Empleado_correo, Empleado_telefono, Empleado_direccion, Empleado_sueldo;
        static void Main(string[] args)
        {
            ListaCliente cliente = new ListaCliente();
            Lista_Empleados Empleados = new Lista_Empleados();

            /*
            cliente.InsertarClienteAlFinal(1, "pepe", "78000654", "20/04/02", "pepe@gmail.com", "980054321");
            cliente.InsertarClienteAlFinal(2, "rosa", "78978652", "21/05/01", "rosa@gmail.com", "987654890");
            cliente.InsertarClienteAlFinal(3, "Dyer", "78978111", "22/06/04", "dyer@gmail.com", "987654777");
            */

            do
            {
                try
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine("Menu - HOTELERIA UPN");
                    Console.WriteLine("******************************");
                    Console.WriteLine("[1]Gestion de Clientes");
                    Console.WriteLine("[2]Gestion de Empleados");
                    Console.WriteLine("[3]Gestion de Materiales");
                    Console.WriteLine("[4]SALIR");
                    Console.Write("Elija una Opcion: ");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Menu de Persona");
                                Console.WriteLine("******************************");
                                Console.WriteLine("[1]Ingresar Cliente al Inicio");
                                Console.WriteLine("[2]Ingresar Cliente al Final");
                                Console.WriteLine("[3]Eliminar el Primer Cliente");
                                Console.WriteLine("[4]Eliminar el Ultimo Cliente");
                                Console.WriteLine("[5]Eliminar Cliente por ID");
                                Console.WriteLine("[6]Eliminar Toda la Lista de CLientes");
                                Console.WriteLine("[7]Buscar Cliente por DNI");
                                Console.WriteLine("[8]Listar Clientes");
                                Console.WriteLine("[9] Salir");
                                Console.Write("ELIJA UNA OPCION: ");

                                opC = int.Parse(Console.ReadLine());
                                switch (opC)
                                {
                                    case 1:
                                        IngresoDatos();
                                        cliente.InsertarClienteInicio(C_nombre, C_dni, C_f_nac, C_email, C_telf);
                                        break;

                                    case 2:
                                        IngresoDatos();
                                        cliente.InsertarClienteAlFinal(C_nombre, C_dni, C_f_nac, C_email, C_telf);
                                        break;

                                    case 3:
                                        cliente.EliminarClienteInicio();
                                        Console.ReadKey();
                                        break;

                                    case 4:
                                        cliente.EliminarClienteFinal();
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Console.Write("Ingrese ID del Cliente: ");
                                        C_id = int.Parse(Console.ReadLine());
                                        cliente.EliminarClientePorID(C_id);
                                        Console.ReadKey();
                                        break;
                                    case 6:
                                        cliente.EliminaTodaLaLista();
                                        Console.ReadKey();
                                        break;
                                    case 7:
                                        Console.Write("Ingrese DNI del Cliente: ");
                                        C_dni = Console.ReadLine();
                                        cliente.BuscarClientePorDNI(C_dni);
                                        Console.ReadKey();
                                        break;

                                    case 8:
                                        cliente.ImprimirClientes();
                                        Console.ReadKey();
                                        break;
                                }
                            } while (opC != 9);
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Menu de Persona");
                                Console.WriteLine("******************************");
                                Console.WriteLine("[1]Ingresar Empleado al Inicio");
                                Console.WriteLine("[2]Ingresar Empleado al Final");
                                Console.WriteLine("[3]Eliminar el Primer Empleado");
                                Console.WriteLine("[4]Eliminar el Ultimo Empleado");
                                Console.WriteLine("[5]Eliminar Empleado por ID");
                                Console.WriteLine("[6]Eliminar Toda la Lista de los Empleados");
                                Console.WriteLine("[7]Buscar Empleados por DNI");
                                Console.WriteLine("[8]Listar Empleados");
                                Console.WriteLine("[9] Salir");
                                Console.Write("ELIJA UNA OPCION: ");
                                try
                                {
                                    opcion_empleados = int.Parse(Console.ReadLine());
                                    switch (opcion_empleados)
                                    {
                                        case 1:
                                            IngresoDatos2();
                                            Empleados.InsertarEmpleadoInicio(Empleado_nom, Empleado_apell, Empleado_dni, Empleado_correo, Empleado_telefono, Empleado_direccion, Empleado_sueldo);
                                            break;

                                        case 2:
                                            IngresoDatos2();
                                            Empleados.InsertarEmpleadoFinal(Empleado_nom, Empleado_apell, Empleado_dni, Empleado_correo, Empleado_telefono, Empleado_direccion, Empleado_sueldo);
                                            break;

                                        case 3:
                                            Empleados.EliminarEmpleadoInicio();
                                            Console.ReadKey();
                                            break;

                                        case 4:
                                            Empleados.EliminarEmpleadoFinal();
                                            Console.ReadKey();
                                            break;
                                        case 5:
                                            Console.Write("Ingrese ID del Empleado: ");
                                            Empleado_id = int.Parse(Console.ReadLine());
                                            Empleados.EliminarEmpleadoPorID(Empleado_id);
                                            Console.ReadKey();
                                            break;
                                        case 6:
                                            Empleados.EliminarListaCompleta();
                                            Console.ReadKey();
                                            break;
                                        case 7:
                                            Console.Write("Ingrese DNI del Empleado: ");
                                            Empleado_dni = Console.ReadLine();
                                            Empleados.BuscarEmpleadoPorDNI(Empleado_dni);
                                            Console.ReadKey();
                                            break;

                                        case 8:
                                            Empleados.ImprimirEmpleados();
                                            Console.ReadKey();
                                            break;
                                    }

                                }
                                catch (Exception y)
                                {
                                    Console.WriteLine("Ingrese un valor correcto!");
                                    Console.ReadKey();
                                }
                            } while (opcion_empleados != 9);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Ingrese un valor valido");
                    Console.ReadKey();
                }

                
            } while (op != 3);

            //scliente.ImprimirClientes();
            //Console.ReadKey();
        }

        public static void IngresoDatos()
        {
            Console.Write("Ingresar Nombre: ");
            C_nombre = Console.ReadLine();
            Console.Write("Ingresar Dni: ");
            C_dni = Console.ReadLine();
            Console.Write("Ingresar Fecha de Nacimiento: ");
            C_f_nac = Console.ReadLine();
            Console.Write("Ingresar Email: ");
            C_email = Console.ReadLine();
            Console.Write("Ingresar Telefono: ");
            C_telf = Console.ReadLine();
            Console.WriteLine("Cliente Ingresado Correctamente!");
            Console.ReadKey();
        }
        public static void IngresoDatos2()
        {
            Console.Write("Ingresar Nombre: ");
            Empleado_nom = Console.ReadLine();
            Console.Write("Ingresar Apellido: ");
            Empleado_apell = Console.ReadLine();
            Console.Write("Ingresar Dni: ");
            Empleado_dni = Console.ReadLine();
            Console.Write("Ingresar Correo: ");
            Empleado_correo = Console.ReadLine();
            Console.Write("Ingresar Telefono: ");
            Empleado_telefono = Console.ReadLine();
            Console.Write("Ingresar Direccion: ");
            Empleado_direccion = Console.ReadLine();
            Console.Write("Ingresar Sueldo: ");
            Empleado_sueldo = Console.ReadLine();
            Console.WriteLine("Empleado Ingresado Correctamente!");
            Console.ReadKey();
        }
    }
}
