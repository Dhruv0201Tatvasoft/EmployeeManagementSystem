   M S B A M L   `   `   `  ����S  OEmployeeManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EmployeeManagementSystem.ViewModel"EmployeeManagementSystem.ViewModel  5      <    6EmployeeManagementSystem.UserControls.TechnologyWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?vm0clr-namespace:EmployeeManagementSystem.ViewModel     5      
�������  � 	Resources  5	      <  6EmployeeManagementSystem.ViewModel.TechnologyViewModel   	viewmodel��%   &	          5
   
   6!   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   $	��100��6)   �� 5      $��80 �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��5* �6   $	��250��6*   �� 5      $��3* �6   $	��150��6*   �� 5      $��3* �6   $	��150��6*   �� 5      $��3* �6   $	��150��6*   .+�5   
   �� $��0��6   $��5��6"    �� Orientation$ Vertical=�66   $	��Top=�6M   $	��100��6e   .+�5      �� $��
Technology��6   $��40(�6*   $��
20 20 20 0q�68   �� 5      $��
20 20 20 0q�6   5       �� 5"   
   $	��Top=�6   $��1��6,   $��0��69   $��Technology:��6I   $��	20,42,0,0q�6\   �� 5#   
   
 � Tag$ technology name��6   $	��250��6x   $��1��6�   $	��Top=�6�   $
��Left=�6�   $��0,34,0,0q�6�   $��1��6�   $��32��6�     CustomInputStyle#���  6�   ��6(   �� *TechnologyName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5$   
   $��2��6   $	��120��6D   $��30��6P   $��	0 20 10 0q�6\   $
��Save��6o     ButtonStyle#���  6~   $��1��6�   ��6!   �� *SaveTechnology+6�   �� 5%   
   $��3��6   $	��120��6D   $��30��6P   $��	0 20 10 0q�6\   $
��Edit��6o   #���  6~   $��1��6�   ��6!   �� *EditTechnology+6�   �� 5&   
   $��4��6   $	��120��6F   $��30��6R   $��	0 20 10 0q�6^   $��Delete��6r   #���  6�   $��1��6�   ��6!   �� *DeleteTechnology+6�   &   System.Windows.Controls.DataGrid  5'   
   -   5        $��DataGrid��5'   �      
IsReadOnly$
 True��6   $
��auto��6J   $	��Top=�6�     DataGridStyle#���  6�   $��3��6�   $��5��6�   $��
20 10 20 0q�6�      AutoGenerateColumns$ False��6  $��Stretch=�6*  	   CanUserAddRows$	 False��6H  
   SelectionMode$
 Single=�6_     HeadersVisibility$ Column=�6v   �� SelectedItem 6%   �� *SelectedRow+��6X   �� *TechnologyDataTable+   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 .3* 61      MaxWidth$	 300Q�6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *Id+  5*      $ 
Technology��6%   $	 .7* 69    6E   �� *Name+5,      5-      5.      