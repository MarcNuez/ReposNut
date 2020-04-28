using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormGestionAdmin : Form
    {
        public FormGestionAdmin()
        {
            InitializeComponent();
        }

        private List<DataGridViewRow> lista = new List<DataGridViewRow>();
        private string estadoSeleccionado;
        CultureInfo culture = CultureInfo.InvariantCulture;

        private void FormGestionAdmin_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedItem = "Pendientes";


            dataGrid.CurrentCell.Selected = false;



        }

        private void cargarEstadoCmbBox()
        {

            if (cmbEstado.SelectedItem.ToString() == "Pendientes")
            {
                estadoSeleccionado = "Pendiente";

            }
            else if (cmbEstado.SelectedItem.ToString() == "Aprobadas")
            {
                estadoSeleccionado = "Aprobada";
            }
            else
            {
                estadoSeleccionado = "Todas";
            }

        }

        private void cargarLista()
        {
            if (lista.Count > 0)
            {
                lista.Clear();
            }
            foreach (DataGridViewRow d in dataGrid.Rows)
            {
                lista.Add(d);
            }

        }



        private void cargarGrid(string estado)
        {
            var gModel = new GestionAdminModel();

            var dt = gModel.obtenerVacacionesUsuarios();
            dataGrid.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                if (estado == "Todas")
                {
                    dataGrid.Rows.Add(dr[0], dr[1], dr[2].ToString().Substring(0, 10), dr[3]);
                }
                else if (dr[1].ToString() == estado)
                {
                    dataGrid.Rows.Add(dr[0], dr[1], dr[2].ToString().Substring(0, 10), dr[3]);
                }



            }
            cargarLista();

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var t = textBox1.Text;


            dataGrid.Rows.Clear();

            foreach (DataGridViewRow d in lista)
            {
                if (culture.CompareInfo.IndexOf(((string)d.Cells[0].Value), t.Trim(), CompareOptions.IgnoreCase) >= 0)
                {
                    dataGrid.Rows.Add(d);
                }


                

            }



        }

        private void btnMarcarTodasA_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d in dataGrid.SelectedRows)
            {
                if (d.Cells[4].Value == null)
                {
                    d.Cells[4].Value = false;
                }
                if ((bool)d.Cells[4].Value)
                {
                    d.Cells[4].Value = false;
                }
                else
                {
                    d.Cells[4].Value = true;
                }



            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstadoCmbBox();
            cargarGrid(estadoSeleccionado);
        }

        
    }
}
