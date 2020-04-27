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
using Domain;

namespace Presentacion.CustomControls
{
    public partial class UserControlCalendar : UserControl
    {




        public UserControlCalendar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }


        private int _mesSeleccionado = 1;

        private int _añoSeleccionado = 2020;

        private string tipoSeleccionado = "Vacaciones";
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

        private static ClaseDiasElegidosVacaciones diccionarioDias;
        private DiasElegidosModel diasModel;

        public delegate void Delegate(UserControlCalendar sender, EventArgs e, int numeroOperacion);

        public event Delegate eventDelegateOperacionDiasPendientes;
        public event Delegate eventDelegateClickCalendarAusencias;

        private void UserControlCalendar_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            es = new CultureInfo("Es-Es");
            inf = es.TextInfo;
            formatDate = es.DateTimeFormat;
           
            
            cargarFechasYFormatos();

            posicionarNumerosCalendar();
            ResumeLayout();

        }

       



        private void cargarFechasYFormatos()
        {

            label1.Text = inf.ToTitleCase(formatDate.GetMonthName(_mesSeleccionado));

            diasTotalMes = DateTime.DaysInMonth(_añoSeleccionado, _mesSeleccionado);

            primerDiaDelMes = (new DateTime(_añoSeleccionado, _mesSeleccionado, 1)).ToString("dddd");
        }



        //son los butons del calendario, le das y cambian de color
        public void clickarNumeroCalendar(object sender, EventArgs e)
        {

            var dia = Int32.Parse(((Button)sender).Text);
            var blanco = Color.White;
            var negro = Color.Black;
            var turquesa = Color.MediumTurquoise;
            var darkorange = Color.DarkOrange;



            if (((Button)sender).BackColor != blanco)
            {
                //si son vacas se suma o resta los dias de vacas , las ausencias no
                if (((Button)sender).BackColor == turquesa)
                {
                   
                    eventDelegateOperacionDiasPendientes?.Invoke(this, e, 1);
                }
                ((Button)sender).BackColor = blanco;
                ((Button)sender).ForeColor = negro;









            }
            else
            {

                if (tipoSeleccionado == "Vacaciones")
                {
                   
                    eventDelegateOperacionDiasPendientes?.Invoke(this, e, -1);
                }

                ((Button)sender).BackColor = tipoSeleccionado == "Ausencias" ? darkorange : turquesa;
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }


        public void cambiarAño(int año)
        {


            AñoSeleccionado = año;
            
            cargarFechasYFormatos();
            posicionarNumerosCalendar();

        }

        public void cambiarCmbSelected(string tipo)
        {

            tipoSeleccionado = tipo;

        }


    }
}
