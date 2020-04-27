using Comun.Cache;
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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }
        //boton cerrar
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Boton maximizar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        //boton minimizar
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoadUserData()
        {

            //de la clase cache obtiene en el nombre de usuario
            lblname.Text = UserLoginCache.FirstName + ", " + UserLoginCache.LastName;
            lblpos.Text = UserLoginCache.Position;
            

        }

        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            fh.FormBorderStyle = FormBorderStyle.None;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }
        //boton logout
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Warning",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        //boton Mis vacaciones
        private void button1_Click(object sender, EventArgs e)
        {
            pnlDecorBtn.Visible = true;
            pnlDecorBtn.Height = button1.Height;
            pnlDecorBtn.Top = button1.Top;
            AbrirFormEnPanel(new FormVacaciones());
        }
        //boton mis ausencias
        private void button2_Click(object sender, EventArgs e)
        {
            pnlDecorBtn.Visible = true;
            pnlDecorBtn.Height = button2.Height;
            pnlDecorBtn.Top = button2.Top;
            AbrirFormEnPanel(new FormAusencias());
        }

        
        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        #region

        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panel1.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        #endregion // 
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        //reloj
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("HH:mm:ss") + "      " + DateTime.Now.ToString("dddd MMMM yyyy"); ;

        }

        private void btnAdminGestion_Click(object sender, EventArgs e)
        {
            pnlDecorBtn.Visible = true;
            pnlDecorBtn.Height = btnAdminGestion.Height;
            pnlDecorBtn.Top = btnAdminGestion.Top;
            AbrirFormEnPanel(new FormGestionAdmin());
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            pnlDecorBtn.Visible = false;
            AbrirFormEnPanel(new FormUserProfile());
        }
    }
}
