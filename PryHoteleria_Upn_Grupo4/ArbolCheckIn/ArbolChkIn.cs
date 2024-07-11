using PryHoteleria_Upn_Grupo4.ArbolMantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolCheckIn
{
    class ArbolChkIn
    {
        private NodoCheckIn arbol_checkin;

        public NodoCheckIn Arbol_CheckIn
        {
            get { return arbol_checkin; }
            set { arbol_checkin = value; }
        }

        public ArbolChkIn()
        {
            Arbol_CheckIn = null;
        }

        public void insertaNodo(CheckIn new_check)
        {
            //La variable valorRaiz será el valor base en donde cada vez que se ingresa un nodo, se compará con está
            string valorRaiz;
            //Instanciamos el nuevo nodo que se va a ingresar
            NodoCheckIn q = new NodoCheckIn(new_check);
            //Creamos el objeto 't' que nos servirá para recorrer el Arbol
            NodoCheckIn t = Arbol_CheckIn;
            //Esta variable nos permite saber el nivel en donde se encuentra cada nodo
            int nivel = 0;

            //Si el arbol es null
            if (Arbol_CheckIn == null)
            {
                //Agrega el nuevo nodo al arbol
                Arbol_CheckIn = q;
            }
            //De lo contrario
            else
            {
                //Mientras el objeto 't' sea diferente de null
                while (t != null)
                {
                    //La variable 'nivel' aumenta en 1
                    nivel++;
                    //En 'valorRaiz' almacenamos el valor base o primer valor que se encuentra en el arbol
                    //para luego poder realizar las comparaciones.
                    valorRaiz = t.Dato.Tipo_Serv_Adic;

                    //Si el nuevo objeto 'new_mant' se encuentrá antes (-1) que el 'valorRaiz' de forma alfabetica 
                    if (new_check.Tipo_Serv_Adic.CompareTo(valorRaiz) == -1)
                    {
                        //NOTA: Y por Teoria de Arboles, SI UN OBJETO ES MENOR SE VA PARA LA IZQUIERDA
                        //Ahora, si el nodoIzquierdo es diferente de null
                        if (t.N_Izq != null)
                        {
                            //entonces el t apunta al nodo izquierdo (Hasta encontrar una posición vacia, es decir hasta que sea null)
                            //Es decir, el objeto 't' almacenará todo los valores del objeto que se encuentra en el NodoIzquierdo
                            t = t.N_Izq;
                            //luego de la linea de codigo 64, entrará nuevamente al While ya que el 't' al tener los valores del objeto 'N_Izquierda'
                            //seguirá siendo diferente de 'null'.
                        }
                        //De lo contrario
                        //Si ya encontró una posición vacia, es decir que el 't.N_Izq == null'
                        else
                        {
                            //Le colocamos el valor de la variable 'nivel' a la propiedad NIVEL del nuevo Nodo 'q'
                            q.Dato.Nivel = nivel;
                            //Se ingresa el nuevo nodo 'q' allí 
                            t.N_Izq = q;
                            //Y termina la función
                            return;
                        }
                    }
                    //De lo contrario, Si el nuevo objeto 'new_mant' es posterior o igual que el 'valorRaiz' de forma alfabetica
                    else
                    {
                        //NOTA: Y por Teoria de Arboles, SI UN OBJETO ES MAYOR O IGUAL SE VA PARA LA DERECHA
                        //Ahora, si el nodoDerecho es diferente de null
                        if (t.N_Der != null)
                        {
                            //entonces el t apunta al nodo derecho (Hasta encontrar una posición vacia, es decir hasta que sea null)
                            //Es decir, el objeto 't' almacenará todo los valores del objeto que se encuentra en el NodoDerecho
                            t = t.N_Der;
                            //luego de la linea de codigo 90, entrará nuevamente al While ya que el 't' al tener los valores del objeto 'N_Der'
                            //seguirá siendo diferente de 'null'.
                        }
                        //De lo contrario
                        //Si ya encontró una posición vacia, es decir que el 't.N_Der == null'
                        else
                        {
                            //Le colocamos el valor de la variable 'nivel' a la propiedad NIVEL del nuevo Nodo 'q'
                            q.Dato.Nivel = nivel;
                            //Se ingresa el nuevo nodo 'q' allí 
                            t.N_Der = q;
                            //Y termina la función
                            return;
                        }
                    }
                }
            }
        }

        public void muestraArbol(NodoCheckIn arbol, int cont)
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
                Console.WriteLine(arbol.Id_CheckIn + "." + arbol.Dato.Tipo_Serv_Adic);
                muestraArbol(arbol.N_Izq, cont + 1);
            }
        }

        public void buscarTipoServ(string buscar_serv)
        {
            string valorRaiz;
            NodoCheckIn t = Arbol_CheckIn;
            int nivel = 0;

            if (Arbol_CheckIn == null)
            {
                Console.WriteLine("Arbol vacio, no se puede ejecutar la operacion");
            }
            else
            {
                while (t != null)
                {
                    nivel++;
                    //En 'valorRaiz' almacenamos el valor base o primer valor que se encuentra en el arbol
                    valorRaiz = t.Dato.Tipo_Serv_Adic;
                    //Si el valor pasado por parametro 'buscar_mant' es IGUAL al valorRaiz
                    if (buscar_serv.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine(" ╔════════════════════════════════════════╗");
                        Console.WriteLine(" ║  TERMINO ENCONTRADO                    ║");
                        Console.WriteLine(" ╠════════════════════════════════════════╣");
                        Console.WriteLine(" ║ Tipo Servicio :{0,-24}║", t.Dato.Tipo_Serv_Adic);
                        Console.WriteLine(" ║ Nombre Servicio :{0,-22}║", t.Dato.Nom_Serv);
                        Console.WriteLine(" ╚════════════════════════════════════════╝");
                        //Si el nodoDerecho es diferente de null
                        if (t.N_Der != null)
                        {
                            //Avanza al siguiente Nodo y almacena sus datos
                            t = t.N_Der;
                        }
                        //De lo contrario
                        else
                        {
                            //Termina la funcion
                            return;
                        }
                    }
                    //Si el valor pasado por parametro 'buscar_mant' se encuentrá antes (-1) que el 'valorRaiz' de forma alfabetica
                    else if (buscar_serv.CompareTo(valorRaiz) == -1)
                    {
                        //Ahora, si el nodoIzquierdo es diferente de null
                        if (t.N_Izq != null)
                        {
                            //entonces el t apunta al nodo izquierdo (Hasta encontrar una posición vacia, es decir hasta que sea null)
                            //Es decir, el objeto 't' almacenará todo los valores del objeto que se encuentra en el NodoIzquierdo
                            t = t.N_Izq;
                        }
                        else
                        {
                            
                            //Entonces no se encuentra.
                            Console.WriteLine("Busqueda Concluida!!");
                            //Termina el programa
                            return;
                        }
                    }
                    //De lo contrario, Si el valor 'buscar_mant' es posterior que el 'valorRaiz' de forma alfabetica
                    else
                    {
                        //Ahora, si el nodoDerecho es diferente de null
                        if (t.N_Der != null)
                        {
                            //entonces el t apunta al nodo derecho (Hasta encontrar una posición vacia, es decir hasta que sea null)
                            //Es decir, el objeto 't' almacenará todo los valores del objeto que se encuentra en el NodoDerecho
                            t = t.N_Der;
                        }
                        //De lo contrario
                        //Si ya recorrio todo ese lado, es decir que el 't.N_Der == null'
                        else
                        {
                            //Entonces no se encuentra.
                            Console.WriteLine("Busqueda Concluida!!");
                            //Termina el programa
                            return;
                        }
                    }
                }
            }
        }

        //Metodos para recorrer el arbol por Profundidad
        //Metodo para mostrar el arbol en PreOrden
        //PreOrden : Raiz - Arbol Izquierdo - Arbol Derecho
        public void preOrden(NodoCheckIn arbol)
        {
            //Si el arbol no es nulo
            if (arbol != null)
            {
                //Mostrar datos
                Console.WriteLine(" ╔═══════════════════════════╗");
                Console.WriteLine(" ║  DATOS CHECKIN            ║");
                Console.WriteLine(" ╠═══════════════════════════╬═════════════════╗");
                Console.WriteLine(" ║Cliente                    ║ {0,-16}║", arbol.Dato.Nombre_Cli);
                Console.WriteLine(" ║DNI                        ║ {0,-16}║", arbol.Dato.Dni_Cli);
                Console.WriteLine(" ║IdHabitación               ║ {0,-16}║", arbol.Dato.Id_Habi);
                Console.WriteLine(" ║Num de Personas            ║ {0,-16}║", arbol.Dato.Num_Per);
                Console.WriteLine(" ║Fecha de CheckIn           ║ {0,-16}║", arbol.Dato.Fecha_CheckIn);
                Console.WriteLine(" ║Tipo de Servicio Adicional ║ {0,-16}║", arbol.Dato.Tipo_Serv_Adic);
                Console.WriteLine(" ║Nombre Servicio            ║ {0,-16}║", arbol.Dato.Nom_Serv);
                Console.WriteLine(" ╚═══════════════════════════╩═════════════════╝");
                //Mostrar el arbol por la izquierda
                preOrden(arbol.N_Izq);
                //Mostrar el arbol por la derecha
                preOrden(arbol.N_Der);
            }
        }


        //Metodo para mostrar el arbol en InOrden
        //InOrden : Arbol Izquierdo - Raiz - Arbol Derecho
        public void inOrden(NodoCheckIn arbol)
        {
            //Si el arbol no es nulo
            if (arbol != null)
            {
                //Mostrar el arbol por la izquierda
                inOrden(arbol.N_Izq);
                //Mostrar datos
                Console.WriteLine(" ╔═══════════════════════════╗");
                Console.WriteLine(" ║  DATOS CHECKIN            ║");
                Console.WriteLine(" ╠═══════════════════════════╬═════════════════╗");
                Console.WriteLine(" ║Cliente                    ║ {0,-16}║", arbol.Dato.Nombre_Cli);
                Console.WriteLine(" ║DNI                        ║ {0,-16}║", arbol.Dato.Dni_Cli);
                Console.WriteLine(" ║IdHabitación               ║ {0,-16}║", arbol.Dato.Id_Habi);
                Console.WriteLine(" ║Num de Personas            ║ {0,-16}║", arbol.Dato.Num_Per);
                Console.WriteLine(" ║Fecha de CheckIn           ║ {0,-16}║", arbol.Dato.Fecha_CheckIn);
                Console.WriteLine(" ║Tipo de Servicio Adicional ║ {0,-16}║", arbol.Dato.Tipo_Serv_Adic);
                Console.WriteLine(" ║Nombre Servicio            ║ {0,-16}║", arbol.Dato.Nom_Serv);
                Console.WriteLine(" ╚═══════════════════════════╩═════════════════╝");
                //Mostrar el arbol por la derecha
                inOrden(arbol.N_Der);
            }
        }


        //Metodo para mostrar el arbol en PostOrden
        //PostOrden : Arbol Izquierdo - Arbol Derecho - Raiz
        public void postOrden(NodoCheckIn arbol)
        {
            //Si el arbol no es nulo
            if (arbol != null)
            {
                //Mostrar el arbol por la izquierda
                postOrden(arbol.N_Izq);
                //Mostrar el arbol por la derecha
                postOrden(arbol.N_Der);
                //Mostrar datos
                Console.WriteLine(" ╔═══════════════════════════╗");
                Console.WriteLine(" ║  DATOS CHECKIN            ║");
                Console.WriteLine(" ╠═══════════════════════════╬═════════════════╗");
                Console.WriteLine(" ║Cliente                    ║ {0,-16}║", arbol.Dato.Nombre_Cli);
                Console.WriteLine(" ║DNI                        ║ {0,-16}║", arbol.Dato.Dni_Cli);
                Console.WriteLine(" ║IdHabitación               ║ {0,-16}║", arbol.Dato.Id_Habi);
                Console.WriteLine(" ║Num de Personas            ║ {0,-16}║", arbol.Dato.Num_Per);
                Console.WriteLine(" ║Fecha de CheckIn           ║ {0,-16}║", arbol.Dato.Fecha_CheckIn);
                Console.WriteLine(" ║Tipo de Servicio Adicional ║ {0,-16}║", arbol.Dato.Tipo_Serv_Adic);
                Console.WriteLine(" ║Nombre Servicio            ║ {0,-16}║", arbol.Dato.Nom_Serv);
                Console.WriteLine(" ╚═══════════════════════════╩═════════════════╝");
            }
        }

    }
}
