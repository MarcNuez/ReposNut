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
            if (parameter.ToString() == "VacacionesView")
            {
                viewModel.VistaSeleccionada = new VacacionesViewModel();
            }
            else if(parameter.ToString() == "AusenciasView")
            {
                viewModel.VistaSeleccionada = new AusenciasViewModel();
            }
        }
    }
}
