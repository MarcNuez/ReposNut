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
    public partial class UserControlMensual : UserControl
    {
        public UserControlMensual()
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

        public delegate void Delegate(UserControl sender, EventArgs e, int numeroOperacion);
        public delegate void Delegate2(UserControl sender, EventArgs e, ClaseDiasElegidosVacaciones obj);
        public event Delegate eventDelegateOperacionDiasPendientes;
        public event Delegate eventDelegateCambiarAño;
        public event Delegate2 eventDelegatePasarDia;

        private ClaseDiasElegidosVacaciones diaElegido;
        private DiasElegidosModel elegidosModel;
        private DiasVacacionesModel diasVacasModel;


        //lista que guarda objetos de diaselegidos para cuando cambias de mes y vuelves sigan estando bien 
        //seleccionados y azules
        public List<ClaseDiasElegidosVacaciones> listaDiasElegidos;

        private void UserControlMensual_Load(object sender, EventArgs e)
        {
            elegidosModel = new DiasElegidosModel();
            diasVacasModel = new DiasVacacionesModel();
            es = new CultureInfo("Es-Es");
            inf = es.TextInfo;
            formatDate = es.DateTimeFormat;
            _mesSeleccionado = DateTime.Now.Month;
            _añoSeleccionado = DateTime.Now.Year;
            listaDiasElegidos = new List<ClaseDiasElegidosVacaciones>();
            cargarFechasYFormatos();


        }

        private void cargarFechasYFormatos()
        {

            label1.Text = inf.ToTitleCase(formatDate.GetMonthName(_mesSeleccionado)) + " " + _añoSeleccionado.ToString();

            diasTotalMes = DateTime.DaysInMonth(_añoSeleccionado, _mesSeleccionado);

            primerDiaDelMes = (new DateTime(_añoSeleccionado, _mesSeleccionado, 1)).ToString("dddd");
            posicionarNumerosCalendar();
        }

        //son los butons del calendario, le das y cambian de color
        public void clickarNumeroCalendar(object sender, EventArgs e)
        {

            var dia = Int32.Parse(((Button)sender).Text);
            var blanco = Color.White;
            var negro = Color.Black;
            var turquesa = Color.MediumTurquoise;
            var azul = Color.Blue;


            if (((Button)sender).BackColor == turquesa)
            {

                var item = listaDiasElegidos.FirstOrDefault(x => x.obtenerDia() == dia && x.obtenerMes() == _mesSeleccionado && x.obtenerAño() == _añoSeleccionado);
                if (item != null)
                {
                    eventDelegatePasarDia?.Invoke(this, e, item);
                    listaDiasElegidos.Remove(item);
                }
                eventDelegateOperacionDiasPendientes?.Invoke(this, e, 1);

                ((Button)sender).BackColor = blanco;
                ((Button)sender).ForeColor = negro;



            }
            else if (((Button)sender).BackColor == blanco)
            {

                diaElegido = new ClaseDiasElegidosVacaciones(dia, _mesSeleccionado, _añoSeleccionado);
                listaDiasElegidos.Add(diaElegido);
                eventDelegateOperacionDiasPendientes?.Invoke(this, e, -1);
                eventDelegatePasarDia?.Invoke(this, e, diaElegido);

                ((Button)sender).BackColor = turquesa;
                ((Button)sender).ForeColor = blanco;


            }
            else if (((Button)sender).BackColor == azul)
            {
                if (MessageBox.Show("Este dia esta pendiente para aceptar, desea quitarlo?", "Atención",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ((Button)sender).BackColor = blanco;
                    ((Button)sender).ForeColor = negro;
                    //Como se cancela se suma uno a los dias
                    eventDelegateOperacionDiasPendientes?.Invoke(this, e, 1);
                    diasVacasModel.sumarDiasCancelados(1);
                    elegidosModel.quitarDiaElegido(new DateTime(_añoSeleccionado, _mesSeleccionado, dia));

                }

            }

        }

        //rellena la tabla con los dias ordenados
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
                var item = listaDiasElegidos.FirstOrDefault(x => x.obtenerDia() == i + 1 && x.obtenerMes() == _mesSeleccionado && x.obtenerAño() == _añoSeleccionado);
                var diasElegidoBBDD = elegidosModel.comprobarSiEstaElegido(new DateTime(_añoSeleccionado, _mesSeleccionado, i + 1));
                if (column <= 6)
                {


                    tableLayoutPanel2.GetControlFromPosition(column, fila).Text = (i + 1).ToString();
                    if (diasElegidoBBDD)
                    {
                        tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = Color.Blue;
                        tableLayoutPanel2.GetControlFromPosition(column, fila).ForeColor = column == 6 ? Color.Red : Color.White;

                    }
                    else
                    {
                        tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = item == null ? Color.White : Color.MediumTurquoise;
                        tableLayoutPanel2.GetControlFromPosition(column, fila).ForeColor = column == 6 ? Color.Red : (item == null ? Color.Black : Color.White);

                    }
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Enabled = true;

                    column++;
                }
                else
                {

                    column = 0;
                    fila++;
                    tableLayoutPanel2.GetControlFromPosition(column, fila).Text = (i + 1).ToString();
                    if (diasElegidoBBDD)
                    {
                        tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = Color.Blue;
                        tableLayoutPanel2.GetControlFromPosition(column, fila).ForeColor = Color.White;

                    }
                    else
                    {
                        tableLayoutPanel2.GetControlFromPosition(column, fila).BackColor = item == null ? Color.White : Color.MediumTurquoise;
                        tableLayoutPanel2.GetControlFromPosition(column, fila).ForeColor = item == null ? Color.Black : Color.White;

                    }

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
                eventDelegateCambiarAño?.Invoke(this, e, _añoSeleccionado);
                _mesSeleccionado = 1;
            }
            cargarFechasYFormatos();
           
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
                eventDelegateCambiarAño?.Invoke(this, e, _añoSeleccionado);
                _mesSeleccionado = 12;
            }

            cargarFechasYFormatos();
           
        }

        public void cambiarAño(int año)
        {


            AñoSeleccionado = año;

            cargarFechasYFormatos();
            

        }

       
    }
}
