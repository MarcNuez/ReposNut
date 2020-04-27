using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Presentacion.CustomControls
{
    public partial class UserControlAusencia : UserControl
    {
        public UserControlAusencia()
        {
            InitializeComponent();
        }
        private int _mesSeleccionado = 1;

        private int _añoSeleccionado = 2020;


        public int AñoSeleccionado
        {
            get { return _añoSeleccionado; }

            set { _añoSeleccionado = value; }
        }

        public int MesSeleccionado
        {
            get { return _mesSeleccionado; }

            set { _mesSeleccionado = value; }
        }

        private int diasTotalMes;
        private string primerDiaDelMes;
        private DateTimeFormatInfo formatDate;
        private CultureInfo es;
        private TextInfo inf;



        public delegate void Delegate(UserControlAusencia sender, EventArgs e, string diaElegido, string mes, string año);


        public event Delegate eventDelegateClickCalendarAusencias;

        private void UserControlAusencia_Load(object sender, EventArgs e)
        {
            es = new CultureInfo("Es-Es");
            inf = es.TextInfo;
            formatDate = es.DateTimeFormat;
            _mesSeleccionado = DateTime.Now.Month;
            _añoSeleccionado = DateTime.Now.Year;

            cargarFechasYFormatos();

            posicionarNumerosCalendar();
        }

        private void cargarFechasYFormatos()
        {
            
            label1.Text = inf.ToTitleCase(formatDate.GetMonthName(_mesSeleccionado)) + " " + _añoSeleccionado.ToString();

            diasTotalMes = DateTime.DaysInMonth(_añoSeleccionado, _mesSeleccionado);

            primerDiaDelMes = (new DateTime(_añoSeleccionado, _mesSeleccionado, 1)).ToString("dddd");
        }



        public void clickarNumeroCalendar(object sender, EventArgs e)
        {

            var dia = ((Button)sender).Text;
            var blanco = Color.White;
            var negro = Color.Black;
            var turquesa = Color.MediumTurquoise;



            if (((Button)sender).BackColor != blanco)
            {

                ((Button)sender).BackColor = blanco;
                ((Button)sender).ForeColor = negro;
            }
            else
            {
                foreach (Button b in tableLayoutPanel2.Controls.OfType<Button>())
                {
                    b.BackColor = blanco;
                    b.ForeColor = negro;
                }
                eventDelegateClickCalendarAusencias?.Invoke(this, e, dia,_mesSeleccionado.ToString(),_añoSeleccionado.ToString());
                ((Button)sender).BackColor = turquesa;
                ((Button)sender).ForeColor = blanco;


            }

        }

        private void posicionarNumerosCalendar()
        {
            //Numero del mes al que corresponde
            var column = 0;
            switch (primerDiaDelMes)
            {
                case "lunes":
                    column = 0;
                    break;
                case "martes":
                    column = 1;
                    break;
                case "miércoles":
                    column = 2;
                    break;
                case "jueves":
                    column = 3;
                    break;
                case "viernes":
                    column = 4;
                    break;
                case "sábado":
                    column = 5;
                    break;
                case "domingo":
                    column = 6;
                    break;
            }

            var diasAnteriores = column;



            var fila = 0;
            for (int i = 0; i < diasTotalMes; i++)
            {

                if (column <= 6)
                {

                    tableLayoutPanel2.GetControlFromPosition(column, fila).Text = (i + 1).ToString();
                    tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = Color.White;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).ForeColor = Color.Black;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Enabled = true;




                    column++;
                }
                else
                {

                    column = 0;
                    fila++;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Text = (i + 1).ToString();
                    tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = Color.White;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).ForeColor = Color.Black;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Enabled = true;
                    column++;



                }


            }

            //Numero del mes anterior que estaran desactivados
            var diasMesAnterior = DateTime.DaysInMonth(_añoSeleccionado, (_mesSeleccionado == 1) ? 12 : _mesSeleccionado - 1);
            var iterador = 0;



            for (int i = diasAnteriores; i > 0; i--)
            {

                tableLayoutPanel2.GetControlFromPosition(i - 1, 0).Text = (diasMesAnterior - iterador).ToString();
                tableLayoutPanel2.GetControlFromPosition(i - 1, 0).BackColor = Color.LightGray;
                tableLayoutPanel2.GetControlFromPosition(i - 1, 0).Enabled = false;
                iterador++;
            }



            //Dias posteriores

            var diasPosterior = 42 - diasTotalMes - diasAnteriores;


            for (int i = 0; i < diasPosterior; i++)
            {
                if (column <= 6)
                {
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Text = (i + 1).ToString();
                    tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = Color.LightGray;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Enabled = false;
                    column++;
                }
                else
                {
                    column = 0;
                    fila++;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Text = (i + 1).ToString();
                    tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = Color.LightGray;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Enabled = false;
                    column++;
                }
            }


        }

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            if (_mesSeleccionado < 12)
            {
                _mesSeleccionado++;
            }
            else
            {
                _añoSeleccionado++;
                _mesSeleccionado = 1;
            }
            cargarFechasYFormatos();
            posicionarNumerosCalendar();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (_mesSeleccionado > 1)
            {
                _mesSeleccionado--;
            }
            else
            {

                _añoSeleccionado--;
                _mesSeleccionado = 12;
            }

            cargarFechasYFormatos();
            posicionarNumerosCalendar();
        }
    }
}
