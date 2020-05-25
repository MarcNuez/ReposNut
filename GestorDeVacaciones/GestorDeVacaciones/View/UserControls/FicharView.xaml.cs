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
        public FicharView()
        {
            InitializeComponent();
            inicializarRegistro();
        }

        private void btn_entrar_Click(object sender, RoutedEventArgs e)
        {
            registrarEntrada();
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            registrarSalida();
        }

        /// <summary> Modifica los colores al registrar una entrada</summary>
        private void registrarEntrada()
        {
            btn_entrar.IsEnabled = false;
            btn_salir.IsEnabled = true;
            btn_entrar.Background = Brushes.Red;
            btn_salir.Background = Brushes.LightGreen;
        }
        /// <summary>Modifica los colores al registrar unasalida</summary>
        private void registrarSalida()
        {

            if (fichaje.salida1.TotalSeconds == 0)
            {
                btn_entrar.IsEnabled = true;
                btn_salir.IsEnabled = false;
                btn_entrar.Background = Brushes.LightGreen;
                btn_salir.Background = Brushes.Red;

            }
            else if (fichaje.salida2.TotalSeconds == 0 && horario.jornadaCompleta)
            {
                btn_entrar.IsEnabled = false;
                btn_salir.IsEnabled = false;
                btn_entrar.Background = Brushes.Red;
                btn_salir.Background = Brushes.Red;
            }
        }
        /// <summary>  Inicializa el registro con las horas a null, en el caso que no este inicializado</summary>
        private void inicializarRegistro()
        {
            using (var db = new ContextoBBDD())
            {
                fichaje = db.Fichar.Where(x => x.UserID == UserLoginCache.Id && x.dia == DateTime.Today).FirstOrDefault();
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
                    btn_salir.IsEnabled = false;
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
                    else if (fichaje.salida2.TotalMilliseconds == 0)
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

        }
       
        

       

    }
}
