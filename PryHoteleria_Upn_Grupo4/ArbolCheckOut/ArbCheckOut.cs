using PryHoteleria_Upn_Grupo4.ArbolCheckIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolCheckOut
{
    class ArbCheckOut
    {
        private NodoCheckOut arbol_checkout;

        public NodoCheckOut Arbol_CheckOut
        {
            get { return arbol_checkout; }
            set { arbol_checkout = value; }
        }

        public ArbCheckOut()
        {
            Arbol_CheckOut = null;
        }

        public void insertaNodo(CheckOut new_checkout)
        {
            //La variable valorRaiz será el valor base en donde cada vez que se ingresa un nodo, se compará con está
            string valorRaiz;
            //Instanciamos el nuevo nodo que se va a ingresar
            NodoCheckOut q = new NodoCheckOut(new_checkout);
            //Creamos el objeto 't' que nos servirá para recorrer el Arbol
            NodoCheckOut t = Arbol_CheckOut;
            //Esta variable nos permite saber el nivel en donde se encuentra cada nodo
            int nivel = 0;

            //Si el arbol es null
            if (Arbol_CheckOut == null)
            {
                //Agrega el nuevo nodo al arbol
                Arbol_CheckOut = q;
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
                    valorRaiz = t.Dato.MetodoPago;

                    //Si el nuevo objeto 'new_mant' se encuentrá antes (-1) que el 'valorRaiz' de forma alfabetica 
                    if (new_checkout.MetodoPago.CompareTo(valorRaiz) == -1)
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

        public void muestraArbol(NodoCheckOut arbol, int cont)
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
                Console.WriteLine(arbol.Id_CheckOut + "." + arbol.Dato.MetodoPago);
                muestraArbol(arbol.N_Izq, cont + 1);
            }
        }

        public void buscarTipoMetodoPago(string buscar_met_pag)
        {
            string valorRaiz;
            NodoCheckOut t = Arbol_CheckOut;
            int nivel = 0;

            if (Arbol_CheckOut == null)
            {
                Console.WriteLine("Arbol vacio, no se puede ejecutar la operacion");
            }
            else
            {
                while (t != null)
                {
                    nivel++;
                    //En 'valorRaiz' almacenamos el valor base o primer valor que se encuentra en el arbol
                    valorRaiz = t.Dato.MetodoPago;
                    //Si el valor pasado por parametro 'buscar_mant' es IGUAL al valorRaiz
                    if (buscar_met_pag.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("\tTERMINO ENCONTRADO ... ");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine(" Tipo Metodo Pago       : " + t.Dato.MetodoPago);
                        Console.WriteLine(" Nombre Metodo Pago     : " + t.Dato.Nom_MetodoPago);
                        Console.WriteLine(" Monto Pagar            : " + t.Dato.Monto);
                        Console.WriteLine("--------------------------");
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
                    else if (buscar_met_pag.CompareTo(valorRaiz) == -1)
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
        public void preOrden(NodoCheckOut arbolcheckout)
        {
            //Si el arbol no es nulo
            if (arbolcheckout != null)
            {
                //Mostrar la Raiz
                Console.WriteLine("--------------------------");
                Console.WriteLine("\tTERMINO ENCONTRADO ... ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" Id Check Out           : " + arbolcheckout.Id_CheckOut);
                Console.WriteLine(" Nombre Cliente         : " + arbolcheckout.Dato.Nombre_Cli);
                Console.WriteLine(" DNI Cliente            : " + arbolcheckout.Dato.Dni_Cli);
                Console.WriteLine(" Id Habitacion          : " + arbolcheckout.Dato.Id_Habi);
                Console.WriteLine(" Fecha Check Out        : " + arbolcheckout.Dato.FechaCheckOut);
                Console.WriteLine(" Tipo Metodo Pago       : " + arbolcheckout.Dato.MetodoPago);
                Console.WriteLine(" Nombre Metodo Pago     : " + arbolcheckout.Dato.Nom_MetodoPago);
                Console.WriteLine(" Monto Pagar            : " + arbolcheckout.Dato.Monto);
                Console.WriteLine("--------------------------");
                //Mostrar el arbol por la izquierda
                preOrden(arbolcheckout.N_Izq);
                //Mostrar el arbol por la derecha
                preOrden(arbolcheckout.N_Der);
            }
        }
        //Metodo para mostrar el arbol en InOrden
        //InOrden : Arbol Izquierdo - Raiz - Arbol Derecho
        public void inOrden(NodoCheckOut arbolcheckout)
        {
            //Si el arbol no es nulo
            if (arbolcheckout != null)
            {
                //Mostrar el arbol por la izquierda
                inOrden(arbolcheckout.N_Izq);
                //Mostrar la Raiz
                Console.WriteLine("--------------------------");
                Console.WriteLine("\tTERMINO ENCONTRADO ... ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" Id Check Out           : " + arbolcheckout.Id_CheckOut);
                Console.WriteLine(" Nombre Cliente         : " + arbolcheckout.Dato.Nombre_Cli);
                Console.WriteLine(" DNI Cliente            : " + arbolcheckout.Dato.Dni_Cli);
                Console.WriteLine(" Id Habitacion          : " + arbolcheckout.Dato.Id_Habi);
                Console.WriteLine(" Fecha Check Out        : " + arbolcheckout.Dato.FechaCheckOut);
                Console.WriteLine(" Tipo Metodo Pago       : " + arbolcheckout.Dato.MetodoPago);
                Console.WriteLine(" Nombre Metodo Pago     : " + arbolcheckout.Dato.Nom_MetodoPago);
                Console.WriteLine(" Monto Pagar            : " + arbolcheckout.Dato.Monto);
                Console.WriteLine("--------------------------");
                //Mostrar el arbol por la derecha
                inOrden(arbolcheckout.N_Der);
            }
        }
        //Metodo para mostrar el arbol en PostOrden
        //PostOrden : Arbol Izquierdo - Arbol Derecho - Raiz
        public void postOrden(NodoCheckOut arbolcheckout)
        {
            //Si el arbol no es nulo
            if (arbolcheckout != null)
            {
                //Mostrar el arbol por la izquierda
                postOrden(arbolcheckout.N_Izq);
                //Mostrar el arbol por la derecha
                postOrden(arbolcheckout.N_Der);
                //Mostrar la Raiz
                Console.WriteLine("--------------------------");
                Console.WriteLine("\tTERMINO ENCONTRADO ... ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" Id Check Out           : " + arbolcheckout.Id_CheckOut);
                Console.WriteLine(" Nombre Cliente         : " + arbolcheckout.Dato.Nombre_Cli);
                Console.WriteLine(" DNI Cliente            : " + arbolcheckout.Dato.Dni_Cli);
                Console.WriteLine(" Id Habitacion          : " + arbolcheckout.Dato.Id_Habi);
                Console.WriteLine(" Fecha Check Out        : " + arbolcheckout.Dato.FechaCheckOut);
                Console.WriteLine(" Tipo Metodo Pago       : " + arbolcheckout.Dato.MetodoPago);
                Console.WriteLine(" Nombre Metodo Pago     : " + arbolcheckout.Dato.Nom_MetodoPago);
                Console.WriteLine(" Monto Pagar            : " + arbolcheckout.Dato.Monto);
                Console.WriteLine("--------------------------");
            }
        }
    }
}
