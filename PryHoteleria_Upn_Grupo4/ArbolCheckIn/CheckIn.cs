using PryHoteleria_Upn_Grupo4.ArbolMantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    class CheckIn
    {
        private string nombre_cli;
        private string dni_cli;
        private int id_habi;
        private int num_per;
        private string fecha_checkin;
        private string tipo_serv_adic;
        private string nom_serv;
        //Nivel que tiene el nodo en el Arbol
        private int nivel;

        public CheckIn()
        { }

        public CheckIn(string nom_cli, string dni, int idhabi, int num_p, string fecha_checkin, string tipo_serv, string nom_serv)
        {
            Nombre_Cli = nom_cli;
            Dni_Cli = dni;
            Id_Habi = idhabi;
            Num_Per = num_p;
            Fecha_CheckIn = fecha_checkin;
            Tipo_Serv_Adic = tipo_serv;
            Nom_Serv = nom_serv;
            Nivel = 0;
        }

        public string Nombre_Cli
        {
            get { return nombre_cli; }
            set { nombre_cli = value; }
        }
        public string Dni_Cli
        {
            get { return dni_cli; }
            set { dni_cli = value; }
        }
        public int Id_Habi
        {
            get { return id_habi; }
            set { id_habi = value; }
        }
        public int Num_Per
        {
            get { return num_per; }
            set { num_per = value; }
        }
        public string Fecha_CheckIn
        {
            get { return fecha_checkin; }
            set { fecha_checkin = value; }
        }
        public string Tipo_Serv_Adic
        {
            get { return tipo_serv_adic; }
            set { tipo_serv_adic = value; }
        }
        public string Nom_Serv
        {
            get { return nom_serv; }
            set { nom_serv = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
    }
}
