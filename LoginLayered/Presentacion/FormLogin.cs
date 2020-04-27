using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Domain;
using Comun.Cache;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void textuser_Enter(object sender, EventArgs e)
        {
            if (textuser.Text == "Usuario")
            {
                textuser.Text = "";
                textuser.ForeColor = Color.Black;
            }
        }

        private void textuser_Leave(object sender, EventArgs e)
        {
            if (textuser.Text == "")
            {
                textuser.Text = "Usuario";
                textuser.ForeColor = Color.Black;
            }
        }

        private void textpass_Enter(object sender, EventArgs e)
        {
            if (textpass.Text == "Contraseña")
            {
                textpass.Text = "";
                textpass.ForeColor = Color.Black;
                textpass.UseSystemPasswordChar = true;
            }

        }

        private void textpass_Leave(object sender, EventArgs e)
        {
            if (textpass.Text == "")
            {
                textpass.Text = "Contraseña";
                textpass.ForeColor = Color.Black;
                textpass.UseSystemPasswordChar = false;

            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Lo primero, damos click para ir al menu principal con nuestro usuario
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //si usuario es lo que tenemos en el placeholder, osea usuario , sera incorrecto(es una validacion se cambiara si se quiere)
            if (textuser.Text != "Usuario")
            {
                //lo mismo que en textuser
                if (textpass.Text != "Contraseña"){
                    UserModel user = new UserModel();//creamos un modelo de usuario
                    var validLogin = user.LoginUser(textuser.Text, textpass.Text);// metodo login user que nos devolvera si es valido o no
                    if(validLogin == true)
                    {
                        this.Hide();//ocultamos este form
                        FormWelcome welcome = new FormWelcome();//creamos instancia del form bienvenida
                        welcome.ShowDialog();//lo mostramos

                        MenuPrincipal mainMenu = new MenuPrincipal();//instancia de form principal
                       
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;    //digamos que si le damos al boton logout
                        //el qual en la clase principal llamara a this.close(), osea cerrara, esta linia detecta
                        //el cierre y le concatena mas metodos, el metodo Logout que esta mas abajo...
                        this.Hide();//oculta esta form y nos vamos a la principaaal
                    }
                    else
                    {
                        msgError("Incorrect username or password a saber");
                        textpass.Text = "Contraseña";
                        textuser.Focus();//vuelve el foco al textbox textuser
                    }
                }
                else
                {
                    msgError("Please enter password");
                }
            }
            else
            {
                msgError("Please enter username");
            }
        }

        private void msgError(string msg)
        {
            lblError.Text = "   " + msg;
            lblError.Visible = true;
        }


        private void Logout(object sender, FormClosedEventArgs e)
        {
            textpass.Text = "Contraseña";
            textpass.UseSystemPasswordChar = false;
            textuser.Text = "Usuario";
            lblError.Visible = false;
            this.Show();
            textuser.Focus();
        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoverPassword = new RecuperarContraseña();
            recoverPassword.ShowDialog();
        }
    }
}
