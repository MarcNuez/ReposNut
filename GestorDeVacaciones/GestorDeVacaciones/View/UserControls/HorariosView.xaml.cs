using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.Cache;
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
        ContextoBBDD db = new ContextoBBDD();

        public HorariosView()
        {
            InitializeComponent();
           
        }


       
        #region Anadir horario
       
        private void btn_anadirHorario_Click(object sender, RoutedEventArgs e)
        {
                HorariosModel h = new HorariosModel();
            try
            {
                h = db.Horarios.Where(x => x.nombre == txt_nombre.Text).FirstOrDefault();
                if (h != null)
                {
                    txt_nombre.Background = Brushes.Red;
                    return;
                }
                h = new HorariosModel();
                h.nombre = txt_nombre.Text;

                h.lunes = cb_lunes.IsChecked.Value;
                h.martes = cb_martes.IsChecked.Value;
                h.miercoles = cb_miercoles.IsChecked.Value;
                h.jueves = cb_jueves.IsChecked.Value;
                h.viernes = cb_viernes.IsChecked.Value;
                h.sabado = cb_sabado.IsChecked.Value;
                h.domingo = cb_domingo.IsChecked.Value;

                h.entrada1 = stringAHora(txt_entrada1.Text);
                h.salida1 = stringAHora(txt_salida1.Text);
                h.entrada2 = stringAHora(txt_entrada2.Text);
                h.salida2 = stringAHora(txt_salida2.Text);

                if ((h.salida1 - h.entrada1) + (h.salida2 - h.entrada2) >= stringAHora("08:00")) h.jornadaCompleta = true;

                db.Horarios.Add(h);
                db.SaveChanges();
                //Una vez registrado limpiamos los textboxes
                txt_nombre.Text = "";
                cb_lunes.IsChecked = false;
                cb_martes.IsChecked = false;
                cb_miercoles.IsChecked = false;
                cb_jueves.IsChecked = false;
                cb_viernes.IsChecked = false;
                cb_sabado.IsChecked = false;
                cb_domingo.IsChecked = false;
                txt_entrada1.Text = "";
                txt_salida1.Text = "";
                txt_entrada2.Text = "";
                txt_salida2.Text = "";
            }
            catch
            {
                if (h.entrada1 == null) txt_entrada1.Background = Brushes.Red;
                else if (h.salida1 == null) txt_salida1.Background = Brushes.Red;
                else if (h.entrada2 == null) txt_entrada2.Background = Brushes.Red;
                else if (h.salida2 == null) txt_salida2.Background = Brushes.Red;
            }

        }
        #endregion
       
        #region metodos
        private static TimeSpan stringAHora(string txt_hora)
        {
            string[] hora = txt_hora.Split(':');
            int h = int.Parse(hora[0]);
            int m = int.Parse(hora[1]);
            TimeSpan ts = new TimeSpan(h, m, 00);
            return ts;
        }
       
       
        #endregion
    }
}
