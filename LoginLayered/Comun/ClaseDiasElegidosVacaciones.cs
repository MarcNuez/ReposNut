using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Domain

{
    public class ClaseDiasElegidosVacaciones:IComparable<ClaseDiasElegidosVacaciones>
    {
        private int dia;
        private int mes;
        private int año;

     
        public ClaseDiasElegidosVacaciones(int dia, int mes, int año)
        {
            this.dia = dia;
            this.mes = mes;
            this.año = año;


        }

        public int obtenerDia()
        {
            return dia;
        }

        public int obtenerMes()
        {
            return mes;
        }
        public int obtenerAño()
        {
            return año;
        }
        public DateTime obtenerFechaFormato()
        {
            return new DateTime(año,mes,dia);
        }

        public override string ToString()
        {
            return obtenerDia().ToString() + "/" +obtenerMes().ToString() + "/" + obtenerAño().ToString() + " , ";
            ;
        }

        public int CompareTo(ClaseDiasElegidosVacaciones other)
        {
            return this.obtenerFechaFormato().CompareTo(other.obtenerFechaFormato());
        }
    }
}
