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
using Comun;

namespace Presentacion
{
    public partial class FormVacaciones : Form
    {




        public FormVacaciones()
        {
            InitializeComponent();


        }


        public int diasPendientes;

        private int añoSeleccionado;

        DiasVacacionesModel diasVacasModel = new DiasVacacionesModel();

        private List<ClaseDiasElegidosVacaciones> listaDiasParaLblSelect;


        private void FormVacaciones_Load(object sender, EventArgs e)
        {
            listaDiasParaLblSelect = new List<ClaseDiasElegidosVacaciones>();

            cargarComboBoxTipos();
            cargarAñoActual();
            cargarDiasPendientes();    
            cargarMetodosCambiarAño();



        }

        private void cargarComboBoxTipos()
        {
            cmbTipo.SelectedItem = "Vacaciones";
        }

        private void cargarAñoActual()
        {
            añoSeleccionado = DateTime.Now.Year;
            lblAño.Text = añoSeleccionado.ToString();
        }

        private void cargarDiasPendientes()
        {
            diasPendientes = diasVacasModel.obtenerDias();
            lblDiasPendientes.Text = diasPendientes.ToString();
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



        private void metodoOperacionDiasPendientes(UserControl sender, EventArgs e, int numOperacion)
        {
            //maximo podra ser los dias que te hayan concedido por ley o el jefe
            if (diasVacasModel.obtenerDiasMaximo() >= (diasPendientes + numOperacion))
            {
                diasPendientes = diasPendientes + numOperacion;
                lblDiasPendientes.Text = diasPendientes.ToString();
            }

        }

        private void eventCambiarAño(UserControl sender, EventArgs e, int numOperacion)
        {
            añoSeleccionado = numOperacion;
            lblAño.Text = añoSeleccionado.ToString();
        }

        //añade de los calendarios a la etiqueta el dia/mes/año y ademas los ordena
        private void eventAñadirDiaLabelDiasSeleccionados(UserControl sender, EventArgs e, ClaseDiasElegidosVacaciones obj)
        {
            if (listaDiasParaLblSelect.Contains(obj))
            {
                listaDiasParaLblSelect.Remove(obj);
                lblDiasSelect.Text = "";
                listaDiasParaLblSelect.Sort();
                foreach (ClaseDiasElegidosVacaciones o in listaDiasParaLblSelect)
                {

                    lblDiasSelect.Text += o.ToString();
                }

            }
            else
            {
                listaDiasParaLblSelect.Add(obj);
                listaDiasParaLblSelect.Sort();
                lblDiasSelect.Text = "";
                foreach (ClaseDiasElegidosVacaciones o in listaDiasParaLblSelect)
                {

                    lblDiasSelect.Text += o.ToString();
                }


            }




        }



        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            //le podemos pasar lista dias label select que ya nos va bien
            DiasElegidosModel diasModel = new DiasElegidosModel(listaDiasParaLblSelect);
            diasModel.guardarDias();
            //Eliminamos la lista porque ya estara en la base de datos
            listaDiasParaLblSelect.Clear();
            userControlMensual1.listaDiasElegidos.Clear();
            lblDiasSelect.Text = "";
            MessageBox.Show("Dias solicitados con exito");




        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbTipo.SelectedItem.ToString() == "Vacaciones")
            {
                pnlMuestra.BackColor = Color.MediumTurquoise;
            }
            else
            {
                pnlMuestra.BackColor = Color.DarkOrange;
            }
        }

        private void btnMensual_Click(object sender, EventArgs e)
        {
            UserControlMensual calendMes = new UserControlMensual();
            añadirAlPanelContenedor(calendMes);
            cargarMetodosCambiarAño();
            //se situa en el año actual no en el seleccionado en el otro calendar (Lo cambiamos? o lo dejamos asi..)
            añoSeleccionado = DateTime.Now.Year;
            lblAño.Text = añoSeleccionado.ToString();
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {

            CalendarioComp calend = new CalendarioComp();
            añadirAlPanelContenedor(calend);
            cargarMetodosCambiarAño();
            //se situa en el año actual no en el seleccionado en el otro calendar (Lo cambiamos? o lo dejamos asi..)
            añoSeleccionado = DateTime.Now.Year;
            lblAño.Text = añoSeleccionado.ToString();

        }

        private void btnAtrasAño_Click(object sender, EventArgs e)
        {
            añoSeleccionado--;
            lblAño.Text = añoSeleccionado.ToString();
            //Si el control que contiene el panel es el calendario mensual o si es el de compañeros
            foreach (Control c in panelContainer.Controls)
            {
                if (c is UserControlMensual)
                {
                    ((UserControlMensual)c).cambiarAño(añoSeleccionado);
                }
                else
                {
                    ((CalendarioComp)c).cambiarAño(añoSeleccionado);
                }
            }

        }

        private void btnAdelanteAño_Click(object sender, EventArgs e)
        {
            añoSeleccionado++;
            lblAño.Text = añoSeleccionado.ToString();

            //Si el control que contiene el panel es el calendario mensual o si es el de compañeros

            foreach (Control c in panelContainer.Controls)
            {
                if (c is UserControlMensual)
                {
                    ((UserControlMensual)c).cambiarAño(añoSeleccionado);
                }
                else
                {
                    ((CalendarioComp)c).cambiarAño(añoSeleccionado);
                }
            }
        }


        private void añadirAlPanelContenedor(object controlhijo)
        {
            if (this.panelContainer.Controls.Count > 0)
                this.panelContainer.Controls.RemoveAt(0);
            UserControl fh = controlhijo as UserControl;

            fh.Dock = DockStyle.Fill;

            this.panelContainer.Controls.Add(fh);
            this.panelContainer.Tag = fh;
            fh.Show();
        }

        private void cargarMetodosCambiarAño()
        {

            foreach (Control c in panelContainer.Controls)
            {
                if (c is UserControlMensual)
                {
                    ((UserControlMensual)c).eventDelegateOperacionDiasPendientes += metodoOperacionDiasPendientes;
                    ((UserControlMensual)c).eventDelegateCambiarAño += eventCambiarAño;
                    ((UserControlMensual)c).eventDelegatePasarDia += eventAñadirDiaLabelDiasSeleccionados;
                }
                else
                {
                    ((CalendarioComp)c).eventDelegateOperacionDiasPendientes += metodoOperacionDiasPendientes;

                    ((CalendarioComp)c).eventDelegateCambiarAño += eventCambiarAño;
                }


            }



        }


    }
}
