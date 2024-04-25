﻿using System;
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
            }else return false;
        }

        public void InsertarClienteInicio(int id, string nombre, string dni, string f_nac, string email, string telefono)
        {
            //Creamos el nodo cliente a ingresar
            Cliente q = new Cliente(id, nombre, dni, f_nac, email, telefono);
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


        public void InsertarClienteAlFinal(int id, string nombre, string dni, string f_nac , string email, string telefono)
        {
            //Creamos el objeto que se ingresará al final de la lista
            Cliente q = new Cliente(id,nombre,dni,f_nac,email,telefono);
            //Si la lista es Null
            if (Lista_cliente == null)
            {
                //La lista apuntará al objeto 'q' que estamos agregando.
                Lista_cliente = q;
            }
            //DE LO CONTRARIO, SI HAY ELEMENTOS EN LA LISTA
            else
            {
                //Esta variable 'p' se utilizará para recorrer la lista hasta encontrar el último nodo.
                //Por lo que a 'p' le asignamos todos los valores que se encuentra en la Lista_cliente
                Cliente p = Lista_cliente;
                //Mientras la propiedad Cl_Sgte sea distinto de null
                while (p.Cl_Sgte != null) 
                {
                    //Avanzará hasta el ultimo nodo
                    p = p.Cl_Sgte;
                }
                //UNA VEZ ENCONTRADO EL ULTIMO NODO
                //La propiedad Cl_Sgte apuntará al nuevo Cliente ingresado
                p.Cl_Sgte = q;
            }
        }

        public void EliminarClienteInicio()
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine("LA LISTA ESTÁ VACIA!!");
                return;
            }else
            {
                Lista_cliente = Lista_cliente.Cl_Sgte;
                Console.WriteLine("\nCLIENTE INICIAL ELIMINADO!");
            }
        }

        public void EliminarClienteFinal()
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine("LA LISTA ESTÁ VACIA!!");
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
                Console.WriteLine("\nCLIENTE FINAL ELIMINADO!");
            }
        }

        public void EliminarClientePorID(int id)
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine("LA LISTA ESTÁ VACIA!!");
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
                        Console.WriteLine("Cliente con ID " + id + " Eliminado Correctamente!");
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
                Console.WriteLine("No se encontró ningún cliente con el ID " + id);
            }
            
            
            
        }

        //Metodo para eliminar la lista
        public void EliminaTodaLaLista()
        {
            Lista_cliente = null;
            Console.WriteLine("LISTA ELIMINADA CORRECTAMENTE!");
        }

        public void BuscarClientePorDNI(string dni)
        {
            Cliente p = Lista_cliente;
            //Mientras el 'p' sea diferente de null y su valor sea distinto al que se esta pasando por parametro
            //Va a recorrer la lista hasta encontrar el valor deseado
            while ((p != null) && (p.Dni != dni))
            {
                //Imprime el valor q tiene el 'p'
                Console.WriteLine(p.Dni);
                //p apunta al siguiente nodo
                p = p.Cl_Sgte;
            }
            //SI YA RECORRIO TODA LA LISTA, entonces entra a este 'if'
            //Por lo tanto, cuando llega al ultimo elemento el p va a apuntar al null
            //Es por ello que si 'p' es null
            if (p == null)
                //el elemento buscado no se encuentra en la lista
                Console.WriteLine("El ID " + dni + " no se encuentra en la lista");
            //De lo contrario, si esta.
            else
            {
                Console.WriteLine("Datos del Cliente");
                Console.WriteLine("******************************");
                Console.Write("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}", p.Id, "-", p.Nombre, " -> ", p.Dni, " -> ", p.FechaNaci, " -> ", p.Email, " -> ", p.Telefono, " -> ");

            }
        }


        public void ImprimirClientes()
        {
            Cliente p = Lista_cliente;
            if(VerificarListaVacia())
            {
                Console.WriteLine("LA LISTA ESTÁ VACIA!!");
                return;
            }
            //Recorrer la lista
            Console.WriteLine("Lista Enlazada con Datos");
            Console.WriteLine("*************************");
            Console.Write("Lista -> ");
            while (p != null)
            {
                Console.Write("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}", p.Id, "-", p.Nombre, " -> ", p.Dni, " -> ", p.FechaNaci, " -> ", p.Email, " -> ", p.Telefono, " -> ");
                p = p.Cl_Sgte;
            }
            Console.WriteLine("NULL ");


        }

    }
}