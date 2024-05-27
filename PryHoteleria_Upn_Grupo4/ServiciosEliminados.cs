using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    public  class ServiciosEliminados
    {
        //Cola
        NodoServicioEliminado _inicio;

        public void Enqueue(NodoServicioEliminado unServicio)
        {
            if (_inicio == null)
            {
                _inicio = unServicio;
            }
            else
            {
                NodoServicioEliminado aux = BuscarUltimo(_inicio);
                aux.Siguiente = unServicio;
            }
        }

        private NodoServicioEliminado BuscarUltimo(NodoServicioEliminado unServicio)
        {
            if (unServicio.Siguiente == null)
            {
                return unServicio;
            }
            else 
            {
                return BuscarUltimo(unServicio.Siguiente);
            }
        }

        public void Dequeue()
        {
            _inicio = _inicio.Siguiente;
        }

        public NodoServicioEliminado Peek
        {
            get {  return _inicio; }
        }
    }
}
