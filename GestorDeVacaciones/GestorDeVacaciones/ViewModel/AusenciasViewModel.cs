using GestorDeVacaciones.Core;
using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestorDeVacaciones.ViewModel
{
    public class AusenciasViewModel : BaseViewModel
    {

        private List<TipoAusenciaModel> _tiposAusencias;
        public List<TipoAusenciaModel> TiposAusencias
        {
            get { return _tiposAusencias; }
            set { _tiposAusencias = value; OnPropertyChanged(nameof(TiposAusencias)); }
        }


        private TipoAusenciaModel _tipoSeleccionado;

        public TipoAusenciaModel TipoSeleccionado
        {
            get { return _tipoSeleccionado; }
            set { _tipoSeleccionado = value; OnPropertyChanged(nameof(TipoSeleccionado)); }
        }


        public AusenciasViewModel()
        {



            using (var db = new ContextoBBDD())
            {
                var listTiposAusencias = db.TiposAusencias.ToList();
                TiposAusencias = listTiposAusencias;
            }



        }



        private string _comentario;

        public string ComentarioTxt
        {
            get { return _comentario; }
            set { _comentario = value; }
        }








        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
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

        private string _diasAusentes;

        public string DiasAusentes
        {
            get { return _diasAusentes; }
            set
            {
                _diasAusentes = value;

                OnPropertyChanged("DiasAusentes");
            }
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

        private ICommand _enviarAusencia;
        public ICommand EnviarAusencia
        {
            get
            {
                if (_enviarAusencia == null)
                    _enviarAusencia = new RelayCommand(new Action(enviarAusencia));
                return _enviarAusencia;
            }
        }



        private void enviarAusencia()
        {

            using (var db = new ContextoBBDD())
            {

                var nuevaAusencia = new AusenciasModel()
                {
                    UserModelId = UserLoginCache.Id,
                    
                    TipoAusenciaModelId = TipoSeleccionado.Id,
                    FechaInicio = StartDate.Date,//con el date al final solo obtenemos la data sin horas
                    FechaFinal = EndDate.Date,
                    Comentario = ComentarioTxt


                };

                db.Ausencias.Add(nuevaAusencia);
                db.SaveChanges();


            }




        }

        private void calcular()
        {
            if (_startDate < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("La fecha de inicio no puede ser menor que la fecha de hoy");
                StartDate = DateTime.Now.Date;
                return;
            }

            if (_endDate < _startDate)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha de inicio");
            }
            else
            {
                var dias = (int)(_endDate - _startDate).TotalDays + 1;
                DiasAusentes = dias > 1 ? dias.ToString() + " Dias" : dias.ToString() + " Dia";
            }



        }

    }
}
