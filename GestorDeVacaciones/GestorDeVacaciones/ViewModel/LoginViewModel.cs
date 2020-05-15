using GestorDeVacaciones.Core;
using GestorDeVacaciones.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestorDeVacaciones.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {










        private ICommand _loguear;
        public ICommand Loguear
        {
            get
            {
                if (_loguear == null)
                    _loguear = new RelayCommand(new Action(loginComando));
                return _loguear;
            }
        }


        private void loginComando()
        {

            var validLogin = true;
            if (validLogin)
            {
                MenuPrincipalView mp = new MenuPrincipalView();
                mp.Show();
            }
            else
            {

            }

           
            
        }









    }
}
