using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Empleados
    {
        public static int contador = 10000;
        private int id;
        private string nom;
        private string apell;
        private string dni;
        private string correo;
        private string telefono;
        private string direccion;
        private string sueldo;
        private Empleados emple_sgt;

        public Empleados()
        {

        }
        public Empleados(string nom, string apell, string dni, string correo, string telefono, string direccion, string sueldo)
        {

            Id = contador++;

            Nom = nom;
            Apell = apell;
            Dni = dni;
            Correo = correo;
            Telefono = telefono;
            Direccion = direccion;
            Sueldo = sueldo;

            emple_sgt = null;
        }
        public Empleados Emple_Sgt
        {
            get { return emple_sgt; }
            set { emple_sgt = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Apell
        {
            get { return apell; }
            set { apell = value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }
    }
}
