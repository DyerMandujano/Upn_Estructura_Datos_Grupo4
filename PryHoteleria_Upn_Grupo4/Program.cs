using System;
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
        static void Main(string[] args)
        {
            ListaCliente cliente = new ListaCliente();

            /*
            cliente.InsertarClienteAlFinal(1, "pepe", "78000654", "20/04/02", "pepe@gmail.com", "980054321");
            cliente.InsertarClienteAlFinal(2, "rosa", "78978652", "21/05/01", "rosa@gmail.com", "987654890");
            cliente.InsertarClienteAlFinal(3, "Dyer", "78978111", "22/06/04", "dyer@gmail.com", "987654777");
            */

            do
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
                                    cliente.InsertarClienteInicio(C_id, C_nombre, C_dni, C_f_nac, C_email, C_telf);
                                    break;

                                case 2:
                                    IngresoDatos();
                                    cliente.InsertarClienteAlFinal(C_id, C_nombre, C_dni, C_f_nac, C_email, C_telf);
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
                        Console.WriteLine("COLOCA TU CODIGO DE EMPLEADOS MANO :V hasta el viernes como maximo :D");
                        Console.ReadKey();
                        break;
                }
            } while (op != 3);
           
            //scliente.ImprimirClientes();
            //Console.ReadKey();
        }

        public static void IngresoDatos()
        {
            Console.Write("Ingresar ID: ");
            C_id = int.Parse(Console.ReadLine());
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
    }
}
