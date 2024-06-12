using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    //Clase para implementar los metodos u operaciones de la lista de Clientes
    internal class ListaCliente
    {
        //Definimos el nodo de tipo Cliente
        private Cliente lista_cli;

        //Propiedad Lista_cliente para acceder a la lista_cli
        public Cliente Lista_cliente
        {
            get { return lista_cli; }
            set { lista_cli = value; }
        }

        //Definimos el constructor e inicializamos la listaclientes
        public ListaCliente()
        {
            //la propiedad 'Lista_cliente' será null
            Lista_cliente = null;
        }

        //Metodo para determinar si la lista esta vacia
        public bool VerificarListaVacia()
        {
            if (Lista_cliente == null)
            {
                return true;
            }
            else return false;
        }


        public void InsertarClienteInicio(string nombre, string dni, string f_nac, string email, string telefono)
        {
            //Creamos el nodo cliente a ingresar
            Cliente q = new Cliente(nombre, dni, f_nac, email, telefono);
            if (Lista_cliente == null)
            {
                //La lista apuntará al objeto 'q' que estamos agregando.
                Lista_cliente = q;
                // El nuevo cliente apunta al inicio de la lista y no a Null.
                // Por lo tanto seria una lista circular.
                q.Cl_Sgte = Lista_cliente;
            }
            else
            {
                //El valor ingresado a punta a la lista que ya se encontraba
                q.Cl_Sgte = Lista_cliente;

                Cliente p = Lista_cliente;
                // Mientra que el p no apunte a la Lista_cliente
                while (p.Cl_Sgte != Lista_cliente)
                {
                    //avanza al siguiente nodo
                    p = p.Cl_Sgte;
                }

                // El último cliente apunta al nuevo cliente que se está ingresando
                p.Cl_Sgte = q;

                //La lista apunta al 'q' para q este sea el nuevo valor inicial
                Lista_cliente = q;
            }
        }



        public void InsertarClienteAlFinal(string nombre, string dni, string f_nac, string email, string telefono)
        {
            //Creamos el objeto que se ingresará al final de la lista
            Cliente q = new Cliente(nombre, dni, f_nac, email, telefono);
            //Si la lista es Null
            if (Lista_cliente == null)
            {
                //La lista apuntará al objeto 'q' que estamos agregando.
                Lista_cliente = q;
                // El nuevo cliente apunta al inicio de la lista y no a Null.
                // Por lo tanto seria una lista circular.
                q.Cl_Sgte = Lista_cliente;

            }
            //DE LO CONTRARIO, SI HAY ELEMENTOS EN LA LISTA
            else
            {
                //Esta variable 'p' se utilizará para recorrer la lista hasta encontrar el último nodo.
                //Por lo que a 'p' le asignamos todos los valores que se encuentra en la Lista_cliente
                Cliente p = Lista_cliente;
                //Mientras la propiedad Cl_Sgte sea distinto de la lista cliente
                while (p.Cl_Sgte != Lista_cliente)
                {
                    //Avanzará hasta el ultimo nodo
                    p = p.Cl_Sgte;
                }
                //UNA VEZ ENCONTRADO EL ULTIMO NODO
                //La propiedad Cl_Sgte apuntará al nuevo Cliente ingresado
                p.Cl_Sgte = q;
                //Ahora la direccion del nuevo cliente ingresado apuntará a la Lista_cliente
                // Por lo tanto seria una lista circular.
                q.Cl_Sgte = Lista_cliente;
            }
        }



        public void EliminarClienteInicio()
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
                if (Lista_cliente.Cl_Sgte == Lista_cliente)
                {
                    //Al momento de eliminar el unico nodo
                    //la lista apuntará a null
                    Lista_cliente = null;
                }
                //De lo contrario
                else
                {
                    //instanciamos un objeto 'q' de tipo Cliente 
                    Cliente q = Lista_cliente;
                    //Con el objeto 'q' recorremos la lista
                    //Mientras que el nodo 'q' no apunte al primer elemento de la lista
                    while (q.Cl_Sgte != Lista_cliente)
                    {
                        //Avanza al siguiente nodo
                        q = q.Cl_Sgte;
                    }
                    //Una vez se termine el bucle
                    // El segundo nodo de la listaCliente se convierte en el primero
                    Lista_cliente = Lista_cliente.Cl_Sgte;
                    //Y el último nodo apunta al nuevo primer nodo
                    q.Cl_Sgte = Lista_cliente;
                }
                Console.WriteLine("\n CLIENTE INICIAL ELIMINADO!");
            }
        }

        public void EliminarClienteFinal()
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
                if (Lista_cliente.Cl_Sgte == Lista_cliente)
                {
                    //Al momento de eliminar el unico nodo
                    //la lista apuntará a null
                    Lista_cliente = null;
                }
                //De lo contrario
                else
                {
                    //EL 'p' NOS SERVIRA PARA RECORRER LA LISTA
                    Cliente p = Lista_cliente;
                    //El 'nd_ant' NOS SERVIRA PARA ALMACENAR LOS VALORES DEL 'p' MIENTRAS ESTE RECORRIENDO LA LISTA
                    Cliente nd_ant = new Cliente();
                    //Mientras que el nodo 'q' no apunte al primer elemento de la lista
                    while (p.Cl_Sgte != Lista_cliente)
                    {
                        //LOS DATOS DEL OBJETO 'p' SE ALMACENARÁN EN EL OBJETO 'nd_anterior'
                        nd_ant = p;
                        //Y EL OBJETO 'p' IRA AL SIGUIENTE NODO DE LA LISTA
                        p = p.Cl_Sgte;
                    }
                    //Una vez se termine el bucle, Es decir se haya encontrado al ultimo no y eliminado...
                    // El penúltimo nodo apunta al primer nodo de la lista
                    nd_ant.Cl_Sgte = Lista_cliente;
                }
                Console.WriteLine("\n CLIENTE FINAL ELIMINADO!");
            }
        }

        public void EliminarClientePorID(int id)
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }
            //flag para saber si se ha encontrado el ID
            bool encontrado = false;
            Cliente p = Lista_cliente;
            Cliente ant = null;

            //el do-while va a ejecutar el codigo por primera vez sin hacer caso a la condicion
            do
            {
                //Buscar el valor del nodo en la lista mediante el dato pasado por parametro
                //Es decir, Si el 'valor' pasado por parametro es igual al numero que se encuentra en la propiedad 'Id' del nodo
                if (p.Id == id)
                {
                    //Si el objeto 'p' que estoy buscando es el primero de la lista clientes
                    if (p == Lista_cliente)
                    {
                        //PUEDE HABER DOS CASOS
                        // Si solo hay un nodo en la lista, es decir que solo este el 'p'
                        if (Lista_cliente.Cl_Sgte == Lista_cliente)
                        {
                            Lista_cliente = null;
                        }
                        //de lo contrario
                        else
                        {
                            //Si hay mas nodos de tipo Cliente
                            // recorre la lista mediante el objeto 'p' hasta llegar al ultimo
                            while (p.Cl_Sgte != Lista_cliente)
                            {
                                //avanza al siguiente nodo
                                p = p.Cl_Sgte;
                            }
                            //una vez terminado el bucle
                            // El segundo nodo se convierte en el primero
                            Lista_cliente = Lista_cliente.Cl_Sgte;
                            // El último nodo apunta al nuevo primer nodo
                            p.Cl_Sgte = Lista_cliente;
                        }
                    }
                    //Caso contrario de que no este en el primer lugar
                    else
                    {
                        //el objeto 'ant' apuntará a la dirección del objeto 'q' Y NO AL MISMO OBJETO.
                        ant.Cl_Sgte = p.Cl_Sgte;
                    }
                    Console.WriteLine(" Cliente con ID " + id + " Eliminado Correctamente!");
                    encontrado = true;
                    break;
                }

                //el 'ant' almacena los valores del 'p'
                ant = p;
                //Avanza al siguiente nodo 
                p = p.Cl_Sgte;

            }
            //Mientras 'p' sea distinto del primer elemento
            while (p != Lista_cliente);

            if (!encontrado)
            {
                Console.WriteLine(" No se encontró ningún cliente con el ID " + id);
            }
        }

        //Metodo para eliminar la lista
        public void EliminaTodaLaLista()
        {
            Lista_cliente = null;
            Console.WriteLine(" LISTA ELIMINADA CORRECTAMENTE!");
        }


        public void BuscarClientePorDNI(string dni)
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }

            Cliente p = Lista_cliente;
            bool encontrado = false;

            // Comprueba si el primer nodo es el que se busca
            if (p.Dni == dni)
            {
                encontrado = true;
            }

            // Si el primer nodo no es el que se busca, recorre la lista
            while (p.Cl_Sgte != Lista_cliente && !encontrado)
            {
                p = p.Cl_Sgte;
                if (p.Dni == dni)
                {
                    encontrado = true;
                }
            }

            if (encontrado)
            {
                Console.WriteLine(" ╔══════════╦══════════════════╦═══════════════╦═════════════════════╦══════════════════════════╦══════════════╗");
                Console.WriteLine(" ║    ID    ║      Nombre      ║      DNI      ║   Fecha Nacimiento  ║          Correo          ║   Teléfono   ║");
                Console.WriteLine(" ╠══════════╬══════════════════╬═══════════════╬═════════════════════╬══════════════════════════╬══════════════╣");

                Console.WriteLine(" ║{0,10}║{1,18}║{2,15}║{3,21}║{4,26}║{5,14}║*", p.Id, p.Nombre, p.Dni, p.FechaNaci, p.Email, p.Telefono);
                Console.WriteLine(" ╚══════════╩══════════════════╩═══════════════╩═════════════════════╩══════════════════════════╩══════════════╝");
            }
            else
            {
                Console.WriteLine(" El DNI " + dni + " no se encuentra en la lista");
            }
        }

        public void ActualizarTelefPorId(int id)
        {
            Cliente p = Lista_cliente;
            Cliente inicio = p;
            bool clienteBuscado = false;
            // Recorre la lista hasta encontrar el empleado con el ID deseado
            while (p != null && p != inicio || inicio == p && !clienteBuscado)
            {
                if (p.Id == id)
                {
                    clienteBuscado = true;
                    break;
                }
                p = p.Cl_Sgte;
                if (p == inicio)
                {
                    break;
                }
            }
            // Si el empleado no se encuentra en la lista
            if (!clienteBuscado)
            {
                Console.WriteLine(" El cliente con el ID " + id + " no se encuentra en la lista");
            }
            else
            {
                Console.WriteLine(" Ingrese el telefono a actualizar:");
                string telf_new = Console.ReadLine();
                p.Telefono = telf_new;
                Console.WriteLine(" El telefono del empleado ha sido actualizado exitosamente");
            }
        }
        /*
        public void ActualizarTelefPorId(int id)
        {
            Cliente p = Lista_cliente;
            bool clienteBuscado = false;
            // Recorre la lista hasta encontrar el empleado con el ID deseado
            while (p != null)
            {
                if (p.Id == id)
                {
                    clienteBuscado = true;
                    break;
                }
                p = p.Cl_Sgte;
            }
            // Si el empleado no se encuentra en la lista
            if (!clienteBuscado)
            {
                Console.WriteLine(" El cliente con el ID " + id + " no se encuentra en la lista");
            }
            else
            {
                Console.WriteLine("Ingrese el telefono a actualizar:");
                string telf_new = Console.ReadLine();
                p.Telefono = telf_new;
                Console.WriteLine(" El telefono del empleado ha sido actualizado exitosamente");
            }
        }
        */

        public void ActualizarTelefonoPorId(int id, string newTelf)
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }

            //el objeto 'p' almacena la lista cliente
            Cliente p = Lista_cliente;
            //flag para saber si se ha encontrado o no el id
            bool encontrado = false;

            //Si el id que se busca se encuentra en el primer nodo...
            // Si el valor pasado por el parametro es el mismo que el de la propiedad Id
            if (p.Id == id)
            {
                encontrado = true;
                //Actualiza el telefono
                p.Telefono = newTelf;
            }

            // Si el primer nodo no es el que se busca, recorre la lista
            //Mientras que el p no apunte a la lista cliente y no lo haya encontrado
            while (p.Cl_Sgte != Lista_cliente && !encontrado)
            {
                //Avanza al siguiente nodo
                p = p.Cl_Sgte;
                // Si el valor pasado por el parametro es el mismo que el de la propiedad Id
                if (p.Id == id)
                {
                    encontrado = true;
                    //Actualiza el telefono
                    p.Telefono = newTelf;
                }
            }

            //Si lo encontró..
            if (encontrado)
            {
                Console.WriteLine(" Se actualizó el Telefono Correctamente!!\n");

                Console.WriteLine(" ╔══════════╦══════════════════╦═══════════════╦═════════════════════╦══════════════════════════╦══════════════╗");
                Console.WriteLine(" ║    ID    ║      Nombre      ║      DNI      ║   Fecha Nacimiento  ║          Correo          ║   Teléfono   ║");
                Console.WriteLine(" ╠══════════╬══════════════════╬═══════════════╬═════════════════════╬══════════════════════════╬══════════════╣");

                Console.WriteLine(" ║{0,10}║{1,18}║{2,15}║{3,21}║{4,26}║{5,14}║*", p.Id, p.Nombre, p.Dni, p.FechaNaci, p.Email, p.Telefono);
                Console.WriteLine(" ╚══════════╩══════════════════╩═══════════════╩═════════════════════╩══════════════════════════╩══════════════╝");
            }
            //Caso contrario
            else
            {
                Console.WriteLine(" El ID " + id + " no se encuentra en la lista");
            }
        }

        public void ImprimirListaCircular()
        {
            //Si la lista es diferente a null
            if (Lista_cliente != null)
            {
                //instanciamos un objeto p
                Cliente p = Lista_cliente;

                Console.WriteLine(" ╔══════════╦══════════════════╦═══════════════╦═════════════════════╦══════════════════════════╦══════════════╗");
                Console.WriteLine(" ║    ID    ║      Nombre      ║      DNI      ║   Fecha Nacimiento  ║          Correo          ║   Teléfono   ║");
                Console.WriteLine(" ╠══════════╬══════════════════╬═══════════════╬═════════════════════╬══════════════════════════╬══════════════╣");
                //Entra al bucle
                do
                {
                    Console.WriteLine(" ║{0,10}║{1,18}║{2,15}║{3,21}║{4,26}║{5,14}║", p.Id, p.Nombre, p.Dni, p.FechaNaci, p.Email, p.Telefono);
                    // Avanza al siguiente nodo
                    p = p.Cl_Sgte;
                    Console.WriteLine(" ╚══════════╩══════════════════╩═══════════════╩═════════════════════╩══════════════════════════╩══════════════╝");
                }
                //Mientras que 'p' sea distinto al primer elemento de la Lista_Cliente
                //va a seguir imprimiendo los nodos.
                while (p != Lista_cliente);
            }
            else
            {
                Console.WriteLine(" La lista está vacía.");
            }
        }

    }
}










