   M S B A M L   `   `   `  ����S  OEmployeeManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EmployeeManagementSystem.ViewModel"EmployeeManagementSystem.ViewModel  5      <    6EmployeeManagementSystem.UserControls.TechnologyWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?vm0clr-namespace:EmployeeManagementSystem.ViewModel     5      
�������  � 	Resources  5	      <  6EmployeeManagementSystem.ViewModel.TechnologyViewModel   	viewmodel��%   &	          5
   
   6!   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   $	��100��6)   �� 5      $��60 �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $	��Top=�69   $	��100��6Q   .+�5      �� $��
Technology��6   $��40(�6*   $��
20 20 20 0q�68   �� 5      $��
20 20 20 0q�6   5      � 5   
   $��1��6   $��Center=�6    5      �� 5      $��32 �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   $	��250��6-   �� 5       $	��120 �6#   �� 5!      $	��120 �6#   �� 5"      $	��120 �6#   .+�5%      �� $��Center=�6   $��0��63   $��Technology:��6C   $��	20,0,0,10q�6V   �� 5&      $	��250��6   $��1��6%   
 � Tag$ 
technology��65   $��Stretch=�6�   $
��Left=�6�   $��15,0,0,0q�6�     CustomInputStyle#���  6�   ��6F   �� *TechnologyName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5(      $��2��6   $��5 0 20 0q�6I   $
��Save��6[     ButtonStyle#���  6j   ��6&   �� *SaveTechnology+6�   �� 5)      $��3��6   $��5 0 20 0q�6I   $
��Edit��6[   #���  6j   ��6%   �� *EditTechnology+6�   �� 5*      $��4��6   $��5 0 20 0q�6J   $��Delete��6]   #���  6n   ��6%   �� *DeleteTechnology+6�   5+      &   System.Windows.Controls.DataGrid  5,   
   -   5        $��DataGrid��5,   �      
IsReadOnly$
 True��6   $
��auto��6J   $	��Top=�6�     DataGridStyle#���  6�   $��2��6�   $��5��6�   $��
20 10 20 0q�6�      AutoGenerateColumns$ False��6  $��Stretch=�6*  	   CanUserAddRows$	 False��6H  
   SelectionMode$
 Single=�6_     HeadersVisibility$ Column=�6v   �� SelectedItem 6%   �� *SelectedRow+��6X   �� *TechnologyDataTable+   Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 .3* 61      MaxWidth$	 300Q�6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *Id+  5/      $ 
Technology��6%   $	 .7* 69    6E   �� *Name+51      52      53      