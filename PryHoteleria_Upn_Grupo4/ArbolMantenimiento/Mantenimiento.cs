using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4.ArbolMantenimiento
{
    class Mantenimiento
    {
        //atributo statico
        public static int contador = 1000;
        //atributos privados
        private int idMantenimiento;
        private int idHabitacion;
        private int idEmpleado;
        private string fechaMante;
        private string tipoMante;
        private string descripMante;
        //Nivel que tiene el nodo en el Arbol
        private int nivel;

        //Constructor sin parametros
        public Mantenimiento() { }

        //Constructor con parametros
        public Mantenimiento(int idHabitacion, int idEmpleado, string fechaMante, string tipoMante, string descripMante)
        {
            Id = contador++;
            IdHabit = idHabitacion;
            IdEmple = idEmpleado;
            Fecha_Mant = fechaMante;
            Tipo_Mant = tipoMante;
            Descrip_Mant = descripMante;
            Nivel = 0;
        }

        //GETTERS Y SETTERS DE LAS PROPIEDADES
        public int Id
        {
            get { return idMantenimiento; }
            set { idMantenimiento = value; }
        }

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        public int IdHabit
        {
            get { return idHabitacion; }
            set { idHabitacion = value; }
        }

        public int IdEmple
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public string Fecha_Mant
        {
            get { return fechaMante; }
            set { fechaMante = value; }
        }

        public string Tipo_Mant
        {
            get { return tipoMante; }
            set { tipoMante = value; }
        }
        public string Descrip_Mant
        {
            get { return descripMante; }
            set { descripMante = value; }
        }

    }
}
