using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    //Clase para implementar los metodos u operaciones de la lista de habitaciones
    internal class ListaHabitacion
    {
        //Definimos el nodo de tipo Habitacion
        private Habitacion lista_hab;


        //Propiedad Lista_habi para acceder a la lista_hab
        public Habitacion Lista_habi
        {
            get { return lista_hab; }
            set { lista_hab = value; }
        }

        //Definimos el constructor e inicializamos la lista habitacion
        public ListaHabitacion() 
        {
            //la propiedad 'Lista_habi' será null
            Lista_habi = null;
        }

        //Metodo para determinar si la lista esta vacia
        public bool VerificarListaVacia()
        {
            if (Lista_habi == null)
            {
                return true;
            }
            else return false;
        }

        public void InsertarHabitacionInicio(string tipoHab, int cap, double precio, string serv_hab)
        {
            //Creamos el nodo habitacion a ingresar
            Habitacion q = new Habitacion(tipoHab, cap, precio, serv_hab);
            if (Lista_habi == null)
            {
                //La lista apuntará al objeto 'q' que estamos agregando.
                Lista_habi = q;
                // El nuevo Habitacion apunta al inicio de la lista y no a Null.
                // Por lo tanto seria una lista circular.
                q.H_Sgte = Lista_habi;
            }
            else
            {
                //El valor ingresado a punta a la lista que ya se encontraba
                q.H_Sgte = Lista_habi;

                Habitacion p = Lista_habi;
                // Mientra que el p no apunte a la Lista_habi
                while (p.H_Sgte != Lista_habi)
                {
                    //avanza al siguiente nodo
                    p = p.H_Sgte;
                }

                // El último Habitacion apunta al nuevo Habitacion que se está ingresando
                p.H_Sgte = q;

                //La lista apunta al 'q' para q este sea el nuevo valor inicial
                Lista_habi = q;
            }
        }

        public void InsertarHabitacionAlFinal(string tipoHab, int cap, double precio, string serv_hab)
        {
            //Creamos el nodo q que se ingresara al final de la lista
            Habitacion q = new Habitacion(tipoHab, cap, precio, serv_hab);
            //Si la lista es Null
            if (Lista_habi == null)
            {
                //La lista apuntará al objeto 'q' que estamos agregando.
                Lista_habi = q;
                // El nuevo Habitacion apunta al inicio de la lista y no a Null.
                // Por lo tanto seria una lista circular.
                q.H_Sgte = Lista_habi;

            }
            //DE LO CONTRARIO, SI HAY ELEMENTOS EN LA LISTA
            else
            {
                //Esta variable 'p' se utilizará para recorrer la lista hasta encontrar el último nodo.
                //Por lo que a 'p' le asignamos todos los valores que se encuentra en la Lista_habi
                Habitacion p = Lista_habi;
                //Mientras la propiedad H_Sgte sea distinto de la lista habitacion
                while (p.H_Sgte != Lista_habi)
                {
                    //Avanzará hasta el ultimo nodo
                    p = p.H_Sgte;
                }
                //UNA VEZ ENCONTRADO EL ULTIMO NODO
                //La propiedad H_Sgte apuntará a la nueva habitacion ingresada
                p.H_Sgte = q;
                //Ahora la direccion de la nueva habitacion ingresada apuntará a la Lista_habi
                // Por lo tanto seria una lista circular.
                q.H_Sgte = Lista_habi;
            }
        }

        public void EliminarHabitacionInicio()
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }
            else
            {
                //Cuando hay un solo nodo en la lista
                //Si la lista se apunta a si misma 
                if (Lista_habi.H_Sgte == Lista_habi)
                {
                    //Al momento de eliminar el unico nodo
                    //la lista apuntará a null
                    Lista_habi = null;
                }
                //De lo contrario
                else
                {
                    //instanciamos un objeto 'q' de tipo Habitacion 
                    Habitacion q = Lista_habi;
                    //Con el objeto 'q' recorremos la lista
                    //Mientras que el nodo 'q' no apunte al primer elemento de la lista
                    while (q.H_Sgte != Lista_habi)
                    {
                        //Avanza al siguiente nodo
                        q = q.H_Sgte;
                    }
                    //Una vez se termine el bucle
                    // El segundo nodo de la listaHabitacion se convierte en el primero
                    Lista_habi = Lista_habi.H_Sgte;
                    //Y el último nodo apunta al nuevo primer nodo
                    q.H_Sgte = Lista_habi;
                }
                Console.WriteLine("\n HABITACION INICIAL ELIMINADA!");
            }
        }

        public void EliminarHabitacionFinal()
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }
            else
            {
                //Cuando hay un solo nodo en la lista
                //Si la lista se apunta a si misma 
                if (Lista_habi.H_Sgte == Lista_habi)
                {
                    //Al momento de eliminar el unico nodo
                    //la lista apuntará a null
                    Lista_habi = null;
                }
                //De lo contrario
                else
                {
                    //EL 'p' NOS SERVIRA PARA RECORRER LA LISTA
                    Habitacion p = Lista_habi;
                    //El 'nd_ant' NOS SERVIRA PARA ALMACENAR LOS VALORES DEL 'p' MIENTRAS ESTE RECORRIENDO LA LISTA
                    Habitacion nd_ant = new Habitacion();
                    //Mientras que el nodo 'q' no apunte al primer elemento de la lista
                    while (p.H_Sgte != Lista_habi)
                    {
                        //LOS DATOS DEL OBJETO 'p' SE ALMACENARÁN EN EL OBJETO 'nd_anterior'
                        nd_ant = p;
                        //Y EL OBJETO 'p' IRA AL SIGUIENTE NODO DE LA LISTA
                        p = p.H_Sgte;
                    }
                    //Una vez se termine el bucle, Es decir se haya encontrado al ultimo no y eliminado...
                    // El penúltimo nodo apunta al primer nodo de la lista
                    nd_ant.H_Sgte = Lista_habi;
                }
                Console.WriteLine("\n HABITACION FINAL ELIMINADA!");
            }
        }

        //Metodo para eliminar la lista
        public void EliminaTodaLaLista()
        {
            Lista_habi = null;
            Console.WriteLine(" LISTA ELIMINADA CORRECTAMENTE!");
        }

        public void BuscarHabitacionPorId(int id)
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }

            Habitacion p = Lista_habi;
            bool encontrado = false;

            // Comprueba si el primer nodo es el que se busca
            if (p.Id == id)
            {
                encontrado = true;
            }

            // Si el primer nodo no es el que se busca, recorre la lista
            while (p.H_Sgte != Lista_habi && !encontrado)
            {
                p = p.H_Sgte;
                if (p.Id == id)
                {
                    encontrado = true;
                }
            }

            if (encontrado)
            {
                Console.WriteLine(" *****************************************************************************************************************");
                Console.WriteLine(" *|    ID    |      Tipo Habitacion      |      Capacidad      |   Precio por Noche  |    Servicios de la Habitacion|*");
                Console.WriteLine(" *****************************************************************************************************************");

                Console.WriteLine(" *|{0,10}|{1,18}|{2,15}|{3,21}|{4,26}|*", p.Id, p.Tipo_Habitacion, p.Capacidad, p.Precio_Noche, p.Serv_habitacion);
                Console.WriteLine(" *****************************************************************************************************************");
            }
            else
            {
                Console.WriteLine(" El Id " + id + " no se encuentra en la lista");
            }
        }

        public void ImprimirListaCircular()
        {
            //Si la lista es diferente a null
            if (Lista_habi != null)
            {
                //instanciamos un objeto p
                Habitacion p = Lista_habi;

                Console.WriteLine(" *****************************************************************************************************************");
                Console.WriteLine(" *|    ID    |      Tipo Habitacion      |      Capacidad      |   Precio por Noche  |    Servicios de la Habitacion|*");
                Console.WriteLine(" *****************************************************************************************************************");
                //Entra al bucle
                do
                {
                    Console.WriteLine(" *|{0,10}|{1,18}|{2,15}|{3,21}|{4,26}|*", p.Id, p.Tipo_Habitacion, p.Capacidad, p.Precio_Noche, p.Serv_habitacion);
                    // Avanza al siguiente nodo
                    p = p.H_Sgte;
                    Console.WriteLine(" *****************************************************************************************************************");
                }
                //Mientras que 'p' sea distinto al primer elemento de la Lista_habi
                //va a seguir imprimiendo los nodos.
                while (p != Lista_habi);
            }
            else
            {
                Console.WriteLine("La lista está vacía.");
            }
        }

    }
}
