   M S B A M L   `   `   `  ����M  IGestorDeVacaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GestorDeVacaciones.ViewGestorDeVacaciones.View  5   	   K*clr-namespace:GestorDeVacaciones.ViewModelGestorDeVacaciones.ViewModel  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   7    1GestorDeVacaciones.View.UserControls.FichajesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:GestorDeVacaciones.View     5   	   9vm*clr-namespace:GestorDeVacaciones.ViewModel     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5	   	   
�������  � 	Resources  5      4   .GestorDeVacaciones.ViewModel.FichajesViewModel   fVM��%   &	          5   
   6   5      .��5      � $��0,0,0,0q�6    � DataContext# [  6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ calDesde��5   8   $
��Left=�6K   $��
391,94,0,0q�6f   $	��Top=�6z      SelectedDate 6   �� *	StartDate+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectedDateChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SeleccionarFecha+5      5        5   
   -   5        $ calHasta��5   6   $
��Left=�6I   $��
594,94,0,0q�6d   $	��Top=�6x    6   �� *	EndDate+ 5        5      $ SelectedDateChanged��6!   . 5         6,   �� *SeleccionarFecha+5       5"      �� 5#   
   $��Marcajes anteriores��6   $��26,30,657,390q�6.   �� 5$   
   $��Usuario:��6   $��30��6#   $��
529,30,0,0q�6/   $	��Top=�6C   $
��Left=�6[   $��52��6v   �� 5%   
   $��Desde:��6   $��24��6!   $��
344,93,0,0q�6-   $	��Top=�6A   $
��Left=�6Y   $��47��6t   �� 5&   
   $��Hasta:��6   $��24��6!   $��
548,94,0,0q�6-   $	��Top=�6A   $
��Left=�6Y   $��46��6t   �� 5'   
    �� 
IsEditable . 	 �� SelectedValuePath$	 Nombre��6%   
 �� DisplayMemberPath$

 Tipo��6�   $
��Left=�6�   $��
594,30,0,0q�6�   $	��Top=�6  $	��145��6'   �� SelectedValue 6@   �� *TipoSeleccionado.Nombre+ �� SelectedItem 6r   �� *TipoSeleccionado+��6�   �� *DiferentesUsuarios+6'  &   System.Windows.Controls.DataGrid  5(   
      AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   $��26,126,61,31q�6c      AlternatingRowBackground
 �����   CanUserReorderColumns .  ��6   �� *ListaDeDias+   Columns 5)      0	  *System.Windows.Controls.DataGridTextColumn	  5*      ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Nombre��6%    
  
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Nombre+	  5+      $	 Dia��6%    .  6D   �� *Dia+	  5,      $ Primera entrada��6%    .  6P   �� *
Entrada1+	  5-      $ Primera salida��6%    .  6O   �� *	Salida1+	  5.      $ Segunda entrada��6%    .  6P   �� *
Entrada2+	  5/      $ Segunda salida��6%    .  6O   �� *	Salida2+	  50      $ Warning��6%    .  6H   �� *	Warning+53      54      55      