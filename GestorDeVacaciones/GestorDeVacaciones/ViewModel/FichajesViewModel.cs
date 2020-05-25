using GestorDeVacaciones.Core;
using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.ClasesAnonimas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GestorDeVacaciones.ViewModel
{
    public class FichajesViewModel : BaseViewModel
    {
        public FichajesViewModel()
        {
            using (var db = new ContextoBBDD())
            {
                var listUsers = db.Usuarios.ToList();
                DiferentesUsuarios = listUsers;
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

        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }



        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public List<FicharModel> MostrarFichajes()
        {
            List<FicharModel> fichajes;
            using (var db = new ContextoBBDD())
            {
                DateTime dStart = _startDate.AddDays(-1);
                DateTime dEnd = _endDate.AddDays(1);
                if(_tipoSeleccionado==null)
                    fichajes = db.Fichar.Where(x=> x.dia>dStart && x.dia<dEnd).ToList();
                else
                    fichajes = db.Fichar.Where(x => x.dia > dStart && x.dia < dEnd && x.UserID==_tipoSeleccionado.Id).ToList();
            }

            return fichajes;
        }

        private List<UserModel> _diferentesUsuarios;
        public List<UserModel> DiferentesUsuarios
        {
            get { return _diferentesUsuarios; }
            set { _diferentesUsuarios = value; OnPropertyChanged(nameof(DiferentesUsuarios)); }
        }
        private UserModel _tipoSeleccionado;

        public UserModel TipoSeleccionado
        {
            get { return _tipoSeleccionado; }
            set { _tipoSeleccionado = value; OnPropertyChanged(nameof(TipoSeleccionado)); }

        }
        private ICommand _selectDate;
        public ICommand SeleccionarFecha
        {
            get
            {
                if (_selectDate == null)
                    _selectDate = new RelayCommand(new Action(calcular));
                return _selectDate;
            }
        }
        private void calcular()
        {
            if (_startDate > DateTime.Today)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de hoy");
                StartDate = DateTime.Now.Date;
                return;
            }

            if (_endDate < _startDate)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha de inicio");
            }
        }
    }
}
