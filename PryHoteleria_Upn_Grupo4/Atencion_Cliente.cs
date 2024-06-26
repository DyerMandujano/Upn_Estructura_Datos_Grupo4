﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryHoteleria_Upn_Grupo4
{
    internal class Atencion_Cliente
    {
        private int idAtencion;
        private int idCliente;
        private int idHabitacion;
        private string fechasolicitud;
        private string descripcion;
        private int prioridad;
        private int descripcion_prioridad;
        private Atencion_Cliente sgte;

        public Atencion_Cliente()
        {

        }
        public Atencion_Cliente(int idAten,int idClie, int idHab,string fecSoli,string descrip,int priori,int descri_priori)
        {
            IdAtencion = idAten;
            IdCliente = idClie;
            IdHabitacion = idHab;
            FechaSolicitud = fecSoli;
            Descripcion = descrip;
            Prioridad = priori;
            Descripcion_Prioridad = descri_priori;
            Sgte = null;
        }
        public Atencion_Cliente Sgte
        {
            get { return sgte; } 
            set { sgte = value; } 
        }
        public int IdAtencion
        {
            get { return idAtencion; }
            set { idAtencion = value; }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public int IdHabitacion
        {
            get { return idHabitacion; }
            set { idHabitacion = value; }
        }

        public string FechaSolicitud
        {
            get { return fechasolicitud; }
            set { fechasolicitud = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Prioridad 
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        public int Descripcion_Prioridad
        {
            get { return descripcion_prioridad; }
            set { descripcion_prioridad = value; }
        }
    }
}

    

