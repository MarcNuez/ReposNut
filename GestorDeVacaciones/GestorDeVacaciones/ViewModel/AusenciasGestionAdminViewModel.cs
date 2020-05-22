using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model.ClasesAnonimas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.ViewModel
{
    public class AusenciasGestionAdminViewModel : BaseViewModel
    {
        public ContextoBBDD db { get; } = new ContextoBBDD();

        public AusenciasGestionAdminViewModel()
        {
            var listaAnonima = (from usuario in db.Usuarios
                                join dias in db.DiasElegidos on usuario.Id equals dias.UserModelId
                                select new DataGridGestionAdmin
                                {

                                    NombreCompleto = usuario.Nombre + " " + usuario.Apellidos,
                                    Estado = dias.Aprobado,
                                    Dia = dias.Dia,
                                    Mes = dias.Mes,
                                    Año = dias.Año



                                }).ToList();



            ListaDeDias = listaAnonima.ToList();
        }

        private IList<DataGridGestionAdmin> _listadedias;

        public IList<DataGridGestionAdmin> ListaDeDias
        {
            get => _listadedias;
            set
            {
                _listadedias = value;
                OnPropertyChanged("ListaDeDias");
            }
        }
    }
}
