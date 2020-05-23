using GestorDeVacaciones.Data;
using GestorDeVacaciones.Migrations;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorDeVacaciones.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para FicharView.xaml
    /// </summary>
    public partial class FicharView : UserControl
    {
        FicharModel fichaje;
        HorariosModel horario;
       ContextoBBDD db = new ContextoBBDD();
        public FicharView()
        {
            InitializeComponent();
            inicializarRegistro();
            mostrarUltimosDiezRegistros();
            comprobarRegistroAnterior();
        }

        private void btn_entrar_Click(object sender, RoutedEventArgs e)
        {
            registrarEntrada();
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            registrarSalida();
        }

        /// <summary>  Si entrada1 no tiene registro, rellenara esta; sino rellenara la entrada2</summary>
        private void registrarEntrada()
        {
            
            if (fichaje.entrada1.TotalMilliseconds == 0)
            {
                fichaje.entrada1 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);
                if (fichaje.entrada1.TotalSeconds > horario.entrada1.TotalSeconds)
                {
                    fichaje.warning = 2;
                }
            }
            else if (fichaje.entrada2.TotalSeconds == 0)
            {
                fichaje.entrada2 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);
                if (fichaje.entrada2.TotalSeconds > horario.entrada2.TotalSeconds)
                {
                    fichaje.warning = 2;
                }
            }
            db.SaveChanges();

            btn_entrar.IsEnabled = false;
            btn_salir.IsEnabled = true;
            btn_entrar.Background = Brushes.Red;
            btn_salir.Background = Brushes.LightGreen;
        }
        /// <summary>Si salida 1 no tiene registro, rellenara esta; sino rellenara la salida 2</summary>
        private void registrarSalida()
        {
           
            if (fichaje.salida1.TotalSeconds == 0)
            {
                fichaje.salida1 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);
                btn_entrar.IsEnabled = true;
                btn_salir.IsEnabled = false;
                btn_entrar.Background = Brushes.LightGreen;
                btn_salir.Background = Brushes.Red;

            }
            else if (fichaje.salida2.TotalSeconds == 0 && horario.jornadaCompleta)
            {
                fichaje.salida2 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);
                btn_entrar.IsEnabled = false;
                btn_salir.IsEnabled = false;
                btn_entrar.Background = Brushes.Red;
                btn_salir.Background = Brushes.Red;
            }
            db.SaveChanges();
        }
        /// <summary>  Inicializa el registro con las horas a null, en el caso que no este inicializado</summary>
        private void inicializarRegistro()
        {
            fichaje = db.Fichar.Where(x => x.UserID == UserLoginCache.Id && x.dia==DateTime.Today).FirstOrDefault();
            if (fichaje == null)
            {
                fichaje = new FicharModel();
                fichaje.UserID = UserLoginCache.Id;
                fichaje.horarioID = 1;
                fichaje.dia = DateTime.Today;
                fichaje.warning = 1;
                db.Fichar.Add(fichaje);
                db.SaveChanges();
                btn_entrar.IsEnabled = true;
                btn_salir.IsEnabled =false;
                btn_entrar.Background = Brushes.LightGreen;
                btn_salir.Background = Brushes.Red;
            }
            else
            {
                if (fichaje.entrada1.TotalMilliseconds == 0)
                {
                    btn_entrar.IsEnabled = true;
                    btn_salir.IsEnabled = false;
                    btn_entrar.Background = Brushes.LightGreen;
                    btn_salir.Background = Brushes.Red;
                }
                else if (fichaje.salida1.TotalMilliseconds == 0)
                {
                    btn_entrar.IsEnabled = true;
                    btn_salir.IsEnabled = false;
                    btn_entrar.Background = Brushes.LightGreen;
                    btn_salir.Background = Brushes.Red;
                }
                else if (fichaje.entrada2.TotalMilliseconds == 0)
                {
                    btn_entrar.IsEnabled = true;
                    btn_salir.IsEnabled = false;
                    btn_entrar.Background = Brushes.LightGreen;
                    btn_salir.Background = Brushes.Red;
                }
                else if(fichaje.salida2.TotalMilliseconds == 0)
                {
                    btn_entrar.IsEnabled = true;
                    btn_salir.IsEnabled = false;
                    btn_entrar.Background = Brushes.LightGreen;
                    btn_salir.Background = Brushes.Red;
                }
                else
                {
                    btn_entrar.IsEnabled = false;
                    btn_salir.IsEnabled = false;
                    btn_entrar.Background = Brushes.Red;
                    btn_salir.Background = Brushes.Red;
                }
            }
            horario = db.Horarios.Where(x => x.ID == fichaje.horarioID).FirstOrDefault();

        }
        /// <summary>Mostrarlos registros de los 10 ultimos dias</summary>
        private void mostrarUltimosDiezRegistros()
        {
            DateTime d = DateTime.Today.AddDays(-10);
            
            gdv_marcajes.DataContext = db.Fichar.Where(x => x.dia > d && x.UserID==UserLoginCache.Id).ToArray();


        }

        private void comprobarRegistroAnterior()
        {
            FicharModel fichajeAyer = db.Fichar.Where(x => x.UserID == UserLoginCache.Id && x.dia == DateTime.Today.AddDays(-1)).FirstOrDefault();
            if ((fichajeAyer.salida1 - fichajeAyer.entrada1) + (fichajeAyer.salida2 - fichajeAyer.entrada2) > new TimeSpan(8, 0, 0)) fichajeAyer.warning = 3;
            else if (fichajeAyer.entrada1.TotalMilliseconds == 0 || fichajeAyer.salida1.TotalMilliseconds == 0 || fichajeAyer.entrada2.TotalMilliseconds == 0 || fichajeAyer.salida2.TotalMilliseconds == 0) 
                fichajeAyer.warning =4;
            db.SaveChanges();
        }

    }
}
