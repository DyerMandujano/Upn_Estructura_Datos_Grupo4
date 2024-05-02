﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Empleados
    {
        public static int contador = 1000;
        private int id;
        private string nom;
        private string dni;
        private string correo;
        private string telefono;
        private string direccion;
        private string cargo;
        private string sueldo;
        private Empleados emple_sgt;
        private Empleados emple_ant;

        public Empleados()
        {

        }
        public Empleados(string nom, string dni, string correo, string telefono, string direccion, string cargo,string sueldo)
        {

            Id = contador++;

            Nom = nom;
            Dni = dni;
            Correo = correo;
            Telefono = telefono;
            Direccion = direccion;
            Cargo = cargo;
            Sueldo = sueldo;
            emple_sgt = null;
            emple_ant = null;
        }
        public Empleados Emple_Ant
        {
            get { return emple_ant; }
            set { emple_ant = value; }
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
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
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
