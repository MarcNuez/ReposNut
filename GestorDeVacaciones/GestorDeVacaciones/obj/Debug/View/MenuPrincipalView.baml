   M S B A M L   `   `   `  ����M  IGestorDeVacaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GestorDeVacaciones.ViewGestorDeVacaciones.View  5   	   [2clr-namespace:GestorDeVacaciones.View.UserControls$GestorDeVacaciones.View.UserControls  5   	   K*clr-namespace:GestorDeVacaciones.ViewModelGestorDeVacaciones.ViewModel  5   	   M+clr-namespace:GestorDeVacaciones.ConvertersGestorDeVacaciones.Converters  5	   	   /    )GestorDeVacaciones.View.MenuPrincipalView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:GestorDeVacaciones.View     5   	   Aus2clr-namespace:GestorDeVacaciones.View.UserControls     5   	   9vm*clr-namespace:GestorDeVacaciones.ViewModel     5   	   >conver+clr-namespace:GestorDeVacaciones.Converters     5	   	     � Title$  MenuPrincipalView��5   	   $	��800��6#   $
��1200��60    � WindowStartupLocation$ CenterScreen=�6=    � 	Resources 5       �� DataType5   /GestorDeVacaciones.ViewModel.AusenciasViewModel8   2GestorDeVacaciones.View.UserControls.AusenciasView6   0GestorDeVacaciones.ViewModel.VacacionesViewModel9   3GestorDeVacaciones.View.UserControls.VacacionesView7   1GestorDeVacaciones.ViewModel.GestorAdminViewModel:   4GestorDeVacaciones.View.UserControls.GestorAdminView2   ,GestorDeVacaciones.ViewModel.FicharViewModel5   /GestorDeVacaciones.View.UserControls.FicharView4	   .GestorDeVacaciones.ViewModel.FichajesViewModel7
   1GestorDeVacaciones.View.UserControls.FichajesView4   .GestorDeVacaciones.ViewModel.HorariosViewModel7   1GestorDeVacaciones.View.UserControls.HorariosView9   3GestorDeVacaciones.ViewModel.MenuPrincipalViewModel 
  menuVM7   1GestorDeVacaciones.Converters.ImagenNullConverter  converterimagen��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� �     5      *, +)&	  ,    &	 ?    �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " 	 6   .R�5      
  5      �� 5   
   "  6   .R�5        5         5"   
   6$     5#   
   6%   5$      .��5-      � $��0,0,0,0q�6    � DataContext# [  6   .+�5.   
   � $��45��6   $	��Top=�6   ���	#FF0672F3$��	211,0,0,0q�6J   .+�5/      �� $
��Left=�6   $
��Wrap=�63   $��	TextBlock��6G   $��Center=�6X   $��
33,15,0,15q�6s   50      � 51   
   $
��Left=�6   $	��211��6*   ���	#FF0672F3.+�52      A� $	��126��6   $	��127��6#   $��
42,15,42,0q�6/   $��Center=�6C   $	��Top=�6`   ���	#FF080707 J� Effect 53      3  -System.Windows.Media.Effects.DropShadowEffect  54         	Direction$	 285Q�6'      
BlurRadius$ 27Q�67      Color$ 	#FF59594C��6G   ��56      �� 57      	 j� Stretch$
	 Fill=�6n   
 �� ImageSource
 6!   �� *
UrlImage+ �� 	Converter# [ 6n   59      �� 5:      -   5         ��Name$	 lol��5:      $��Center=�6%   $��	0,158,0,0q�6B   $
��Wrap=�6U   $	��Top=�6�   $��80��6�   ��6i   �� *Nombre+6�   �� 5;      $��Center=�6   $��66,210,65,0q�65   $
��Wrap=�6J   $	��Top=�6s   $��80��6�   ��6^   �� *Rol+6�   �� 5?      $
��Left=�6   $	��385��64   $��
10,258,0,0q�6A   $	��Top=�6U   $	��201��6m   .+�5B      �� $��VacacionesView��6A   $��
Vacaciones��6c   $��62��6x   ���	#FF0672F3
�������$
��Left=�6�   $��20,1,1,1q�6�   ��6   �� *AbrirVentanaCommand+��6�   Z� 6�   �� 5C      $��AusenciasView��6A   $��	Ausencias��6b   $��62��6v   ���	#FF0672F3
�������$
��Left=�6�   $��20,1,1,1q�6�   ��6   �� *AbrirVentanaCommand+��6�   Z� 6�   �� 5D      $��
FicharView��6A   $��Fichar��6`   $��62��6q   ���	#FF0672F3
�������$
��Left=�6�   $��20,1,1,1q�6�   ��6   �� *AbrirVentanaCommand+��6�   Z� 6�   �� 5E      $��FichajesView��6A   $��Fichajes��6b   $��62��6u   ���	#FF0672F3
�������$
��Left=�6�   $��20,1,1,1q�6�   ��6   �� *AbrirVentanaCommand+��6�   Z� 6�   �� 5F      $��HorariosView��6A   $��Horarios��6b   $��62��6u   ���	#FF0672F3
�������$
��Left=�6�   $��20,1,1,1q�6�   ��6   �� *AbrirVentanaCommand+��6�   Z� 6�   �� 5G      $��GestorAdminView��6A   $��Gestion Admin��6d   $��62��6|   ���	#FF0672F3
�������$
��Left=�6�   $��20,1,1,1q�6�   ��6   �� *AbrirVentanaCommand+��6�   Z� 6�   5I      5K      � 5L   
   $��30��6   $��Bottom=�6   ���	#FF80E8FF$��	211,0,0,0q�6M   �� 5M   
   $��Stretch=�6?   $��Stretch=�6d   $��211,45,0,30q�6�   ��6   �� *VistaSeleccionada+6�   5N      5O      