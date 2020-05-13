﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model
{
    public class DiasElegidosModel 
    {

        public int Dia { get; set; }
        public int Mes { get; set; }

        public int Año { get; set; }

        public string diaFormato { get {

                return Dia.ToString() + "/" + Mes.ToString() + "/" + Año.ToString(); } }


        public DiasElegidosModel(int dia,int mes, int año)
        {
            Dia = dia;
            Mes = mes;
            Año = año;
        }

        

    }
}