/*
public void InsertarClienteInicio(string nombre, string dni, string f_nac, string email, string telefono)
{
    //Creamos el nodo cliente a ingresar
    Cliente q = new Cliente(nombre, dni, f_nac, email, telefono);
    if (Lista_cliente == null)
    {
        //La lista apuntará al objeto 'q' que estamos agregando.
        Lista_cliente = q;
    }else
    {
        //El valor ingresado a punta a la lista que ya se encontraba
        q.Cl_Sgte = Lista_cliente;
        //La lista apunta al 'q' para q este sea el nuevo valor inicial
        Lista_cliente = q;
    }
}
*/

/*
public void EliminarClienteInicio()
{
    if (VerificarListaVacia())
    {
        Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
        return;
    }else
    {
        Lista_cliente = Lista_cliente.Cl_Sgte;
        Console.WriteLine("\n CLIENTE INICIAL ELIMINADO!");
    }
}
*/

/*
        public void EliminarClienteFinal()
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }
            else 
            {
                //CONSIDERANDO QUE SOLO HAYA UN NODO EN LA LISTA
                //SI LA DIRECCION DEL NODO ES NULL
                if (Lista_cliente.Cl_Sgte == null)
                {
                    //LA LISTA APUNTARA A UNA DIRECCION NULA LO QUE CONLLEVA A LA ELIMINACION DEL UNICO NODO
                    Lista_cliente = Lista_cliente.Cl_Sgte;
                }
                else
                {
                    //EL 'p' NOS SERVIRA PARA RECORRER LA LISTA
                    Cliente p = Lista_cliente;
                    //El 'nd_ant' NOS SERVIRA PARA ALMACENAR LOS VALORES DEL 'p' MIENTRAS ESTE RECORRIENDO LA LISTA
                    Cliente nd_ant= new Cliente();
                    //MIENTRAS QUE LA DIRECCION DEL objeto 'p' SEA DISTINTO DE NULL 
                    while (p.Cl_Sgte != null)
                    {
                        //LOS DATOS DEL OBJETO 'p' SE ALMACENARÁN EN EL OBJETO 'nd_anterior'
                        nd_ant = p;
                        //Y EL OBJETO 'p' IRA AL SIGUIENTE NODO DE LA LISTA
                        p = p.Cl_Sgte;
                    }
                    //UNA VEZ HAYA LLEGADO AL ULTIMO NODO, COMO EL Objeto 'nd_anterior' guardo el penultimo nodo del objeto 'p',
                    //EL OBJETO 'nd_anterior' APUNTARA AL NULL YA QUE AHORA ESE SE CONVERTIRA EN EL ULTIMO NODO, PORQUE EL OTRO HA SIDO ELMINADO
                    nd_ant.Cl_Sgte = null;
                }
                Console.WriteLine("\n CLIENTE FINAL ELIMINADO!");
            }
        }
        */
