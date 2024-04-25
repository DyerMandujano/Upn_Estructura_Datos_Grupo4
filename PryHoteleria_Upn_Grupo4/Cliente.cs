using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Cliente
    {
        //ATRIBUTOS
        private int id;
        private string nombre;
        private string dni;
        private string fecha_Naci;
        private string email;
        private string telefono;
        private Cliente cl_sgt;

        //Constructor SIN PARAMETROS
        public Cliente()
        {

        }

        //CONSTRUCTOR CON PARAMETROS
        public Cliente(int ID, string nom, string DNI, string fec_Naci, string correo, string telef)
        {
    //PROPIEDADES - ARGUMENTOS
            Id        = ID;
            Nombre    = nom;
            Dni       = DNI;
            FechaNaci = fec_Naci;
            Email     = correo;
            Telefono  = telef;
            //Inicializar el enlace en null
            Cl_Sgte = null;
        }

        //Propiedad para acceso al enlace siguiente
        public Cliente Cl_Sgte
        {
            get { return cl_sgt; } //Leer el enlace siguiente
            set { cl_sgt = value; } //Escribir enlace siguiente
        }

        //GETTERS Y SETTERS DE LAS PROPIEDADES
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string FechaNaci
        {
            get { return fecha_Naci; }
            set { fecha_Naci = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}
