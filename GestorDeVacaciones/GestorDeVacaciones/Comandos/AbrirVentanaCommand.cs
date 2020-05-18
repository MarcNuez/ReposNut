using GestorDeVacaciones.View;
using GestorDeVacaciones.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestorDeVacaciones.Comandos
{
    public class AbrirVentanaCommand : ICommand
    {

        private MenuPrincipalViewModel viewModel;

        public AbrirVentanaCommand(MenuPrincipalViewModel viewModel)
        {
            this.viewModel = viewModel;
        }





        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString().Equals("VacacionesView"))
            {
                viewModel.VistaSeleccionada = new VacacionesViewModel();
            }
            else if(parameter.ToString().Equals("AusenciasView"))
            {
                viewModel.VistaSeleccionada = new AusenciasViewModel();
            }else if (parameter.ToString().Equals("GestorAdminView"))
            {
               // viewModel.VistaSeleccionada = new ();

            }
            else if (parameter.ToString().Equals("FicharView"))
            {
                viewModel.VistaSeleccionada = new FicharViewModel();

            }
            else if (parameter.ToString().Equals("FichajesView"))
            {
                viewModel.VistaSeleccionada = new FichajesViewModel();

            }
            else if (parameter.ToString().Equals("HorariosView"))
            {
                viewModel.VistaSeleccionada = new HorariosViewModel();

            }
        }
    }
}
