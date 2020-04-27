using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun.Cache;
using Domain;

namespace Presentacion
{
    public partial class FormUserProfile : Form
    {
        public FormUserProfile()
        {
            InitializeComponent();
        }

        private void FormUserProfile_Load(object sender, EventArgs e)
        {
            loadUserData();
            initializePassEditControl();
        }

        private void loadUserData()
        {

            lblfname.Text = UserLoginCache.FirstName;
            lbllname.Text = UserLoginCache.LastName;
            lblemail.Text = UserLoginCache.Email;
            lblpos.Text = UserLoginCache.Position;

            txtusername.Text = UserLoginCache.LoginName;
            txtname.Text = UserLoginCache.FirstName;
            txtlastname.Text = UserLoginCache.LastName;
            txtemail.Text = UserLoginCache.Email;
            txtpass.Text = UserLoginCache.Password;
            txtconfirm.Text = UserLoginCache.Password;
            txtcurrent.Text = "";
            



        }

        private void initializePassEditControl()
        {
           
            linklbleditpass.Text = "Edit";
            txtpass.Enabled = false;
            txtpass.UseSystemPasswordChar = true;
            txtconfirm.Enabled = false;
            txtconfirm.UseSystemPasswordChar = true;

        }

        private void reset()
        {
            loadUserData();
            initializePassEditControl();
        }

        private void linklbleditpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linklbleditpass.Text == "Edit")
            {
                linklbleditpass.Text = "Cancel";
                txtpass.Enabled = true;
                txtpass.Text = "";
                txtconfirm.Text = "";
                txtconfirm.Enabled = true;
            }else if (linklbleditpass.Text == "Cancel")
            {
                initializePassEditControl();
                txtpass.Text = UserLoginCache.Password;
                txtconfirm.Text = UserLoginCache.Password;
                
            }
        }

        private void linklbleditperfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            loadUserData();
        }


        //save
        private void button2_Click(object sender, EventArgs e)
        {

            if (txtpass.Text.Length >=5)
            {

                if (txtpass.Text == txtconfirm.Text)
                {
                    if (txtcurrent.Text == UserLoginCache.Password)
                    {
                        var userModel = new UserModel(idUSer:UserLoginCache.IdUser,
                            loginName:txtusername.Text,
                            password:txtpass.Text,
                            firstName:txtname.Text,
                            lastName:txtlastname.Text,
                            position:null,
                            email:txtemail.Text);

                        var result = userModel.editUserProfile();
                        MessageBox.Show(result);
                        reset();
                        panel1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect current password");
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña do not match, try again");
                }
            }
            else
            {
                MessageBox.Show("Contra muy corta");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            reset();
        }
    }
}
