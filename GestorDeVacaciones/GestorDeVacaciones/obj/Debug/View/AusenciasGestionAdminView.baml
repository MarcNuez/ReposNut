   M S B A M L   `   `   `  ����M  IGestorDeVacaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:GestorDeVacaciones.ViewModelGestorDeVacaciones.ViewModel  5      A%clr-namespace:GestorDeVacaciones.ViewGestorDeVacaciones.View  5   	   7    1GestorDeVacaciones.View.AusenciasGestionAdminView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9vm*clr-namespace:GestorDeVacaciones.ViewModel     5      7local%clr-namespace:GestorDeVacaciones.View     5   	     � Title$  AusenciasGestionAdminView��5
   	   $��497.369��6+   $��574.377��6<    � 	Resources 5      A   ;GestorDeVacaciones.ViewModel.AusenciasGestionAdminViewModel   gestorVM��%   &	          5   
   6,   5      .��5      �  � DataContext# [  6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   $��40,126,103,31q�6c      AlternatingRowBackground
 �����   CanUserReorderColumns .  ��6   �� *ListaDeDias+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6G   �� *NombreCompleto+  5      $ Estado��6%   	 . 
 6G   �� *Estado+  5      $
 Dias��6%   	 . 
 6E   �� *Dias+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Aprobar��6)      CellTemplate 5      �� 5      .R�5      �� 
����� �$��50��6E   $��0q�6P   .��5   "   �� $��/Recursos/verif.png��6(   $��20��6E   $��20��6P   5      5      5        5      $ Denegar��6)    5       �� 5!      .R�5"      �� 
����p��$��50��6@   $��0q�6K   .��5#   "   �� $��/Recursos/cerrar.png��6(   $��20��6F   $��20��6Q   5$      5%      5'      5)      �� 5*   
   $
��Left=�6   $��23��6-   $��	40,78,0,0q�69    �� TextWrapping$
 Wrap=�6L   $�� ��6`   $	��Top=�6h   $	��264��6�   �� 5+   
   $��Buscar por nombre: ��6   $
��Left=�6.   $��	40,54,0,0q�6I   $	��Top=�6\   �� 5,   
   $
��Left=�6   $��
328,73,0,0q�6.   $	��Top=�6B   $	��135��6Z   5-      5.      