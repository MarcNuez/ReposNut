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
        private GestionAdminModel gModel = new GestionAdminModel();

        private void FormGestionAdmin_Load(object sender, EventArgs e)
        {

            cmbEstado.SelectedItem = "Pendientes"; //esto llama autoamticamente el evento selectionchanged

            
         


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


            var dt = gModel.obtenerVacacionesUsuarios();
            dataGrid.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                if (estado == "Todas")
                {
                    dataGrid.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4].ToString().Substring(0, 10), dr[5]);


                }
                else if (dr[3].ToString() == estado)
                {
                    dataGrid.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4].ToString().Substring(0, 10), dr[5]);



                }



            }
            //las que ya esten aprobadas no podras marcar cell y las pendientes estaran al iniciarse en false
            foreach (DataGridViewRow dr in dataGrid.Rows)
            {


                if (dr.Cells[3].Value.ToString() == "Aprobada")
                {
                    dr.Cells[3].Style.BackColor = Color.FromArgb(172, 252, 208);
                   
                    dr.Cells[6].Value = true;
                    dr.Cells[6].ReadOnly = true;
                }
                else
                {

                    dr.Cells[6].Value = false;

                }


               


            }
            if (dataGrid.Rows.Count>0)
            {
                dataGrid.CurrentCell.Selected = false;
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
                if (d.Cells[3].Value.ToString() == "Pendiente")
                {
                    if ((bool)d.Cells[6].Value)
                    {
                        d.Cells[6].Value = false;
                    }
                    else
                    {
                        d.Cells[6].Value = true;
                    }
                }
                



            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstadoCmbBox();
            cargarGrid(estadoSeleccionado);
        }



        private void FormGestionAdmin_Click(object sender, EventArgs e)
        {
            dataGrid.ClearSelection();
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            var count = 0;

            foreach (DataGridViewRow dr in dataGrid.Rows)
            {
                if ((bool)dr.Cells[6].Value == true && dr.Cells[3].Value.ToString() == "Pendiente")
                {
                    gModel.aprobarVacaciones(Int32.Parse(dr.Cells[0].Value.ToString()));
                    count++;
                }

            }
            MessageBox.Show("Se han aprobado: "+ count);
            cargarGrid(estadoSeleccionado);
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex == 7 && dataGrid.Rows[e.RowIndex].Cells[3].Value.ToString() == "Pendiente")
            {
                var id_dia = (int)dataGrid.Rows[e.RowIndex].Cells[0].Value;
                var id_user = (int)dataGrid.Rows[e.RowIndex].Cells[1].Value;
                var dia = DateTime.Parse(dataGrid.Rows[e.RowIndex].Cells[4].Value.ToString());
                var comentario = "por defecto";

                if (MessageBox.Show("¿Desea eliminar el dia?", "Atención",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) ;
                gModel.denegarVacaciones(id_dia,id_user,dia,comentario);
                cargarGrid(estadoSeleccionado);


            }else if (e.ColumnIndex == 7 && dataGrid.Rows[e.RowIndex].Cells[3].Value.ToString() == "Aprobada")
            {
                MessageBox.Show("Ya esta aprobada, para cancelar...");
            }
        }
    }
}
