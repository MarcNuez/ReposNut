using GestorDeVacaciones.Core;
using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.ClasesAnonimas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestorDeVacaciones.ViewModel
{
    public class HorariosViewModel : BaseViewModel
    {
        public HorariosViewModel()
        {
            using (var db = new ContextoBBDD())
            {
                var listUsers = db.Usuarios.ToList();
                var listaAnonima = (from h in db.Horarios
                                    select new DataGridHorarios
                                    {

                                        nombre=h.nombre,
                                        entrada1=h.entrada1,
                                        salida1=h.salida1,
                                        entrada2=h.entrada2,
                                        salida2=h.salida2,
                                        lunes=h.lunes? "✓":"X",
                                        martes=h.martes ? "✓" : "X",
                                        miercoles =h.miercoles ? "✓" : "X",
                                        jueves =h.jueves ? "✓" : "X",
                                        viernes =h.viernes ? "✓" : "X",
                                        sabado =h.sabado ? "✓" : "X",
                                        domingo =h.domingo ? "✓" : "X",



                                    }).ToList();




                ListaDeHorarios = listaAnonima.ToList();
            }
        }

        private IList<DataGridHorarios> _listadehorarios;

        public IList<DataGridHorarios> ListaDeHorarios
        {
            get => _listadehorarios;
            set
            {
                _listadehorarios = value;
                OnPropertyChanged("ListaDeHorarios");
            }
        }



        private List<HorariosModel> _diferentesHorarios;
        public List<HorariosModel> DiferentesHorarios
        {
            get { return _diferentesHorarios; }
            set { _diferentesHorarios = value; OnPropertyChanged(nameof(DiferentesHorarios)); }
        }
        private HorariosModel _tipoSeleccionado;

        public HorariosModel TipoSeleccionado
        {
            get { return _tipoSeleccionado; }
            set { _tipoSeleccionado = value; OnPropertyChanged(nameof(TipoSeleccionado)); }

        }
        private ICommand _eliminarhorario;
        public ICommand EliminarHorario
        {
            get
            {
                if (_eliminarhorario == null)
                    _eliminarhorario = new RelayCommand(new Action(eliminarHorario));
                return _eliminarhorario;
            }
        }
        private void eliminarHorario()
        {
            using (var db = new ContextoBBDD())
            {
                
                // horario = db.Horarios.Where(x => x.ID == _eliminarhorario).FirstOrDefault();
                
                db.SaveChanges();


            }

        }
    }
}
