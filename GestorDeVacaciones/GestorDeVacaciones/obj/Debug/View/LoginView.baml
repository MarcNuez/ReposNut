   M S B A M L   `   `   `  ����M  IGestorDeVacaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:GestorDeVacaciones.ViewGestorDeVacaciones.View  5   	   K*clr-namespace:GestorDeVacaciones.ViewModelGestorDeVacaciones.ViewModel  5   	   '    !GestorDeVacaciones.View.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:GestorDeVacaciones.View     5   	   9vm*clr-namespace:GestorDeVacaciones.ViewModel     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	LoginView��5
   	   $	��500��6   $	��350��6(    � WindowStartupLocation$ CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y    � 	Resources 5      1   +GestorDeVacaciones.ViewModel.LoginViewModel 	  LogVM��%   &	          5   
   6   5      .��5      �  � DataContext# [  6   .+�5   
   �� $
��Left=�6   $	��293��6/   $	��Top=�6<   $	��342��6T   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FF448ADE��6#   	 � Offset$	 0.204Q�65   � 5      $ 	#FF2D0D87��6#   $	 0.657Q�65   5      5      �� 5   
   $��Center=�6   $	��100��6-   $	��Top=�6:   $	��100��6R   $��72,28,170,0q�6^   
 J� OpacityMask
 5      �� 5      5      �� 5    
   $��Center=�6   $	��217��61   $��	0,164,0,0q�6>   $	��Top=�6Q   $	��251��6i   
������� �� RadiusY$ 14.82��6�    �� RadiusX$ 14.82��6�    J� Effect 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"         Opacity$	 0.8Q�6#      	Direction$ 0Q�61      
BlurRadius$ 10Q�6?      Color$ 	#FF787272��6O   5$      � 5%   
   $
��Left=�6   $	��217��6*   $��
46,164,0,0q�67   $	��Top=�6K   $	��250��6c   .+�5&      �� $��Login��6   $��Center=�6%   $��0,10,0,0q�6B   $
��Wrap=�6T   $	��Top=�6h   $��16(�6�   ���	#FF5959596�   �� 5'      $
��Left=�6   $	��143��64   $��
10,48,0,26q�6A   $��Center=�6U   $	��230��6p   .+�5(      �� -   5         ��Name$ 
txtUsuario��5(      $
��0,10q�6.   $��Champagne & Limousines)�6=   $��18(�6e   G� 5)      -   5         G�Name$ txtContraseña��5)      $
��0,10q�65   $��Champagne & Limousines)�6C   $��18(�6k   5*      5+      �� 5,   
   -   5        $��Login��5,      $��Center=�6/   $��94,361,94,0q�6L   $	��Top=�6a   $	��154��6y   $��42��6�   $��18(�6�   $��Champagne &)�6�   �� 5-   
   $!��¿Olvidaste la contraseña?��6   $��Center=�66   $��	0,429,0,0q�6S   $
��Wrap=�6f   $	��Top=�6z   ���	#FF8B8B8B6�   5/      50      