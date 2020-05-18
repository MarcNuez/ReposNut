using System;
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
    /// Lógica de interacción para HorariosView.xaml
    /// </summary>
    public partial class HorariosView : UserControl
    {
        public static string totalHoras;


        public HorariosView()
        {
            InitializeComponent();
        }


        #region entradas/salidas
        private void txt_entrada1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txt_entrada1.Text += stringAHora(txt_entrada1.Text);
        }

        private void txt_salida1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txt_salida1.Text += stringAHora(txt_salida1.Text);
        }

        private void txt_entrada2_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txt_entrada2.Text += stringAHora(txt_entrada2.Text);
        }

        private void txt_salida2_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txt_salida2.Text += stringAHora(txt_salida2.Text);
        }
        #endregion
        #region Anadir horario
        private void txt_nombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #region Dias semana
        private void cb_lunes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_martes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_miercoles_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_jueves_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_viernes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_sabado_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_domingo_Checked(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        private void btn_anadirHorario_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region borrar horario
        private void cmb_horario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_eliminarHorario_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region metodos
        private static string stringAHora(string hora)
        {
            if (hora.Length == 2) return hora + ":";

            return hora;
        }
        private void mostrarHorarios()
        {

        }
        #endregion
    }
}
