using GestorDeVacaciones.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestorDeVacaciones.ViewModel
{
    public class AusenciasViewModel : BaseViewModel
    {
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }



        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        private string _diasAusentes;

        public string DiasAusentes
        {
            get { return _diasAusentes; }
            set { _diasAusentes = value;
                
                OnPropertyChanged("DiasAusentes");
            }
        }

      

        private ICommand _selectDate;
        public ICommand SeleccionarFecha
        {
            get
            {
                if (_selectDate == null)
                    _selectDate = new RelayCommand(new Action(calcular));
                return _selectDate;
            }
        }

   

        private void calcular()
        {
            if (_startDate< DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("La fecha de inicio no puede ser menor que la fecha de hoy");
                return;
            }

            if (_endDate<_startDate)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha de inicio");
            }
            else
            {
                var dias = (int)(_endDate - _startDate).TotalDays + 1;
                DiasAusentes = dias > 1 ? dias.ToString() + " Dias" : dias.ToString() + " Dia";
            }


            
        }

    }
}
