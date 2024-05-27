using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

        //EMPLEADOS
        static int Empleado_id, opcion, opcion_empleados, Empleado_dni, Empleado_telefono, Empleado_sueldo;

        static string Empleado_nom, Empleado_cargo, Empleado_correo, Empleado_direccion;

        //MATERIALES
        //MT es la variable para majeras las opciones de los materiales
        static int MT_id, MT_cantidad, opM;
        //Variables a utilizar para los datos de Material.
        static string MT_categoria, MT_nombre_material;
        static double MT_costo;

        //SERVICIOS
        static Servicios _servicios = new Servicios();
        static ServiciosEliminados _eliminados = new ServiciosEliminados();
        static int _idServicio = 1;

        //Reserva
        static int reser_habitacion, reser_cliente, reser_id;
        static DateTime reser_fecha_inicio, reser_fecha_final;
        static int opcion_reserva;

        static public ListaReserva cola = new ListaReserva();
        static public PilaReserva pila = new PilaReserva();

        static void Main(string[] args)
        {
            //Reserva
            Reserva v;
            Console.SetWindowSize(140, 50);
            ListaCliente cliente = new ListaCliente();
            Lista_Empleados Empleados = new Lista_Empleados();
            ListaMateriales materiales = new ListaMateriales();
            //Reserva
            ListaReserva reserva = new ListaReserva();

            do
            {
                try
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine(" *   * ***** *   * *   *       *   *  ***  ***** ***** *     ***** ****   ***   ***   *   * ****  *   * ");
                    Console.WriteLine(" *   * *     *   * *   *       *   * *   *   *   *     *     *     *   *   *   *   *  *   * *   * *   * ");
                    Console.WriteLine(" ** ** *     **  * *   *       *   * *   *   *   *     *     *     *   *   *   *   *  *   * *   * **  * ");
                    Console.WriteLine(" * * * ****  * * * *   * ***** ***** *   *   *   ****  *     ****  ****    *   *****  *   * ****  * * * ");
                    Console.WriteLine(" *   * *     *  ** *   *       *   * *   *   *   *     *     *     * *     *   *   *  *   * *     *  ** ");
                    Console.WriteLine(" *   * *     *   * *   *       *   * *   *   *   *     *     *     *  *    *   *   *  *   * *     *   * ");
                    Console.WriteLine(" *   * ***** *   *  ***        *   *  ***    *   ***** ***** ***** *   *  ***  *   *   ***  *     *   * ");

                    Console.WriteLine("\t");


                    Console.WriteLine(" ***************************");
                    Console.WriteLine(" *[1]Gestion de Clientes   *");
                    Console.WriteLine(" *[2]Gestion de Empleados  *");
                    Console.WriteLine(" *[3]Gestion de Materiales *");
                    Console.WriteLine(" *[4]Gestion de Habitaciones*");
                    Console.WriteLine(" *[5]Gestion de Reservas   *");
                    Console.WriteLine(" *[6]Gestion de Servicios   *");
                    Console.WriteLine(" *[7]SALIR                 *");
                    Console.WriteLine(" ***************************");
                    Console.Write(" Elija una Opcion: ");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            do
                            {
                                //Menu Cliente
                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine(" Menu de Cliente");
                                Console.WriteLine(" ********************************************");
                                Console.WriteLine(" *[1]Ingresar Cliente al Inicio             *");
                                Console.WriteLine(" *[2]Ingresar Cliente al Final              *");
                                Console.WriteLine(" *[3]Eliminar el Primer Cliente             *");
                                Console.WriteLine(" *[4]Eliminar el Ultimo Cliente             *");
                                Console.WriteLine(" *[5]Eliminar Cliente por ID                *");
                                Console.WriteLine(" *[6]Eliminar Toda la Lista de CLientes     *");
                                Console.WriteLine(" *[7]Buscar Cliente por DNI                 *");
                                Console.WriteLine(" *[8]Actualizar Telefono del Cliente por ID *");
                                Console.WriteLine(" *[9]Listar Clientes                        *");
                                Console.WriteLine(" *[10] Salir                                *");
                                Console.WriteLine(" ********************************************");
                                Console.Write(" ELIJA UNA OPCION: ");
                                try
                                {
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
                                            Console.Write(" Ingrese ID del Cliente: ");
                                            C_id = int.Parse(Console.ReadLine());
                                            cliente.EliminarClientePorID(C_id);
                                            Console.ReadKey();
                                            break;
                                        case 6:
                                            cliente.EliminaTodaLaLista();
                                            Console.ReadKey();
                                            break;
                                        case 7:
                                            Console.Write(" Ingrese DNI del Cliente: ");
                                            C_dni = Console.ReadLine();
                                            cliente.BuscarClientePorDNI(C_dni);
                                            Console.ReadKey();
                                            break;

                                        case 8:
                                            Console.Write(" Ingrese ID del Cliente: ");
                                            C_id = int.Parse(Console.ReadLine());
                                            cliente.ActualizarTelefPorId(C_id);
                                            Console.ReadKey();
                                            break;
                                        case 9:
                                            cliente.ImprimirListaCircular();
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Coloque una opción valida!!.");
                                    Console.ReadKey();
                                }

                            } while (opC != 10);
                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("");
                                //Menu de Empleados
                                Console.WriteLine(" Menu de Empleados");
                                Console.WriteLine(" **********************************************");
                                Console.WriteLine(" *[1]Ingresar Empleado al Inicio              *");
                                Console.WriteLine(" *[2]Ingresar Empleado al Final               *");
                                Console.WriteLine(" *[3]Eliminar el Primer Empleado              *");
                                Console.WriteLine(" *[4]Eliminar el Ultimo Empleado              *");
                                Console.WriteLine(" *[5]Eliminar Empleado por ID                 *");
                                Console.WriteLine(" *[6]Eliminar Toda la Lista de los Empleados  *");
                                Console.WriteLine(" *[7]Buscar Empleados por DNI                 *");
                                Console.WriteLine(" *[8]Actualizar Correo de Empleado por ID     *");
                                Console.WriteLine(" *[9]Listar Empleados                         *");
                                Console.WriteLine(" *[10] Salir                                  *");
                                Console.WriteLine(" **********************************************");
                                Console.Write(" ELIJA UNA OPCION: ");
                                try
                                {
                                    opcion_empleados = int.Parse(Console.ReadLine());
                                    switch (opcion_empleados)
                                    {
                                        case 1:
                                            IngresoDatos2();
                                            Empleados.InsertarEmpleadoInicio(Empleado_nom, Empleado_dni, Empleado_correo, Empleado_telefono, Empleado_direccion, Empleado_cargo, Empleado_sueldo);
                                            break;

                                        case 2:
                                            IngresoDatos2();
                                            Empleados.InsertarEmpleadoFinal(Empleado_nom, Empleado_dni, Empleado_correo, Empleado_telefono, Empleado_direccion, Empleado_cargo, Empleado_sueldo);
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
                                            Console.Write(" Ingrese ID del Empleado: ");
                                            Empleado_id = int.Parse(Console.ReadLine());
                                            Empleados.EliminarEmpleadoPorID(Empleado_id);
                                            Console.ReadKey();
                                            break;
                                        case 6:
                                            Empleados.EliminarListaCompleta();
                                            Console.ReadKey();
                                            break;
                                        case 7:
                                            Console.Write(" Ingrese DNI del Empleado: ");
                                            Empleado_dni = int.Parse(Console.ReadLine());
                                            Empleados.BuscarEmpleadoPorDNI(Empleado_dni);
                                            Console.ReadKey();
                                            break;

                                        case 8:
                                            Console.Write(" Ingrese ID del Empleado: ");
                                            Empleado_id = int.Parse(Console.ReadLine());
                                            Empleados.ActualizarCorreoEmpleado(Empleado_id, Empleado_correo);
                                            Console.ReadKey();
                                            break;
                                        case 9:
                                            Empleados.ImprimirEmpleados();
                                            Console.ReadKey();
                                            break;
                                    }

                                }
                                catch (Exception y)
                                {
                                    Console.WriteLine(" Ingrese un valor correcto!");
                                    Console.ReadKey();
                                }
                            } while (opcion_empleados != 10);
                            break;
                        case 3:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine(" Menu de Materiales");
                                Console.WriteLine(" *******************************************");
                                Console.WriteLine(" *[1]Ingresar Material al Inicio           *");
                                Console.WriteLine(" *[2]Ingresar Material al Final            *");
                                Console.WriteLine(" *[3]Eliminar el Primer Material           *");
                                Console.WriteLine(" *[4]Eliminar el Ultimo Material           *");
                                Console.WriteLine(" *[5]Eliminar Material por ID              *");
                                Console.WriteLine(" *[6]Eliminar Toda la Lista de Matariales  *");
                                Console.WriteLine(" *[7]Buscar Materiales                     *");
                                Console.WriteLine(" *[8]Actualiza Material por ID             *");
                                Console.WriteLine(" *[9]Listar Materiales                     *");
                                Console.WriteLine(" *[10]Salir                                *");
                                Console.WriteLine(" *******************************************");
                                Console.Write(" ELIJA UNA OPCION: ");
                                try
                                {
                                    opM = int.Parse(Console.ReadLine());
                                    switch (opM)
                                    {
                                        case 1:
                                            IngresoDatosMateriales();
                                            materiales.InsertarMaterialInicio(MT_categoria, MT_nombre_material, MT_costo);
                                            break;
                                        case 2:
                                            IngresoDatosMateriales();
                                            materiales.InsertarMaterialAlFinal(MT_categoria, MT_nombre_material, MT_costo);
                                            break;
                                        case 3:
                                            materiales.EliminarMaterialInicio();
                                            Console.ReadKey();
                                            break;
                                        case 4:
                                            materiales.EliminarMaterialFinal();
                                            Console.ReadKey();
                                            break;
                                        case 5:
                                            Console.Write(" Ingrese ID del Material: ");
                                            MT_id = int.Parse(Console.ReadLine());
                                            materiales.EliminarMaterialPorID(MT_id);
                                            Console.ReadKey();
                                            break;
                                        case 6:
                                            materiales.EliminaTodaLaLista();
                                            Console.ReadKey();
                                            break;
                                        case 7:
                                            Console.Write(" Ingrese el nombre del Material: ");
                                            MT_nombre_material = Console.ReadLine();
                                            materiales.BuscarMateriales(MT_nombre_material);
                                            Console.ReadKey();
                                            break;
                                        case 8:
                                            Console.Write(" Ingrese ID del Material: ");
                                            MT_id = int.Parse(Console.ReadLine());
                                            materiales.ActualizarNombreMaterial(MT_id, MT_nombre_material);
                                            Console.ReadKey();
                                            break;
                                        case 9:
                                            materiales.ImprimirMaterial();
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine(" Ingrese un valor correcto!");
                                    Console.ReadKey();
                                }

                            } while (opM != 10);
                            break;
                        case 4:
                            break;
                    
                        case 5:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(" ");
                            Console.WriteLine("********************************************");
                            Console.WriteLine("*               Menu Reservar              *");
                            Console.WriteLine(" *******************************************");
                            Console.WriteLine(" *[1]Ingresar Datos                        *");
                            Console.WriteLine(" *[2]Eliminar Datos                        *");
                            Console.WriteLine(" *[3]Mostrar Datos                         *");
                            Console.WriteLine(" *[4]Cambiar de Cola a pila                *");
                            Console.WriteLine(" *[5]Elimina datos (pila)                  *");
                            Console.WriteLine(" *[6]Mostrar Datos (pila)                  *");
                            Console.WriteLine(" *[7]Salir                                 *");
                            Console.WriteLine(" *******************************************");
                            Console.Write(" ELIJA UNA OPCION: ");

                            try
                            {
                                opcion_reserva = int.Parse(Console.ReadLine());
                                switch (opcion_reserva)
                                {
                                    case 1:
                                        IngresoDatosReserva();
                                        reserva.queue(reser_habitacion, reser_cliente, reser_fecha_inicio, reser_fecha_final);
                                        break;
                                    case 2:
                                        Reserva reservaEliminada = reserva.dequeue();
                                        if (reservaEliminada != null)
                                        {
                                            Console.WriteLine("Reserva eliminada!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 3:
                                        reserva.Mostrar();
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        if (reserva.VerificarListaVacia())
                                        {
                                            Console.WriteLine("La cola está vacía!");
                                        }
                                        else
                                        {
                                            while (!reserva.VerificarListaVacia())
                                            {
                                                v = reserva.dequeue(false);
                                                pila.push(v);
                                            }
                                            Console.WriteLine("Elementos de la cola transferidos a pila!");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Reserva reservaEliminadaPila = pila.pop();
                                        if (reservaEliminadaPila != null)
                                        {
                                            Console.WriteLine("Reserva eliminada de la pila! ");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 6:
                                        pila.muestraPila();
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine(" Ingrese un valor correcto!");
                                Console.ReadKey();
                            }

                        } while (opcion_reserva != 7);
                            break;
                        case 6:
                            MantenimientoServicios();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine(" Ingrese un valor valido");
                    Console.ReadKey();
                }
            } while (op != 7);

        }

        public static void IngresoDatos()
        {
            do
            {
                Console.Write(" Ingresar Nombre: ");
                C_nombre = Console.ReadLine();
                if (int.TryParse(C_nombre, out _) == true)
                {
                    Console.WriteLine("Ingrese un valor correcto");
                }
            }
            //Mientras que los valores pasados se puedan convertir a entero, va a seguir en el bucle
            //Sino sale del bucle, ya que el valor que se estaria pasando seria un string
            while (int.TryParse(C_nombre, out _));
            do
            {
                Console.Write(" Ingresar Dni: ");
                C_dni = Console.ReadLine();
                if (!EsDNIValido(C_dni))
                {
                    Console.WriteLine("Coloque un DNI valido");
                }
            }
            while (!EsDNIValido(C_dni));


            Console.Write(" Ingresar Fecha de Nacimiento: ");
            C_f_nac = Console.ReadLine();

            Console.Write(" Ingresar Email: ");
            C_email = Console.ReadLine();

            do
            {
                Console.Write(" Ingresar Telefono: ");
                C_telf = Console.ReadLine();
                if (!EsTelfValido(C_telf))
                {
                    Console.WriteLine("Coloque un telefono valido");
                }
            }
            while (!EsTelfValido(C_telf));

            Console.WriteLine(" Cliente Ingresado Correctamente!");
            Console.ReadKey();
        }
        //validaciones empleados
        public static void IngresoDatos2()
        {
            do
            {
                Console.Write("Ingresar Nombre: ");
                Empleado_nom = Console.ReadLine();
            }

            while
            (int.TryParse(Empleado_nom, out _));

            do
            {
                Console.Write("Ingresar DNI: ");
            } while (!int.TryParse(Console.ReadLine(), out Empleado_dni));

            do
            {
                Console.Write(" Ingresar Correo: ");
                Empleado_correo = Console.ReadLine();
            } while (int.TryParse(Empleado_correo, out _));

            do
            {
                Console.Write("Ingresar Telefono: ");
            } while (!int.TryParse(Console.ReadLine(), out Empleado_telefono));

            do
            {
                Console.Write("Ingresar Direccion: ");
                Empleado_direccion = Console.ReadLine();
            } while (int.TryParse(Empleado_direccion, out _));

            do
            {
                Console.Write("Ingresar Cargo: ");
                Empleado_cargo = Console.ReadLine();
            } while (int.TryParse(Empleado_cargo, out _));

            do
            {
                Console.Write("Ingresar Sueldo: ");
            } while (!int.TryParse(Console.ReadLine(), out Empleado_sueldo));

            Console.WriteLine(" Empleado Ingresado Correctamente!");
            Console.ReadKey();
        }

        public static void IngresoDatosMateriales()
        {
            do
            {
                Console.Write(" Ingresar la Categoria: ");
                MT_categoria = Console.ReadLine();
                if (int.TryParse(MT_categoria, out _) == true)
                {
                    Console.WriteLine("Ingrese un valor correcto");
                }
            }
            while (int.TryParse(MT_categoria, out _));
            do
            {
                Console.Write(" Ingresar Nombre del Material: ");
                MT_nombre_material = Console.ReadLine();
                if (int.TryParse(MT_nombre_material, out _) == true)
                {
                    Console.WriteLine("Ingrese un valor correcto");
                }
            }
            while (int.TryParse(MT_nombre_material, out _));

            do
            {
                Console.Write("Ingresar Costo: ");
            } while (!double.TryParse(Console.ReadLine(), out MT_costo));



            Console.WriteLine(" Material Ingresado Correctamente!");
            Console.ReadKey();
        }

        static bool EsDNIValido(string dni)
        {
            // la clase 'Regex' nos sirve para verificar que el DNI contenga solo números
            //Por lo tanto le estamos diciendo que acepte los digitos desde 0 a 9
            //y tambien que solo acepte 8 caracteres.
            Regex regex = new Regex(@"^\d{8}$");
            return regex.IsMatch(dni);
        }

        static bool EsTelfValido(string telf)
        {
            // la clase 'Regex' nos sirve para verificar que el DNI contenga solo números
            //Por lo tanto le estamos diciendo que acepte los digitos desde 0 a 9
            //y tambien que solo acepte 9 caracteres.
            Regex regex = new Regex(@"^\d{9}$");
            return regex.IsMatch(telf);
        }
        public static void IngresoDatosReserva()
        {
            do
            {
                Console.Write("Ingresar ID de la habitación (4 dígitos): ");
            } while (!int.TryParse(Console.ReadLine(), out reser_habitacion) || reser_habitacion.ToString().Length != 4);

            do
            {
                Console.Write("Ingresar ID del Cliente (4 dígitos): ");
            } while (!int.TryParse(Console.ReadLine(), out reser_cliente) || reser_cliente.ToString().Length != 4);
            do
            {
                Console.Write("Ingrese Fecha de Inicio (Dia/Mes/Año): ");
            } while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out reser_fecha_inicio));

            do
            {
                Console.Write("Ingrese Fecha de Final (Dia/Mes/Año): ");
            } while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out reser_fecha_final));

            Console.WriteLine("Reservacion Satisfactoria!");
            Console.ReadKey();
        }

        public static void MantenimientoServicios()
        {
            while (true)
            {
                Console.Clear();
                string[] validar2 = { "1", "2", "3", "4", "5" };
                Console.WriteLine(" ===============================================");
                Console.WriteLine("\n\t    SERVICIOS");
                Console.WriteLine("\n\t[1] Ingresar Servicios");
                Console.WriteLine("\t[2] Eliminar Servicios");
                Console.WriteLine("\t[3] Visualizar Servicios");
                Console.WriteLine("\t[4] Mostrar de pila a cola");
                Console.WriteLine("\t[5] Regresar al Menú Principal");
                Console.WriteLine(" ===============================================");
                string dato2 = Console.ReadLine();
                int opcion2 = validar2.Contains(dato2) ? int.Parse(dato2) : 0;
                switch (opcion2)
                {
                    case 1:
                        IngresoServicios();
                        break;
                    case 2:
                        EliminarServicios();
                        break;
                    case 3:
                        VisualizarServicios();
                        break;
                    case 4:
                        VisualizarServiciosEliminados();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine(" Opción no válida");
                        Console.ReadLine();
                        break;
                }
                if (opcion2 == 5)
                {
                    break;
                }
            }
        }

        public static void IngresoServicios()
        {
            Console.Clear();
            Console.WriteLine(" =============================================");
            Console.WriteLine("   DATOS DEL SERVICIO");
            Console.WriteLine(" =============================================");
            Console.Write("  Id.Servicios     : " + _idServicio.ToString() + "\n");
            Console.Write("  Nombre Servicio  : ");
            string nombreServicio = Console.ReadLine();
            Console.Write("  Descripción      : ");
            string descServicio = Console.ReadLine();
            Console.Write("  Horario          : ");
            string horario = Console.ReadLine();
            Console.Write("  Precio           : ");
            string precio = Console.ReadLine();

            NodoServicio _servicio = new NodoServicio
            {
                IdServicio = _idServicio,
                Nombre_servi = nombreServicio,
                Descripcion = descServicio,
                Horario = horario,
                Precio = String.IsNullOrWhiteSpace(precio) ? 0 : Decimal.Parse(precio)
            };
            _servicios.push(_servicio);
            _idServicio++;
            VisualizarServicios();
        }

        public static void EliminarServicios()
        {
            if (_servicios.Tope() != null)
            {
                _eliminados.Enqueue(_servicios.pop());
                Console.WriteLine("Servicio Eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Pila vacia");
            }
            Console.ReadKey();
        }

        public static void VisualizarServicios()
        {
            Console.Clear();
            Console.WriteLine("SERVICIOS");
            Console.WriteLine("╔════════════╦══════════════════════════╦═════════════════════════════╦═════════════════════════╦════════╗");
            Console.WriteLine("║     NRO.   ║                          ║                             ║                         ║        ║");
            Console.WriteLine("║  SERVICIO  ║        SERVICIO          ║        DESCRIPCION          ║      HORARIO            ║ PRECIO ║");
            Console.WriteLine("╠════════════╬══════════════════════════╬═════════════════════════════╬═════════════════════════╬════════╣");
            if (_servicios.Tope() != null)
            {
                MostrarServicio(_servicios.Tope());
            }
            Console.WriteLine("╚════════════╩══════════════════════════╩═════════════════════════════╩═════════════════════════╩════════╝");
            Console.ReadLine();
        }

        public static void MostrarServicio(NodoServicio unServicio)
        {



            Console.WriteLine("║" + unServicio.IdServicio.ToString().PadLeft(5, ' ') + "       ║" +
                              unServicio.Nombre_servi.PadRight(26, ' ') + "║" +
                              unServicio.Descripcion.PadRight(29, ' ') + "║" +
                              unServicio.Horario.PadRight(25, ' ').Substring(0, 25) + "║" +
                              unServicio.Precio.ToString().PadRight(8, ' ') + "║");
            if (unServicio.Siguiente != null)
            {
                MostrarServicio(unServicio.Siguiente);
            }
        }
        public static void VisualizarServiciosEliminados()
        {
            Console.Clear();
            Console.WriteLine("SERVICIOS ELIMINADOS - COLA ");
            Console.WriteLine("╔════════════╦══════════════════════════╦═════════════════════════════╦══════════════════════╦════════╗");
            Console.WriteLine("║     NRO.   ║                          ║                             ║                      ║        ║");
            Console.WriteLine("║  SERVICIO  ║        SERVICIO          ║        DESCRIPCION          ║      HORARIO         ║ PRECIO ║");
            Console.WriteLine("╠════════════╬══════════════════════════╬═════════════════════════════╬══════════════════════╬════════╣");
            MostrarServicioEliminado(_eliminados.Peek);
            Console.WriteLine("╚════════════╩══════════════════════════╩═════════════════════════════╩══════════════════════╩════════╝");
            Console.ReadLine();
        }
        public static void MostrarServicioEliminado(NodoServicioEliminado unServicioEliminado)
        {
            if (unServicioEliminado != null)
            {
                Console.WriteLine("║" + unServicioEliminado.IdServicio.ToString().PadLeft(5, ' ') + "       ║" +
                             unServicioEliminado.Nombre_servi.PadRight(26, ' ') + "║" +
                             unServicioEliminado.Descripcion.PadRight(29, ' ') + "║" +
                             unServicioEliminado.Horario.PadRight(22, ' ') + "║" +
                             unServicioEliminado.Precio.ToString().PadRight(8, ' ') + "║");
                if (unServicioEliminado != null)
                {
                    MostrarServicioEliminado(unServicioEliminado.Siguiente);
                }
            }
        }
    }
}
