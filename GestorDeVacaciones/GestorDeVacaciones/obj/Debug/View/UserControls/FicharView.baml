   M S B A M L   `   `   `  ����M  IGestorDeVacaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GestorDeVacaciones.ViewGestorDeVacaciones.View  5   	   K*clr-namespace:GestorDeVacaciones.ViewModelGestorDeVacaciones.ViewModel  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   5    /GestorDeVacaciones.View.UserControls.FicharView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:GestorDeVacaciones.View     5   	   9vm*clr-namespace:GestorDeVacaciones.ViewModel     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5	   	   
�������  � 	Resources  5      2   ,GestorDeVacaciones.ViewModel.FicharViewModel   fVM��%   &	          5   
   6   5      .��5      �  � DataContext# [  6   .+�5   
   �� $��Últimos 10 marcajes��6   $��44,179,635,244q�6.   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   $��44,179,43,31q�6c      AlternatingRowBackground
 �����   CanUserReorderColumns .  ��6   �� *ListaDeDias+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6G   �� *Nombre+  5      $	 Dia��6%    . 	 6D   �� *Dia+  5      $ Primera entrada��6%    . 	 6P   �� *
Entrada1+  5      $ Primera salida��6%    . 	 6O   �� *	Salida1+  5      $ Segunda entrada��6%    . 	 6P   �� *
Entrada2+  5      $ Segunda salida��6%    . 	 6O   �� *	Salida2+  5      $ Warning��6%    . 	 6H   �� *	Warning+5      �� 5   
   -   5        
 ��Name$
 
btn_entrar��5      $��Entrada��6%   $
��Left=�67   $��
251,74,0,0q�6R   $	��Top=�6f   $	��121��6~   $��47��6�   ��6�   �� *RegistrarEntrada+6�   �� 5   
   -   5        $
 	btn_salir��5      $��Salida��6$   $
��Left=�65   $��
429,74,0,0q�6P   $	��Top=�6d   $	��121��6|   $��47��6�   ��6�   �� *RegistrarSalida+6�   5       5!      