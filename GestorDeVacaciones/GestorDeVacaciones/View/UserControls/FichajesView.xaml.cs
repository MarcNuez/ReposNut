using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorDeVacaciones.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para FichajesView.xaml
    /// </summary>
    public partial class FichajesView : UserControl
    {
        ContextoBBDD db = new ContextoBBDD();
        public FichajesView()
        {
            InitializeComponent();
            cargarCombobox();
            mostrarRegistros();
        }

        private void cmb_usuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void mostrarRegistros()
        {
            
            gdv_marcajes.DataContext = db.Fichar.ToArray();

        }
        private void cargarCombobox()
        {
            List<UserModel> users = db.Usuarios.ToList();
            cmb_usuarios.ItemsSource = users;
            cmb_usuarios.DisplayMemberPath = "Name";
            cmb_usuarios.SelectedValuePath = "ID";
        }

    }
}
