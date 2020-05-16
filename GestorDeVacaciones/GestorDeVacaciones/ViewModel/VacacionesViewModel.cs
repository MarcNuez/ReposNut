using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model.Cache;
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

			using (var db = new ContextoBBDD())
			{
				var diasquequedan = db.Usuarios.Where(x => x.Id == UserLoginCache.Id).Select(d => d.DiasPendientes.DiasQueMeQuedan).FirstOrDefault();
				_diasQueQuedan = diasquequedan;
			}

		}



	}
}
