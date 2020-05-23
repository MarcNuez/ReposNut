using GestorDeVacaciones.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestorDeVacaciones.Comandos
{
    public class CambiarTitulo : ICommand
    {

        MenuPrincipalViewModel viewModel;
        public CambiarTitulo(MenuPrincipalViewModel vm)
        {
            viewModel = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //el parametro que le pasamos por commandparameter viene hasta aqui se convierte en string
            //y llama al metodo de la modelovista que hemos pasado
            this.viewModel.cambiarTitulo(parameter as string);
            
        }
    }
}
