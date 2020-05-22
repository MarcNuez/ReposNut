using GestorDeVacaciones.Core;
using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model.Cache;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GestorDeVacaciones.ViewModel
{
    public class EditarPerfilViewModel : BaseViewModel
    {

        public EditarPerfilViewModel()
        {

        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellidos;

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _passwordconfirm;

        public string Passwordconfirm
        {
            get { return _passwordconfirm; }
            set { _passwordconfirm = value; }
        }


        private ICommand _actualizardatos;

        public ICommand Actualizardatos
        {
            get
            {
                if (_actualizardatos == null)
                    _actualizardatos = new RelayCommand(new Action(actualizar));
                return _actualizardatos;
            }
        }

        private ICommand _cambiarfoto;

        public ICommand Cambiarfoto
        {
            get
            {
                if (_cambiarfoto == null)
                    _cambiarfoto = new RelayCommand(new Action(cambiarfoto));
                return _cambiarfoto;
            }
        }


        private void cambiarfoto()
        {
            //falta crear la ruta para guardar la imagen en un directorio del projecto y que guarde la url en la base de datos
            OpenFileDialog op = new OpenFileDialog();
            

          



            

        }




        public void actualizar()
        {

            if (Password == Passwordconfirm)
            {
                using (var db = new ContextoBBDD())
                {

                    var result = db.Usuarios.FirstOrDefault(x => x.Id == UserLoginCache.Id);
                    if (result != null)
                    {
                        result.Nombre = Nombre;
                        result.Apellidos = Apellidos;
                        result.UserName = Username;
                        result.Password = Password;
                        db.SaveChanges();
                    }

                }

            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }

           
        }



    }
}
