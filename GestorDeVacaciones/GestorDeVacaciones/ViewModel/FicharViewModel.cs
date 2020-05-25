using GestorDeVacaciones.Core;
using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.Cache;
using GestorDeVacaciones.Model.ClasesAnonimas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestorDeVacaciones.ViewModel
{
    public class FicharViewModel : BaseViewModel
    {
        private FicharModel fichaje;
        private HorariosModel horario;


        public FicharViewModel()
        {
            using (var db = new ContextoBBDD())
            {
                var listUsers = db.Usuarios.ToList();
                var listaAnonima = (from usuario in db.Usuarios
                                    join fichaje in db.Fichar on usuario.Id equals fichaje.UserID
                                    join warning in db.Warning on fichaje.warning equals warning.ID
                                    select new DataGridFichajes
                                    {

                                        Nombre = usuario.Nombre + " " + usuario.Apellidos,
                                        Dia = fichaje.dia,
                                        Entrada1 = fichaje.entrada1,
                                        Salida1 = fichaje.salida1,
                                        Entrada2 = fichaje.entrada2,
                                        Salida2 = fichaje.salida2,
                                        Warning = warning.descripcion



                                    }).ToList();




                ListaDeDias = listaAnonima.ToList();
            }
        }

        private IList<DataGridFichajes> _listadedias;

        public IList<DataGridFichajes> ListaDeDias
        {
            get => _listadedias;
            set
            {
                _listadedias = value;
                OnPropertyChanged("ListaDeDias");
            }
        }
        private ICommand _registrarEntrada;
        public ICommand RegistrarEntrada
        {
            get
            {
                if (_registrarEntrada == null)
                    _registrarEntrada = new RelayCommand(new Action(introducirEntrada));
                return _registrarEntrada;
            }
        }
        private void introducirEntrada()
        {
            comprobarRegistroAnterior();
            using (var db = new ContextoBBDD())
            {
                fichaje = db.Fichar.Where(x => x.UserID == UserLoginCache.Id && x.dia == DateTime.Today).FirstOrDefault();
                horario = db.Horarios.Where(x=> x.ID == fichaje.horarioID).FirstOrDefault();
                if (fichaje.entrada1.TotalMilliseconds == 0)
                {
                    fichaje.entrada1 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);
                    if (fichaje.entrada1.TotalSeconds > horario.entrada1.TotalSeconds)
                    {
                        fichaje.warning = 2;
                    }
                }
                else if (fichaje.entrada2.TotalSeconds == 0)
                {
                    fichaje.entrada2 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);
                    if (fichaje.entrada2.TotalSeconds > horario.entrada2.TotalSeconds)
                    {
                        fichaje.warning = 2;
                    }
                }
                db.SaveChanges();


            }

        }

        private ICommand _registrarSalida;
        public ICommand RegistrarSalida
        {
            get
            {
                if (_registrarSalida == null)
                    _registrarSalida = new RelayCommand(new Action(introducirSalida));
                return _registrarSalida;
            }
        }
        private void introducirSalida()
        {
            using (var db = new ContextoBBDD())
            {

                fichaje = db.Fichar.Where(x => x.UserID == UserLoginCache.Id && x.dia == DateTime.Today).FirstOrDefault();
                horario = db.Horarios.Where(x => x.ID == fichaje.horarioID).FirstOrDefault();
                if (fichaje.salida1.TotalSeconds == 0)
                {
                    fichaje.salida1 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);

                }
                else if (fichaje.salida2.TotalSeconds == 0 && horario.jornadaCompleta)
                {
                    fichaje.salida2 = new TimeSpan(DateTime.Now.Ticks - DateTime.Today.Ticks);
                }
                db.SaveChanges();


            }

        }

        

        private void comprobarRegistroAnterior()
        {
            using (var db = new ContextoBBDD())
            {
                DateTime d = DateTime.Today.AddDays(-1);
                FicharModel fichajeAyer = db.Fichar.Where(x => x.UserID == UserLoginCache.Id && x.dia == d).FirstOrDefault();
                if (fichajeAyer == null) return;
                if ((fichajeAyer.salida1 - fichajeAyer.entrada1) + (fichajeAyer.salida2 - fichajeAyer.entrada2) > new TimeSpan(8, 0, 0)) fichajeAyer.warning = 3;
                else if (fichajeAyer.entrada1.TotalMilliseconds == 0 || fichajeAyer.salida1.TotalMilliseconds == 0 || fichajeAyer.entrada2.TotalMilliseconds == 0 || fichajeAyer.salida2.TotalMilliseconds == 0)
                    fichajeAyer.warning = 4;
                db.SaveChanges();
            }
        }

    }
}
