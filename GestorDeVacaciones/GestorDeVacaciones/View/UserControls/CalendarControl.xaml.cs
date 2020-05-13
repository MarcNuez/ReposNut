using GestorDeVacaciones.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class CalendarControl : UserControl, INotifyPropertyChanged
    {
        public CalendarControl()
        {
            InitializeComponent();
        }

        private ObservableCollection<DiasElegidosModel> _listaDiasSeleccionados;
        public ObservableCollection<DiasElegidosModel> ListaDiasSeleccionados
        {
            get
            {
                return _listaDiasSeleccionados;
            }
            set
            {
                _listaDiasSeleccionados = value;
                OnPropertyChanged("ListaDiasSeleccionados")
                ;
            }
        }


        public int AñoSeleccionado
        {
            get { return añoSeleccionado; }
            set
            {
                añoSeleccionado = value;
                cargarFechasFormatosYCalendar();
                OnPropertyChanged("AñoSeleccionado");
            }
        }




        private int mesSeleccionado = DateTime.Now.Month;
        private int añoSeleccionado = DateTime.Now.Year;
        private DateTimeFormatInfo formatDate;
        private CultureInfo es;
        private TextInfo inf;
        private int diasTotalMes;
        private string primerDiaDelMes;

        #region propertychanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            ListaDiasSeleccionados = new ObservableCollection<DiasElegidosModel>();
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

            //Dias del mes que se pueden clickar
            for (int i = 1; i <= diasTotalMes; i++)
            {
                var lb = new Label();
                lb.Content = i.ToString();
                lb.MouseLeftButtonUp += click_calendar;
                var item =  _listaDiasSeleccionados.FirstOrDefault(x => x.Dia == i && x.Mes == mesSeleccionado && x.Año == añoSeleccionado);

                if (item!=null)
                {
                    lb.Background = Brushes.MediumTurquoise;
                    lb.Foreground = Brushes.White;
                }
                else
                {
                    lb.Background = Brushes.White;
                    lb.Foreground = col == 6 ? Brushes.Red:Brushes.Black;
                }


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
        public void refesh()
        {
            cargarNumerosCalendar();
        }






        private void click_calendar(object sender, MouseButtonEventArgs e)
        {
            var celda = (Label)sender;
            var color = ((Label)sender).Background;



            if (color == Brushes.MediumTurquoise)
            {
                celda.Background = Brushes.White;
                celda.Foreground = celda.Foreground == Brushes.Red ? Brushes.Red : Brushes.Black;
                //Elimina de la lista el dia deseleccionado
                var itemToRemove = ListaDiasSeleccionados.SingleOrDefault(r => r.Dia == Int32.Parse(celda.Content.ToString())
                                    && r.Mes == mesSeleccionado && r.Año == añoSeleccionado);
                if (itemToRemove != null)
                    _listaDiasSeleccionados.Remove(itemToRemove);
                restarDias(sender, e);
            }
            else if(color == Brushes.White)
            {
                celda.Background = Brushes.MediumTurquoise;
                celda.Foreground = celda.Foreground == Brushes.Red ? Brushes.Red : Brushes.White;
                _listaDiasSeleccionados.Add(new DiasElegidosModel(Int32.Parse(celda.Content.ToString()), mesSeleccionado, añoSeleccionado));
                
                sumarDias(sender, e);
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
                AñoSeleccionado++;
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

                AñoSeleccionado--;
                mesSeleccionado = 12;
            }

            cargarFechasFormatosYCalendar();

        }

        #region eventos enrutados para pasar de usercontrol hijo a padre
        public static readonly RoutedEvent OnClickedrestarDias
            = EventManager.RegisterRoutedEvent("restarDias", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(CalendarControl));
        public static readonly RoutedEvent OnClickedsumarDias
    = EventManager.RegisterRoutedEvent("sumarDias", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(CalendarControl));

        // expose our event
        public event RoutedEventHandler OnClickedrestarDias_Clicked
        {
            add { AddHandler(OnClickedrestarDias, value); }
            remove { RemoveHandler(OnClickedrestarDias, value); }
        }

        public event RoutedEventHandler OnClickedsumarDias_Clicked
        {
            add { AddHandler(OnClickedsumarDias, value); }
            remove { RemoveHandler(OnClickedsumarDias, value); }
        }

        private void restarDias(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnClickedrestarDias));
        }
        private void sumarDias(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OnClickedsumarDias));
        }
        #endregion

    }
}
