using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.ViewModel
{
    public class VacacionesViewModel : BaseViewModel
    {
		private int _diasQueQuedan;

		public int DiasQueQuedan
		{
			get { return _diasQueQuedan; }
			set { _diasQueQuedan = value; OnPropertyChanged("DiasQueQuedan"); }
		}

		public VacacionesViewModel()
		{
			_diasQueQuedan = 30;
		}



	}
}