/*
       public void EliminarClientePorID(int id)
       {
           if (VerificarListaVacia())
           {
               Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
               return;
           }
           bool encontrado = false;
           Cliente p = Lista_cliente;
           Cliente ant = new Cliente();

               while (p != null)
               {
                   //Buscar el valor del nodo en la lista mediante el dato pasado por parametro
                   //Es decir, Si el 'valor' pasado por parametro es igual al numero que se encuentra en la propiedad 'Id' del nodo
                   if (p.Id == id)
                   {
                       //Si el valor es encontrado en el primer elemento de la lista
                       if (p == Lista_cliente)
                       {
                           //La lista va a apuntar a la direccion del siguiente nodo y por lo tanto eliminará el nodo q se estaba buscando
                           Lista_cliente = Lista_cliente.Cl_Sgte;
                       }
                       else
                       {

                           //Si se trata de un elemento diferente del primero
                           //hacemos que el obj 'ant' de tipo nodo obtenga la direccion del siguiente nodo, para que el nodo con el valor encontrado se elimine
                           //y continue con el siguiente nodo.
                           ant.Cl_Sgte = p.Cl_Sgte;
                       }
                       Console.WriteLine(" Cliente con ID " + id + " Eliminado Correctamente!");
                       encontrado = true;
                       break;
               }
                   //Si todavia no encuentra el valor deseado, va a seguir estas instrucciones
                   //Guarda el elemento de 'p' en 'ant'
                   ant = p;
                   //Ir al siguiente elemento de la lista
                   p = p.Cl_Sgte;
               }
           if(!encontrado)
           {
               Console.WriteLine(" No se encontró ningún cliente con el ID " + id);
           }

       }
       */

