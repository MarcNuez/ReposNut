using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.ViewModel
{
    public class FicharViewModel : BaseViewModel
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
            set
            {
                _diasAusentes = value;

                OnPropertyChanged("DiasAusentes");
            }
        }




    }
}
