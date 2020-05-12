using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para CalendarControl.xaml
    /// </summary>
    public partial class CalendarControl : UserControl
    {
        public CalendarControl()
        {
            InitializeComponent();
        }

        int mesSeleccionado = DateTime.Now.Month;
        int añoSeleccionado = DateTime.Now.Year;
        private DateTimeFormatInfo formatDate;
        private CultureInfo es;
        private TextInfo inf;
        private int diasTotalMes;
        private string primerDiaDelMes;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            es = new CultureInfo("Es-Es");
            inf = es.TextInfo;
            formatDate = es.DateTimeFormat;
            cargarFechasFormatosYCalendar();
        }

        private void cargarFechasFormatosYCalendar()
        {

            lblMes.Content = inf.ToTitleCase(formatDate.GetMonthName(mesSeleccionado)) + " " + añoSeleccionado.ToString();

            diasTotalMes = DateTime.DaysInMonth(añoSeleccionado, mesSeleccionado);

            primerDiaDelMes = (new DateTime(añoSeleccionado, mesSeleccionado, 1)).ToString("dddd");
            cargarNumerosCalendar();
        }


        private void cargarNumerosCalendar()
        {
            var col = 0;

            var row = 0;
            var diasMesAnterior = DateTime.DaysInMonth(añoSeleccionado, (mesSeleccionado == 1) ? 12 : mesSeleccionado - 1);
            var iterador = 0;

            //si tienes alguna label en la grid la eliminara , asi no se superponen
            if (gridCalendar.Children.Count > 0)
            {
                gridCalendar.Children.Clear();
            }

            switch (primerDiaDelMes)
            {
                case "lunes":
                    col = 0;
                    break;
                case "martes":
                    col = 1;
                    break;
                case "miércoles":
                    col = 2;
                    break;
                case "jueves":
                    col = 3;
                    break;
                case "viernes":
                    col = 4;
                    break;
                case "sábado":
                    col = 5;
                    break;
                case "domingo":
                    col = 6;
                    break;
            }

            var diasAnteriores = col;


            for (int i = 1; i <= diasTotalMes; i++)
            {
                var lb = new Label();
                lb.Content = i.ToString();
                lb.MouseLeftButtonUp += click_calendar;
                if (col == 7)
                {
                    col = 0;
                    row++;

                }

                Grid.SetColumn(lb, col);
                Grid.SetRow(lb, row);

                gridCalendar.Children.Add(lb);
                col++;
            }



            //Numero del mes anterior que estaran desactivados
            for (int i = diasAnteriores; i > 0; i--)
            {
                var lb = new Label();
                lb.Content = (diasMesAnterior - iterador).ToString();
                lb.IsEnabled = true;
                lb.Foreground = Brushes.Gray;
                Grid.SetColumn(lb, i - 1);
                Grid.SetRow(lb, 0);
                gridCalendar.Children.Add(lb);
                iterador++;
            }

            //Dias posteriores

            var diasPosterior = 42 - diasTotalMes - diasAnteriores;

            for (int i = 0; i < diasPosterior; i++)
            {
                var lb = new Label();
                lb.Content = (i + 1).ToString();
                lb.IsEnabled = true;
                lb.Foreground = Brushes.Gray;
                if (col == 7)
                {
                    col = 0;
                    row++;

                }

                Grid.SetColumn(lb, col);
                Grid.SetRow(lb, row);

                gridCalendar.Children.Add(lb);
                col++;
            }




        }

        private void click_calendar(object sender, MouseButtonEventArgs e)
        {
            var celda = (Label)sender;
            var color = ((Label)sender).Background;



            if (color == Brushes.MediumTurquoise)
            {
                celda.Background = Brushes.White;
                celda.Foreground = Brushes.Black;

            }
            else
            {
                celda.Background = Brushes.MediumTurquoise;
                celda.Foreground = Brushes.White;
            }


        }



        private void adelante_Click(object sender, RoutedEventArgs e)
        {
            if (mesSeleccionado < 12)
            {
                mesSeleccionado++;
            }
            else
            {
                añoSeleccionado++;
                mesSeleccionado = 1;
            }
            cargarFechasFormatosYCalendar();

        }

        private void atras_Click(object sender, RoutedEventArgs e)
        {
            if (mesSeleccionado > 1)
            {
                mesSeleccionado--;
            }
            else
            {

                añoSeleccionado--;
                mesSeleccionado = 12;
            }

            cargarFechasFormatosYCalendar();

        }

    }
}
