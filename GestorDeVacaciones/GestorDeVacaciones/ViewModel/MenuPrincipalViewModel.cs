using GestorDeVacaciones.Comandos;
using GestorDeVacaciones.Core;
using GestorDeVacaciones.Model.Cache;
using GestorDeVacaciones.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace GestorDeVacaciones.ViewModel
{
    public class MenuPrincipalViewModel : BaseViewModel
    {



        public string Nombre { get; set; } = UserLoginCache.Nombre + " " + UserLoginCache.Apellidos;
        public string Rol { get; set; } = UserLoginCache.Rol;
        public string UrlImage { get; set; } = UserLoginCache.UrlImage;
        public ICommand AbrirVentanaCommand { get; set; }
       // public CambiarTitulo CambiarTitulo { get; set; }
        public BaseViewModel VistaSeleccionada
        {
            get { return _vistaSeleccionada; }
            set
            {
                _vistaSeleccionada = value;

                OnPropertyChanged(nameof(VistaSeleccionada));
            }

        }
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public string TituloNombre
        {
            get { return _titulonombre; }
            set
            {
                _titulonombre = value;
                OnPropertyChanged(nameof(TituloNombre));
            }
        }

        public ICommand VentanaPerfiles
        {
            get
            {
                return _ventanaPerfiles ?? (_ventanaPerfiles = new RelayCommand(
                   abrirVentanaPerfiles));
            }
        }


        public DispatcherTimer _timer;

        private BaseViewModel _vistaSeleccionada;
        private string _time;
        private string _titulonombre;
        private ICommand _ventanaPerfiles;

        //contructor
        public MenuPrincipalViewModel()
        {


            //tiempo de la parte inferior de la pantalla
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) =>
            {
                Time = DateTime.Now.ToString();
            };
            _timer.Start();



            //metodos personalizados
            AbrirVentanaCommand = new AbrirVentanaCommand(this);
            //CambiarTitulo = new CambiarTitulo(this);


        }


        private static void abrirVentanaPerfiles()
        {
            EditarPerfilView epv = new EditarPerfilView();
            epv.Show();

        }

        public void cambiarTitulo(string titulo)
        {
            TituloNombre = titulo;

        }















    }
}
