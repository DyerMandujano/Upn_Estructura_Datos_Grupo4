using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Materiales
    {
        public static int contador = 1000;
        //ATRIBUTOS
        private int id;
        private string categoria;
        private string nombre_material;
        private int cantidad;
        private double costo;
        private Materiales mt_sgt;

        public Materiales()
        {

        }

        public Materiales(string nombre_material, int cantidad, double costo)
        {
            Id = contador++;
            //MATERIALES DEL PRODUCTO
            NombreMaterial = nombre_material;
            Cantidad = cantidad;
            Costo = costo;
            //Inicializar el enlace en null
            MT_Sgte = null;
        }

        //Propiedad para acceso al enlace siguiente
        public Materiales MT_Sgte
        {
            get { return mt_sgt; } //Leer el enlace siguiente
            set { mt_sgt = value; } //Escribir enlace siguiente
        }

        //GETTERS Y SETTERS DE LAS PROPIEDADES
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NombreMaterial
        {
            get { return nombre_material; }
            set { nombre_material = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }
    }
}
