using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    class Servicios
    {
        //Pila
        NodoServicio _tope;
        //Metodo para agregar elementos a la pila
        public void push( NodoServicio unServicio)
        {
            
            ////Crear el nuevo NodoServicio de la pila
            
            if (_tope == null)            {
                _tope = unServicio;
            }
            else
            {
                NodoServicio auxiliar = _tope;
                _tope = unServicio;
                _tope.Siguiente = auxiliar;
            }
        }
        //Metodo para sacar un elemento de la pila
        public NodoServicioEliminado pop()
        {
            NodoServicio _eliminar = _tope;
            if (_tope != null)
            {

                _tope = _tope.Siguiente;
            }
            NodoServicioEliminado _se = new NodoServicioEliminado
            {
                IdServicio = _eliminar.IdServicio,
                Nombre_servi = _eliminar.Nombre_servi,
                Descripcion = _eliminar.Descripcion,
                Horario = _eliminar.Horario,
                Precio = _eliminar.Precio
            };
            return _se;

        }
        public NodoServicio Tope()
        { return _tope; }
    }
}
