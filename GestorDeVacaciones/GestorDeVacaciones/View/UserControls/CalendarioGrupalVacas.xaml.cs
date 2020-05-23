using GestorDeVacaciones.Data;
using GestorDeVacaciones.Model;
using GestorDeVacaciones.Model.ClasesAnonimas;
using GestorDeVacaciones.View.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Lógica de interacción para CalendarioGrupalVacas.xaml
    /// </summary>
    public partial class CalendarioGrupalVacas : UserControl
    {

        #region variables
        public int MesSeleccionado { get; set; }
        public int AñoSeleccionado { get; set; }
        public List<DiasElegidosModel> ListaSeleccionados { get; set; } = new List<DiasElegidosModel>();
        public List<UserModel> ListaUsuarios { get; set; } = new List<UserModel>();
        public List<Brush> PaletaColores { get; set; } = new List<Brush>() {
        Brushes.Red,Brushes.Blue,Brushes.DodgerBlue,Brushes.YellowGreen,Brushes.OrangeRed,Brushes.BurlyWood,Brushes.Purple,Brushes.Yellow,Brushes.Green,Brushes.Brown,Brushes.Pink,Brushes.Aquamarine};


        public List<DiasElegidosModel> ListaDiasVacasElegidos { get; set; } = new List<DiasElegidosModel>();

        private DateTimeFormatInfo formatDate;
        private CultureInfo es;
        private TextInfo inf;
        private int diasTieneElMes;

        Brush brushAzulSelect = (Brush)new BrushConverter().ConvertFrom("#135CBD");
        Brush brushAzulNoSelect = (Brush)new BrushConverter().ConvertFrom("#1CA5F1");

        #endregion
        public CalendarioGrupalVacas()
        {


            InitializeComponent();
            es = new CultureInfo("Es-Es");
            inf = es.TextInfo;
            formatDate = es.DateTimeFormat;

            MesSeleccionado = DateTime.Now.Month;
            AñoSeleccionado = DateTime.Now.Year;





            cargarGrid();


        }


        #region cargar el grid
        private void cargarGrid()
        {
            ListaSeleccionados.Clear();
            lagrid.Children.Clear();

            cargarDatosDelContexto();
            cargarCabecera();
            cargarUsuarios();
            cargarFilaContadorCoincidencias();


        }





        private void cargarDatosDelContexto()
        {
            using (var db = new ContextoBBDD())
            {
                //cargamos usuarios
                var listausuarios = db.Usuarios.ToList();
                ListaUsuarios = listausuarios;


                //cargamos dias Elegidos de vacas

                var listadiasvacas = db.DiasElegidos.ToList();
                ListaDiasVacasElegidos = listadiasvacas;


            }


        }

        private void cargarFilaContadorCoincidencias()
        {
            if (lagrid.RowDefinitions.Count <= ListaUsuarios.Count + 1)
            {

                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(35, GridUnitType.Pixel);
                lagrid.RowDefinitions.Add(rd);

            }

            for (int i = 1; i <= diasTieneElMes; i++)
            {

                TextBlock txtNum = new TextBlock();

                var cont = 0;

                //cuenta toda la columna si hay coincidencias

                foreach (var d in ListaDiasVacasElegidos)
                {
                    if (d.Dia == i && d.Mes == MesSeleccionado && d.Año == AñoSeleccionado)
                    {
                        cont++;
                    }
                }



                txtNum.Text = cont.ToString();
                txtNum.HorizontalAlignment = HorizontalAlignment.Stretch;
                txtNum.VerticalAlignment = VerticalAlignment.Stretch;
                txtNum.TextAlignment = TextAlignment.Center;
                txtNum.Foreground = Brushes.White;
                txtNum.Padding = new Thickness(0,10,0,0);


                txtNum.Background = cont > 0 ? Brushes.Red : Brushes.DodgerBlue;



                Grid.SetColumn(txtNum, i);
                Grid.SetRow(txtNum, lagrid.RowDefinitions.Count);

                lagrid.Children.Add(txtNum);



            }
        }

        private void cargarCabecera()
        {
            int col = 1;
            int row = 0;
            diasTieneElMes = DateTime.DaysInMonth(AñoSeleccionado, MesSeleccionado);



            DockPanel dock = new DockPanel();
            Button btna = new Button();
            Button btnb = new Button();
            TextBlock txt = new TextBlock();

            btna.Content = "<";
            btna.Width = 20;
            btna.Height = 30;
            btna.Name = "btnAtras";
            btna.Margin = new Thickness(10, 0, 0, 0);
            btna.Click += mesAtras;

            btnb.Content = ">";
            btnb.Width = 20;
            btnb.Height = 30;
            btnb.Name = "btnAdelante";
            btnb.Margin = new Thickness(0, 0, 10, 0);
            btnb.Click += mesAdelante;

            txt.Name = "txtMes";
            txt.Text = inf.ToTitleCase(formatDate.GetMonthName(MesSeleccionado)) + " " + AñoSeleccionado.ToString();

            txt.HorizontalAlignment = HorizontalAlignment.Center;
            txt.VerticalAlignment = VerticalAlignment.Center;

            dock.LastChildFill = true;
            dock.Background = Brushes.DodgerBlue;
            DockPanel.SetDock(btna, Dock.Left);
            DockPanel.SetDock(btnb, Dock.Right);
            dock.Children.Add(btna);
            dock.Children.Add(btnb);
            dock.Children.Add(txt);

            Grid.SetColumn(dock, 0);
            Grid.SetRow(dock, 0);

            lagrid.Children.Add(dock);


            for (int i = 1; i <= diasTieneElMes; i++)
            {
                StackPanel st = new StackPanel();
                TextBlock txtNum = new TextBlock();
                TextBlock txtDia = new TextBlock();

                txtNum.Text = i.ToString();
                txtNum.HorizontalAlignment = HorizontalAlignment.Center;
                txtNum.VerticalAlignment = VerticalAlignment.Center;
                txtDia.Text = cargarCabeceraDiasSemana(i);
                txtDia.HorizontalAlignment = HorizontalAlignment.Center;
                txtDia.VerticalAlignment = VerticalAlignment.Center;





                st.Children.Add(txtNum);
                st.Children.Add(txtDia);
                st.HorizontalAlignment = HorizontalAlignment.Stretch;
                st.VerticalAlignment = VerticalAlignment.Stretch;
                st.Background = Brushes.DodgerBlue;

                Grid.SetColumn(st, col);
                Grid.SetRow(st, row);

                lagrid.Children.Add(st);

                col++;


            }
        }



        public string cargarCabeceraDiasSemana(int dia)
        {
            var dt = new DateTime(AñoSeleccionado, MesSeleccionado, dia);
            var diaSemana = dt.ToString("dddd");
            var letraDia = "";
            switch (diaSemana)
            {
                case "lunes":
                    letraDia = "L";
                    break;
                case "martes":
                    letraDia = "M";
                    break;
                case "miércoles":
                    letraDia = "X";
                    break;
                case "jueves":
                    letraDia = "J";
                    break;
                case "viernes":
                    letraDia = "V";
                    break;
                case "sábado":
                    letraDia = "S";
                    break;
                case "domingo":
                    letraDia = "D";
                    break;
            }
            return letraDia;
        }


        public void cargarUsuarios()
        {

            int col = 0;
            int row = 1;
            Random rnd = new Random();

            foreach (var u in ListaUsuarios)
            {
                StackPanel st = new StackPanel();
                Border bord = new Border();
                TextBlock txtBord = new TextBlock();
                TextBlock nombre = new TextBlock();

                //definimos las propiedades del circulo
                bord.Width = 20;
                bord.Height = 20;

                bord.Background = PaletaColores[rnd.Next(PaletaColores.Count)];
                bord.CornerRadius = new CornerRadius(10, 10, 10, 10);

                //texto interior circulo
                txtBord.Text = u.Nombre.Substring(0, 1) + u.Apellidos.Substring(0, 1);
                txtBord.VerticalAlignment = VerticalAlignment.Center;
                txtBord.HorizontalAlignment = HorizontalAlignment.Center;
                txtBord.Foreground = Brushes.White;

                //añadimos texto al circulo
                bord.Child = txtBord;

                //definimos el nombre del usuario que va a la derecha
                nombre.Text = u.Nombre + " " + u.Apellidos;
                nombre.HorizontalAlignment = HorizontalAlignment.Center;
                nombre.VerticalAlignment = VerticalAlignment.Center;
                nombre.Margin = new Thickness(30, 0, 0, 0);

                //propiedades del stackpanel contenedor de la ellipse y el nombre
                st.Orientation = Orientation.Horizontal;
                st.Children.Add(bord);
                st.Children.Add(nombre);
                st.HorizontalAlignment = HorizontalAlignment.Center;



                //a que fila y columna va el stackpanel
                Grid.SetRow(st, row);
                Grid.SetColumn(st, col);



                //se crean las columna grises de sabado y domingo
                for (int i = 1; i < diasTieneElMes; i++)
                {
                    TextBlock tx = new TextBlock();

                    if (cargarCabeceraDiasSemana(i) == "S" || cargarCabeceraDiasSemana(i) == "D")
                    {

                        tx.Background = Brushes.LightGray;
                        tx.HorizontalAlignment = HorizontalAlignment.Stretch;
                        tx.VerticalAlignment = VerticalAlignment.Stretch;
                        Grid.SetColumn(tx, i);
                        Grid.SetRow(tx, row);
                        lagrid.Children.Add(tx);
                    }
                    else
                    {
                        tx.Background = Brushes.White;
                        tx.HorizontalAlignment = HorizontalAlignment.Stretch;
                        tx.VerticalAlignment = VerticalAlignment.Stretch;
                        Grid.SetColumn(tx, i);
                        Grid.SetRow(tx, row);
                        lagrid.Children.Add(tx);
                    }
                }



                //se crean los dias que ha elegido de vacaciones
                foreach (var l in ListaDiasVacasElegidos)
                {

                    if (l.Mes == MesSeleccionado && l.Año == AñoSeleccionado && l.UserModelId == u.Id && l.Denegado != true)
                    {

                        TextBlock tx = new TextBlock();
                        Border brd = new Border();


                        tx.MouseRightButtonUp += click_diaVacaciones;
                        tx.MouseEnter += arrastraryseleccionar;
                        tx.MouseLeftButtonDown += primerclick;

                        tx.Background = l.Aprobado == false ? brushAzulNoSelect : Brushes.Green;

                        tx.HorizontalAlignment = HorizontalAlignment.Stretch;
                        tx.VerticalAlignment = VerticalAlignment.Stretch;

                        brd.BorderBrush = Brushes.White;
                        brd.BorderThickness = new Thickness(0.5);
                        brd.Child = tx;

                        Grid.SetColumn(brd, l.Dia);
                        Grid.SetRow(brd, row);
                        lagrid.Children.Add(brd);
                    }

                }

                row++;


                //añadimos al grid el stackpanel
                lagrid.Children.Add(st);




                //creamos una fila mas para el siguiente usuario 
                if (lagrid.RowDefinitions.Count <= ListaUsuarios.Count)
                {
                    RowDefinition rd = new RowDefinition();

                    rd.Height = new GridLength(25, GridUnitType.Pixel);
                    lagrid.RowDefinitions.Add(rd);
                }


            }

        }
        #endregion

        #region metodos auxiliares
        //devuelve la fila y la columna en la cual se encuentra el textbloc del dia elegido
        public int localizarDia(object sender)
        {

            //como el textblock esta dentro de un border, necesitamos saber ese border en que celda de la grid esta
            var r = Grid.GetRow((UIElement)((TextBlock)sender).Parent);
            var c = Grid.GetColumn((UIElement)((TextBlock)sender).Parent);

            return c;

        }


        //obtiene del nombre completo el id usuario
        private int obtenerIdUsuario(string usuario)
        {
            var longi = usuario.Length;
            var nombre = usuario.Substring(0, usuario.IndexOf(" "));
            var apellidos = usuario.Substring(nombre.Length, longi - nombre.Length);
            var num = 0;

            using (var db = new ContextoBBDD())
            {
                num = db.Usuarios.Where(x => x.Nombre == nombre && x.Apellidos == apellidos.Trim())
                    .Select(x => x.Id).FirstOrDefault();

            }


            return num;
        }


        public UserModel obtenerUsuario(object sender)
        {
            var l = Grid.GetRow((UIElement)((TextBlock)sender).Parent);
            var c = Grid.GetColumn((UIElement)((TextBlock)sender).Parent);

            //localiza el stackpanel de la celda col=0 fila= la que clickes
            var stac = lagrid.Children
       .Cast<UIElement>()
       .First(es => Grid.GetRow(es) == l && Grid.GetColumn(es) == 0);

            //localiza dentro del stackpanel el elemento hijo que sea un textblock
            TextBlock textbl = ((StackPanel)stac).Children.OfType<TextBlock>().LastOrDefault();

            UserModel us = null;
            using (var db = new ContextoBBDD())
            {
                var num = obtenerIdUsuario(textbl.Text);


                us = db.Usuarios.Where(x => x.Id == num).FirstOrDefault();
            }

            return us;
        }
        #endregion


        #region metodos accion
        private void primerclick(object sender, MouseEventArgs e)
        {

            var user = obtenerUsuario(sender);
            var c = Grid.GetColumn((UIElement)((TextBlock)sender).Parent);

            var newdiaelegido = new DiasElegidosModel()
            {
                Usuario = user,
                UserModelId = obtenerIdUsuario(user.Nombre + " " + user.Apellidos),
                Dia = c,
                Mes = MesSeleccionado,
                Año = AñoSeleccionado,
                Aprobado = false
            };



            // #FF087B95 color seleccionado
            // #FF5CD9F5 color sin seleccionar
            if (((TextBlock)sender).Background != Brushes.Green)
            {
                if (((TextBlock)sender).Background == brushAzulSelect)
                {
                    ((TextBlock)sender).Background = brushAzulNoSelect;


                    ListaSeleccionados.Remove(newdiaelegido);
                }
                else
                {
                    ((TextBlock)sender).Background = brushAzulSelect;
                    ListaSeleccionados.Add(newdiaelegido);
                }

            }

        }


        private void arrastraryseleccionar(object sender, MouseEventArgs e)
        {
            var user = obtenerUsuario(sender);
            var c = Grid.GetColumn((UIElement)((TextBlock)sender).Parent);

            var newdiaelegido = new DiasElegidosModel()
            {
                Usuario = user,
                UserModelId = obtenerIdUsuario(user.Nombre + " " + user.Apellidos),
                Dia = c,
                Mes = MesSeleccionado,
                Año = AñoSeleccionado,
                Aprobado = false
            };


            if (((TextBlock)sender).Background != Brushes.Green)
            {

                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    if (((TextBlock)sender).Background == brushAzulSelect)
                    {
                        ((TextBlock)sender).Background = brushAzulNoSelect;
                        ListaSeleccionados.Remove(newdiaelegido);


                    }
                    else
                    {
                        ((TextBlock)sender).Background = brushAzulSelect;
                        ListaSeleccionados.Add(newdiaelegido);


                    }

                }

            }


        }








        private void click_diaVacaciones(object sender, MouseButtonEventArgs e)
        {

            var user = obtenerUsuario(sender);
            var c = Grid.GetColumn((UIElement)((TextBlock)sender).Parent);

            DiasElegidosModel diaElegidoAPasar = new DiasElegidosModel()
            {
                Usuario = user,
                UserModelId = obtenerIdUsuario(user.Nombre + " " + user.Apellidos),
                Dia = c,
                Mes = MesSeleccionado,
                Año = AñoSeleccionado,
                Aprobado = false


            };

            //si es de color verde se abrira una ventana dialog para rechazar el dia que 
            //previamente habia sido aceptado sino se abrira un dialog de aceptar-denegar
            if (((TextBlock)sender).Background == Brushes.Green)
            {
                DialogGARetirarAprobada dgara = new DialogGARetirarAprobada(diaElegidoAPasar);
                dgara.WindowStartupLocation = WindowStartupLocation.Manual;
                dgara.Left = PointToScreen(Mouse.GetPosition(null)).X;
                dgara.Top = PointToScreen(Mouse.GetPosition(null)).Y;
                dgara.ShowDialog();
                cargarGrid();

            }
            else
            {
                DialogGestionAdminAprobarDenegar em = new DialogGestionAdminAprobarDenegar(diaElegidoAPasar);
                em.WindowStartupLocation = WindowStartupLocation.Manual;
                em.Left = PointToScreen(Mouse.GetPosition(null)).X;
                em.Top = PointToScreen(Mouse.GetPosition(null)).Y;
                em.ShowDialog();
                cargarGrid();


            }



        }


        private void mesAdelante(object sender, RoutedEventArgs e)
        {
            if (MesSeleccionado == 12)
            {
                MesSeleccionado = 1;
                AñoSeleccionado++;
            }
            else
            {
                MesSeleccionado++;

            }

            cargarGrid();

        }

        private void mesAtras(object sender, RoutedEventArgs e)
        {
            if (MesSeleccionado == 1)
            {
                MesSeleccionado = 12;
                AñoSeleccionado--;
            }
            else
            {
                MesSeleccionado--;

            }

            cargarGrid();
        }

        private void btnTodas_Click(object sender, RoutedEventArgs e)
        {
            if (ListaSeleccionados.Count == 0)
            {
                MessageBox.Show("No has seleccionado ningun dia");
                return;
            }
            var str = "Has seleccionado estos dias: \n";

            foreach (var s in ListaSeleccionados)
            {

                str += s.diaFormato + " " + s.Usuario.Nombre + " " + s.Usuario.Apellidos + "\n";

                using (var db = new ContextoBBDD())
                {
                    var result = db.DiasElegidos.SingleOrDefault(x => x.UserModelId == s.UserModelId
               && x.Dia == s.Dia && x.Mes == s.Mes && x.Año == s.Año);
                    if (result != null)
                    {
                        result.Aprobado = true;
                        db.SaveChanges();
                    }
                }



            }

            MessageBox.Show(str);
            cargarGrid();

        }
    }

    #endregion



}
