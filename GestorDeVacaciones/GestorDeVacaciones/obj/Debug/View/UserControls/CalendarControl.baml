   M S B A M L   `   `   `  ����M  IGestorDeVacaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:GestorDeVacaciones.View.UserControls$GestorDeVacaciones.View.UserControls  5      :    4GestorDeVacaciones.View.UserControls.CalendarControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:GestorDeVacaciones.View.UserControls     5      -   5          J� Effect  5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
   
      
BlurRadius$ 10Q�6      	Direction$ 0Q�6+      Opacity$	 0.8Q�69      Color$ 	#FF7C7C7C��6G   .��5      � -   5         �Name$ controlCalendarParent��5      $
��auto��6*   $��0,0,0,0q�68   $
��auto��6J   ���	#FF2642F1 � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��45 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ lblMes��5      $��0��6    $��Enero��6-   $��2��6=   $��Center=�6Q   $��Center=�6n   $��24(�6�   
���������6�   Z� 6�   � 5   
   $��1��6   ���	#FF1F6FFB$��2��63    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5       $��* �6#   �� 5!      $��* �6#   .+�5$      �� $��0��6   $��L��6$   $��Center=�60   $��Center=�6K   
�������6h   �� 5%      $��1��6   $��M��6$   $��Center=�60   $��Center=�6K   
�������6h   �� 5&      $��2��6   $��X��6$   $��Center=�60   $��Center=�6K   
�������6h   �� 5'      $��3��6   $��J��6$   $��Center=�60   $��Center=�6K   
�������6h   �� 5(      $��4��6   $��V��6$   $��Center=�60   $��Center=�6K   
�������6h   �� 5)      $��5��6   $��S��6$   $��Center=�60   $��Center=�6K   
�������6h   �� 5*      $��6��6   $��D��6$   $��Center=�60   $��Center=�6K   
�������6h   52      � 54   
   -   5        $ gridCalendar��54      $��2��6%   
�������$��2��6E    55      �� 56      $��* �6#   �� 57      $��* �6#   �� 58      $��* �6#   �� 59      $��* �6#   �� 5:      $��* �6#   �� 5;      $��* �6#   �� 5<      $��* �6#    5@      �� 5A      $��* �6    �� 5B      $��* �6    �� 5C      $��* �6    �� 5D      $��* �6    �� 5E      $��* �6    �� 5F      $��* �6    5H      �� 5I   
   -   5        	 ��Name$	 atras��5I      $��<��6    $
��Left=�6/   $��	31,16,0,0q�6J   $	��Top=�6]   $��47��6u   $��42��6�   6�   �� 5J   
   -   5        $	 adelante��5J      $��>��6#   $��	0,0,24,17q�62   $��42��6\   $��Bottom=�6h   $��Right=�6�   $��47��6�   5Q      5R      