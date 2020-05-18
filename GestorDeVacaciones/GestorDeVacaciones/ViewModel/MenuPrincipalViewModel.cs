using GestorDeVacaciones.Comandos;
using GestorDeVacaciones.Model.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestorDeVacaciones.ViewModel
{
    public class MenuPrincipalViewModel: BaseViewModel
    {
        private BaseViewModel _vistaSeleccionada;


        public string Nombre { get; set; } = UserLoginCache.Nombre +" " + UserLoginCache.Apellidos;
   
        public string Rol { get; set; } = UserLoginCache.Rol;


        public string UrlImage { get; set; } = UserLoginCache.UrlImage;





        public BaseViewModel VistaSeleccionada
        {
            get { return _vistaSeleccionada; }
            set { _vistaSeleccionada = value;
                OnPropertyChanged(nameof(VistaSeleccionada));
            }
            
        }
        
        public ICommand AbrirVentanaCommand { get; set; }

        public MenuPrincipalViewModel()
        {
            AbrirVentanaCommand = new AbrirVentanaCommand(this);
        }


    }
}
