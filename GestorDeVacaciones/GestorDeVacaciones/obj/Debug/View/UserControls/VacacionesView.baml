   M S B A M L   `   `   `  ����M  IGestorDeVacaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:GestorDeVacaciones.View.UserControls$GestorDeVacaciones.View.UserControls  5      9    3GestorDeVacaciones.View.UserControls.VacacionesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:GestorDeVacaciones.View.UserControls     5      
�������.��5      � .+�5   
   �� $��Dias pendientes:��6   $
��Left=�6+   $��	36,26,0,0q�6F   $	��Top=�6Y   �� 5   
   -   5        $�� ��5      $��	Solicitar��6   $��	64,0,0,43q�60   $��57��6C   $��Bottom=�6O   $
��Left=�6j   $	��172��6�   6�   �� 5   
   -   5          ��Name$  diasPendientes��5      $
��Left=�6V   $��
136,10,0,0q�6q   $	��Top=�6�   $��36(�6�   ��6(   �� *DiasQueQuedan+ �� Mode$ TwoWay=�6�   �� 5   
   
���   �$
��Left=�6!   $��4��6<   $��
138,54,0,0q�6G   
���   �$	��Top=�6j   $��84��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -43.634Q�6&   T� 5      5      5      �� 5   
   $��30��6   $
��Left=�6   $��
173,51,0,0q�68   $	��Top=�6L   $��36(�6d   :   4GestorDeVacaciones.View.UserControls.CalendarControl  5   
   -   5          Name$ 
calControl��5       $��338,77,29,43q�64   �� 5   
   $��
Individual��6   $��
338,39,0,0q�6&   $��33��6:   $	��Top=�6F   $
��Left=�6^   $	��105��6y   �� 5   
   -   5        $��Grupal��5      $��
448,39,0,0q�6"   $��33��66   $	��Top=�6B   $
��Left=�6Z   $	��105��6u   6�   �� 5$   
   -   5        $��>��5$      $��	0,39,29,0q�6    $��27��63   $	��Top=�6?   $��0q�6W   $��Right=�6c   $��18��6   6�   �� 5%   
   -   5        $��<��5%      $��	0,39,95,0q�6    $��27��63   $��0q�6?   $��Right=�6K   $��18��6g   $	��Top=�6r   6�   �� 5&   
   -   5         ��Name$ txtAño��5&      $��	0,39,47,0q�6n   $��Right=�6�   $��44��6�   $��24��6�   $	��Top=�6�   $ 0.603,0.406&�6�   $��18(�6�   ��6$   ��  �� ElementName$ 
calControl�� �� Path$ AñoSeleccionado�$ TwoWay=�6�   �� 5'   
   $��Stretch=�6^   $��1q�6�   $
��Left=�6�   $��36,125,0,144q�6�   $	��250��6�   ���	#FFDAD7D7
������ ��6   �� $ 
calControl��$ ListaDiasSeleccionados���5(      �� 5)       �� 
TargetType" ��6   .�5*      �� 	 �� Property	 � ��
 �� Value$
 0,5,2,0q�60   �� 5+      	 � ��$
 0,5,2,0q�6/   5,      ��5.      �� 5/      .R�50      �  K� IsItemsHost .  � Orientation$ 
Horizontal=�63   51      ��53      �� 54      .R�57      �� ��6    �� *
diaFormato+5;      5@      5A      5B      