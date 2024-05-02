using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class ListaMateriales

    {
        //Definimos el nodo de tipo Material
        private Materiales lista_mat;

        //Propiedad Lista_cliente para acceder a la lista_mat
        public Materiales Lista_material
        {
            get { return lista_mat; }
            set { lista_mat = value; }
        }

        //Definimos el constructor e inicializamos la listaclientes
        public ListaMateriales()
        {
            //la propiedad 'Lista_mateiral' será null
            Lista_material = null;
        }

        //Metodo para determinar si la lista esta vacia
        public bool VerificarListaVacia()
        {
            if (Lista_material == null)
            {
                return true;
            }
            else return false;
        }

        public void InsertarMaterialInicio(string categoria, string nombre_material, int cantidad, double costo)
        {
            //Creamos el nodo material a ingresar
            Materiales q = new Materiales(categoria, nombre_material, cantidad, costo);
            if (Lista_material == null)
            {
                //La lista apuntará al objeto 'q' que estamos agregando.
                Lista_material = q;
            }
            else
            {
                //El valor ingresado a punta a la lista que ya se encontraba
                q.MT_Sgte = Lista_material;
                //La lista apunta al 'q' para q este sea el nuevo valor inicial
                Lista_material = q;
            }
        }


        public void InsertarMaterialAlFinal(string categoria, string nombre_material, int cantidad, double costo)
        {
            //Creamos el objeto que se ingresará al final de la lista
            Materiales q = new Materiales(categoria, nombre_material, cantidad, costo);
            //Si la lista es Null
            if (Lista_material == null)
            {
                //La lista apuntará al objeto 'q' que estamos agregando.
                Lista_material = q;
            }
            //DE LO CONTRARIO, SI HAY ELEMENTOS EN LA LISTA
            else
            {
                //Esta variable 'p' se utilizará para recorrer la lista hasta encontrar el último nodo.
                //Por lo que a 'p' le asignamos todos los valores que se encuentra en la Lista_material
                Materiales p = Lista_material;
                //Mientras la propiedad Cl_Sgte sea distinto de null
                while (p.MT_Sgte != null)
                {
                    //Avanzará hasta el ultimo nodo
                    p = p.MT_Sgte;
                }
                //UNA VEZ ENCONTRADO EL ULTIMO NODO
                //La propiedad Cl_Sgte apuntará al nuevo Cliente ingresado
                p.MT_Sgte = q;
            }
        }

        public void EliminarMaterialInicio()
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }
            else
                Lista_material = Lista_material.MT_Sgte;
            Console.WriteLine("\n MATERIAL INICIAL ELIMINADO!");
        }


        public void EliminarMaterialFinal()
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
                if (Lista_material.MT_Sgte == null)
                {
                    //LA LISTA APUNTARA A UNA DIRECCION NULA LO QUE CONLLEVA A LA ELIMINACION DEL UNICO NODO
                    Lista_material = Lista_material.MT_Sgte;
                }
                else
                {
                    //EL 'p' NOS SERVIRA PARA RECORRER LA LISTA
                    Materiales p = Lista_material;
                    //El 'nd_ant' NOS SERVIRA PARA ALMACENAR LOS VALORES DEL 'p' MIENTRAS ESTE RECORRIENDO LA LISTA
                    Materiales nd_ant = new Materiales();
                    //MIENTRAS QUE LA DIRECCION DEL objeto 'p' SEA DISTINTO DE NULL 
                    while (p.MT_Sgte != null)
                    {
                        //LOS DATOS DEL OBJETO 'p' SE ALMACENARÁN EN EL OBJETO 'nd_anterior'
                        nd_ant = p;
                        //Y EL OBJETO 'p' IRA AL SIGUIENTE NODO DE LA LISTA
                        p = p.MT_Sgte;
                    }
                    //UNA VEZ HAYA LLEGADO AL ULTIMO NODO, COMO EL Objeto 'nd_anterior' guardo el penultimo nodo del objeto 'p',
                    //EL OBJETO 'nd_anterior' APUNTARA AL NULL YA QUE AHORA ESE SE CONVERTIRA EN EL ULTIMO NODO, PORQUE EL OTRO HA SIDO ELMINADO
                    nd_ant.MT_Sgte = null;
                }
                Console.WriteLine("\n MATERIAL FINAL ELIMINADO!");
            }
        }

        public void EliminarMaterialPorID(int id)
        {
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }
            bool encontrado = false;
            Materiales p = Lista_material;
            Materiales ant = new Materiales();

            while (p != null)
            {
                //Buscar el valor del nodo en la lista mediante el dato pasado por parametro
                //Es decir, Si el 'valor' pasado por parametro es igual al numero que se encuentra en la propiedad 'Id' del nodo
                if (p.Id == id)
                {
                    //Si el valor es encontrado en el primer elemento de la lista
                    if (p == Lista_material)
                    {
                        //La lista va a apuntar a la direccion del siguiente nodo y por lo tanto eliminará el nodo q se estaba buscando
                        Lista_material = Lista_material.MT_Sgte;
                    }
                    else
                    {

                        //Si se trata de un elemento diferente del primero
                        //hacemos que el obj 'ant' de tipo nodo obtenga la direccion del siguiente nodo, para que el nodo con el valor encontrado se elimine
                        //y continue con el siguiente nodo.
                        ant.MT_Sgte = p.MT_Sgte;
                    }
                    Console.WriteLine(" Material con ID " + id + " Eliminado Correctamente!");
                    encontrado = true;
                    break;
                }
                //Si todavia no encuentra el valor deseado, va a seguir estas instrucciones
                //Guarda el elemento de 'p' en 'ant'
                ant = p;
                //Ir al siguiente elemento de la lista
                p = p.MT_Sgte;
            }
            if (!encontrado)
            {
                Console.WriteLine(" No se encontró ningún material con el ID " + id);
            }



        }

        //Metodo para eliminar la lista
        public void EliminaTodaLaLista()
        {
            Lista_material = null;
            Console.WriteLine(" LISTA ELIMINADA CORRECTAMENTE!");
        }

        public void BuscarMateriales(string nombre_material)
        {
            Materiales p = Lista_material;
            //Mientras el 'p' sea diferente de null y su valor sea distinto al que se esta pasando por parametro
            //Va a recorrer la lista hasta encontrar el valor deseado
            while ((p != null) && (p.NombreMaterial != nombre_material))
            {
                //Imprime el valor q tiene el 'p'
                Console.WriteLine(" " + p.Categorias);
                //p apunta al siguiente nodo
                p = p.MT_Sgte;
            }
            //SI YA RECORRIO TODA LA LISTA, entonces entra a este 'if'
            //Por lo tanto, cuando llega al ultimo elemento el p va a apuntar al null
            //Es por ello que si 'p' es null
            if (p == null)
                //el elemento buscado no se encuentra en la lista
                Console.WriteLine(" El material " + nombre_material + " no se encuentra en la lista");
            //De lo contrario, si esta.
            else
            {
                Console.WriteLine(" Datos del Material");
                
                Console.WriteLine(" **************************************************************************************************");
                Console.WriteLine(" *|     ID     |     Categorias     |     Nombre Material     |     Cantidad     |     Costo     |*");
                Console.WriteLine(" **************************************************************************************************");
                Console.WriteLine(" *|{0,12}|{1,25}|{2,18}|{3,15}|{4,20}|*", p.Id, p.Categorias, p.NombreMaterial, p.Cantidad, p.Costo);
                Console.WriteLine(" *************************************************************************************************");

            }
        }

        public void ImprimirMaterial()
        {
            Materiales p = Lista_material;
            if (VerificarListaVacia())
            {
                Console.WriteLine(" LA LISTA ESTÁ VACIA!!");
                return;
            }

            Console.WriteLine(" **************************************************************************************************");
            Console.WriteLine(" |     ID     |     Categorias     |     Nombre Material     |     Cantidad     |     Costo     |");
            Console.WriteLine(" **************************************************************************************************");

            // Recorrer la lista
            while (p != null)
            {
                Console.WriteLine(" |{0,12}|{1,25}|{2,18}|{3,15}|{4,20}|", p.Id, p.Categorias, p.NombreMaterial, p.Cantidad, p.Costo);
                p = p.MT_Sgte;
                Console.WriteLine(" **************************************************************************************************");
            }
        }

    }
}