/*
        public void BuscarClientePorDNI(string dni)
        {
            Cliente p = Lista_cliente;

            // Mientras 'p' no sea nulo y su DNI sea diferente al que se pasa por parámetro
            // Recorre la lista hasta encontrar el valor deseado
            while ((p != null) && (p.Dni != dni))
            {
                // Imprime el valor del DNI de 'p'
                Console.WriteLine(" " +p.Dni);
                // Avanza al siguiente nodo
                p = p.Cl_Sgte;
            }

            // Si 'p' es nulo, significa que el elemento buscado no se encuentra en la lista
            if (p == null)
            {
                Console.WriteLine(" El DNI " + dni + " no se encuentra en la lista");
            }
            else
            {
                Console.WriteLine(" *****************************************************************************************************************");
                Console.WriteLine(" *|    ID    |      Nombre      |      DNI      |   Fecha Nacimiento  |          Correo          |   Teléfono   |*");
                Console.WriteLine(" *****************************************************************************************************************");
                                    
                Console.WriteLine(" *|{0,10}|{1,18}|{2,15}|{3,21}|{4,26}|{5,14}|*", p.Id, p.Nombre, p.Dni, p.FechaNaci, p.Email, p.Telefono);
                Console.WriteLine(" *****************************************************************************************************************");
            }
        }
        */

/*
        public void ImprimirClientes()
        {
            Cliente p = Lista_cliente;
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }

            Console.WriteLine(" *****************************************************************************************************************");
            Console.WriteLine(" *|    ID    |      Nombre      |      DNI      |   Fecha Nacimiento  |          Correo          |   Teléfono   |*");
            Console.WriteLine(" *****************************************************************************************************************");

            // Recorrer la lista
            while (p != null)
            {
                Console.WriteLine(" *|{0,10}|{1,18}|{2,15}|{3,21}|{4,26}|{5,14}|*", p.Id, p.Nombre, p.Dni, p.FechaNaci, p.Email, p.Telefono);
                p = p.Cl_Sgte;
                Console.WriteLine(" *****************************************************************************************************************");
            }
        }
        */