using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun.Cache;
using System.Globalization;

namespace Presentacion.CustomControls
{
    public partial class CalendarioComp : UserControl
    {
        public CalendarioComp()
        {
            InitializeComponent();
        }


        private int _mesSeleccionado;
        private int _añoSeleccionado;

        private int diasTotalMes;
        private string primerDiaDelMes;
        private DateTimeFormatInfo formatDate;
        private CultureInfo es;
        private TextInfo inf;

        public delegate void Delegate(UserControl sender, EventArgs e, int numeroOperacion);
       
        public event Delegate eventDelegateOperacionDiasPendientes;
        public event Delegate eventDelegateCambiarAño;
       




        private void CalendarioComp_Load(object sender, EventArgs e)
        {
            es = new CultureInfo("Es-Es");
            inf = es.TextInfo;
            formatDate = es.DateTimeFormat;
            _mesSeleccionado = DateTime.Now.Month;
            _añoSeleccionado = DateTime.Now.Year;
            cargarUsuarios();
            cargarFechasYFormatos();
            cargarDias();
           

            


        }

        private void cargarUsuarios()
        {
            //Creamos las labels de los nombres (habra que cambiarlas por otras mas bonitas)
            //Por ahora habra 5
            var listLabels = new List<Label>();
            for (int i = 0; i < 5; i++)
            {
                listLabels.Add(new Label());
            }
            foreach (Label l in listLabels)
            {
                var i = new Random();
                l.Text = "Usuario" + i.Next(200).ToString();
                l.Dock = DockStyle.Fill;

            }

            for (int i = 0; i < listLabels.Count(); i++)
            {
                tableLayoutPanel1.Controls.Add(listLabels[i], 0, i + 1);
            }
        }
        private void cargarFechasYFormatos()
        {

            label1.Text = inf.ToTitleCase(formatDate.GetMonthName(_mesSeleccionado)) + " " + _añoSeleccionado.ToString();

            diasTotalMes = DateTime.DaysInMonth(_añoSeleccionado, _mesSeleccionado);

            

        }


        private void cargarDias()
        {




            var column = 0;
            
            for (int i=1;i<=diasTotalMes;i++)
            {
                var dt = new DateTime(_añoSeleccionado, _mesSeleccionado, i);
                var dia = dt.ToString("dddd");
                var letraDia = "";
                switch (dia)
                {
                    case "lunes":
                        letraDia = "L";
                        break;
                    case "martes":
                        letraDia = "M";
                        break;
                    case "miércoles":
                        letraDia = "X";
                        break;
                    case "jueves":
                        letraDia = "J";
                        break;
                    case "viernes":
                        letraDia = "V";
                        break;
                    case "sábado":
                        letraDia = "S";
                        break;
                    case "domingo":
                        letraDia = "D";
                        break;
                }
                var lab = new Label();
                lab.Text = i.ToString()+letraDia;
                lab.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(lab, i,0);
            }







        }

        private void refresh()
        {
            for (int i = 1;i<=diasTotalMes;i++)
            {
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(i,0));
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
            refresh();
           
            cargarFechasYFormatos();
            cargarDias();
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
            refresh();
            
            cargarFechasYFormatos();
            cargarDias();
        }

        public void cambiarAño(int año)
        {


            _añoSeleccionado = año;
            refresh();
            cargarFechasYFormatos();
            cargarDias();

        }

    }
}
