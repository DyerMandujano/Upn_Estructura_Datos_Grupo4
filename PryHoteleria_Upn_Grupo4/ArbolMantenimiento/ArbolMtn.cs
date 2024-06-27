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
            //la propiedad Arbol_Mant se inicializa como 'null'
            Arbol_Mant = null;
        }

        public void insertaNodo(Mantenimiento new_mant)
        {
            //La variable valorRaiz será el valor base en donde cada vez que se ingresa un nodo, se compará con está
            string valorRaiz;
            //Instanciamos el nuevo nodo que se va a ingresar
            NodoMantenimiento q = new NodoMantenimiento(new_mant);
            //Creamos el objeto 't' que nos servirá para recorrer el Arbol
            NodoMantenimiento t = Arbol_Mant;
            //Esta variable nos permite saber el nivel en donde se encuentra cada nodo
            int nivel = 0;

            //Si el arbol es null
            if (Arbol_Mant == null)
            {
                //Agrega el nuevo nodo al arbol
                Arbol_Mant = q;
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
                    valorRaiz = t.Dato.Tipo_Mant;

                    //Si el nuevo objeto 'new_mant' se encuentrá antes (-1) que el 'valorRaiz' de forma alfabetica 
                    if (new_mant.Tipo_Mant.CompareTo(valorRaiz) == -1)
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

                return;
            }
            else
            {
                while (t != null)
                {
                    nivel++;
                    //En 'valorRaiz' almacenamos el valor base o primer valor que se encuentra en el arbol
                    valorRaiz = t.Dato.Tipo_Mant;
                    //Si el valor pasado por parametro 'buscar_mant' es IGUAL al valorRaiz
                    if (buscar_mant.CompareTo(valorRaiz) == 0)
                    {
                        //Imprime lo siguiente en consola
                        Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine(" ║                                           MANTENIMIENTO ENCONTRADO                                                   ║");
                        Console.WriteLine(" ╠══════════════╦════════════════╦════════════╦═══════════════════╦══════════════════╦═══════════════════════╦══════════╣");
                        Console.WriteLine(" ║  IdMantenim  ║  IdHabitacion  ║ IdEmpleado ║ Fecha de Mantenim ║ Tipo de Mantenim ║      Descripcion      ║   Nivel  ║");
                        Console.WriteLine(" ╠══════════════╬════════════════╬════════════╬═══════════════════╬══════════════════╬═══════════════════════╬══════════╣");
                        Console.WriteLine(" ║{0,14}║{1,16}║{2,12}║{3,19}║{4,18}║{5,23}║{6,10}║", t.Dato.Id, t.Dato.IdHabit, t.Dato.IdEmple, t.Dato.Fecha_Mant, t.Dato.Tipo_Mant, t.Dato.Descrip_Mant, t.Dato.Nivel);
                        Console.WriteLine(" ╚══════════════╩════════════════╩════════════╩═══════════════════╩══════════════════╩═══════════════════════╩══════════╝");
                        return;
                    }
                    //Si el valor pasado por parametro 'buscar_mant' se encuentrá antes (-1) que el 'valorRaiz' de forma alfabetica
                    else if (buscar_mant.CompareTo(valorRaiz) == -1)
                    {
                        //Ahora, si el nodoIzquierdo es diferente de null
                        if (t.N_Izq != null)
                        {
                            //entonces el t apunta al nodo izquierdo (Hasta encontrar una posición vacia, es decir hasta que sea null)
                            //Es decir, el objeto 't' almacenará todo los valores del objeto que se encuentra en el NodoIzquierdo
                            t = t.N_Izq;
                        }
                        //De lo contrario
                        //Si ya recorrio todo ese lado, es decir que el 't.N_Izq == null'
                        else
                        {
                            //Entonces no se encuentra.
                            Console.WriteLine("El Tipo de Mantenimiento "+ buscar_mant+ " NO se encuentra en el arbol!!");
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
                            //luego de la linea de codigo 189, entrará nuevamente al While ya que el 't' al tener los valores del objeto 'N_Der'
                            //seguirá siendo diferente de 'null'.
                        }
                        //De lo contrario
                        //Si ya recorrio todo ese lado, es decir que el 't.N_Der == null'
                        else
                        {
                            //Entonces no se encuentra.
                            Console.WriteLine("El Tipo de Mantenimiento " + buscar_mant + " NO se encuentra en el arbol!!");
                            //Termina el programa
                            return;
                        }
                    }
                }
            }
        }

    }

}

