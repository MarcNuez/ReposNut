using Domain;
using Presentacion.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormAusencias : Form
    {
        public FormAusencias()
        {
            InitializeComponent();
        }


        private DateTime date1 = DateTime.Now;
        private DateTime date2 = DateTime.Now;

        private void ClickCalendar(object sender, EventArgs e)
        {
            panelCalendarAusencias2.Visible = false;

            panelCalendarAusencias2.BorderStyle = BorderStyle.FixedSingle;
            if (panelCalendarAusencias.Visible == false)
            {
                panelCalendarAusencias.Visible = true;
                ((Panel)sender).BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                panelCalendarAusencias.Visible = false;
                ((Panel)sender).BorderStyle = BorderStyle.FixedSingle;
            }





        }

        private void ClickCalendar2(object sender, EventArgs e)
        {
            panelCalendarAusencias.Visible = false;
            panelCalendarAusencias.BorderStyle = BorderStyle.FixedSingle;
            if (panelCalendarAusencias2.Visible == false)
            {
                panelCalendarAusencias2.Visible = true;
                ((Panel)sender).BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                panelCalendarAusencias2.Visible = false;
                ((Panel)sender).BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void FormAusencias_Load(object sender, EventArgs e)
        {
            userControlAusencia1.eventDelegateClickCalendarAusencias += cambiarLabelFechaDesde;
            userControlAusencia2.eventDelegateClickCalendarAusencias += cambiarLabelFechaHasta;
            cargarCombobox();
        }

        private void cargarCombobox()
        {
            TiposAusenciasModel tipos = new TiposAusenciasModel();
            cmbTipo.DataSource = tipos.obtenerTiposAusencias();
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "Id";
        }


        private void cambiarLabelFechaDesde(UserControlAusencia sender, EventArgs e, string diaElegido, string mes, string año)
        {
            date1 = new DateTime(Int32.Parse(año), Int32.Parse(mes), Int32.Parse(diaElegido));
            if (date1 <= date2)
            {
                lblFechaDesde.Text = diaElegido + "." + mes + "." + año;
                panelCalendarAusencias.Visible = false;

                if (lblFechaDesde.Text != "" && lblFechaHasta.Text != "")
                {

                    var diastotales = ((date2 - date1).TotalDays) + 1;
                    lblIntervalo.Text = diastotales.ToString() + " " + (diastotales > 1 ? "Dias" : "Dia");
                }
            }
            else
            {
                MessageBox.Show("La fecha de inicio no puede ser menor que la fecha final");
            }


        }
        private void cambiarLabelFechaHasta(UserControlAusencia sender, EventArgs e, string diaElegido, string mes, string año)
        {
            date2 = new DateTime(Int32.Parse(año), Int32.Parse(mes), Int32.Parse(diaElegido));
            if (date1 <= date2)
            {
                lblFechaHasta.Text = diaElegido + "." + mes + "." + año;
                panelCalendarAusencias2.Visible = false;
               
                if (lblFechaDesde.Text != "" && lblFechaHasta.Text != "")
                {

                    var diastotales = (date2 - date1).TotalDays + 1;
                    lblIntervalo.Text = diastotales.ToString() + " " + (diastotales > 1 ? "dias" : "Dia");
                }
            }
            else
            {
                MessageBox.Show("La fecha de inicio no puede ser menor que la fecha final");
            }
        }

        //butonsito guardar
        private void button1_Click(object sender, EventArgs e)
        {
            var ausencia = new AusenciasModel();
            var tipo = cmbTipo.Text;
            var comentario = textBox1.Text;
            ausencia.guardarAusencias(tipo, date1, date2,comentario);
            MessageBox.Show("Ausencia guardada con exito");

        }
    }
}
