   M S B A M L   `   `   `  ���� S  OEmployeeManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EmployeeManagementSystem.ViewModel"EmployeeManagementSystem.ViewModel  <    6EmployeeManagementSystem.UserControls.TechnologyWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ?vm0clr-namespace:EmployeeManagementSystem.ViewModel     
�������  � 	Resources  <  6EmployeeManagementSystem.ViewModel.TechnologyViewModel   	viewmodel��%   &	          .���  � RowDefinitions �� $	��100 �$	��100���� $��60 ��� $
��auto �.+��� $��0�� �� Orientation$ Vertical=�$	��Top=�$	��100��.+��� $��
Technology��$��40(�$��
20 20 20 0q��� $��
20 20 20 0q�� $��1��$��Center=� �� $��32 � � ColumnDefinitions �� $
��Auto ��� $��* �$	��250���� $	��120 ��� $	��120 ��� $	��120 �.+��� $��Center=�$��0��$��Technology:��$��	20,0,0,10q��� $	��250��$��1��
 � Tag$ 
technology��$��Stretch=�$
��Left=�$��15,0,0,0q�  CustomInputStyle#���  ���� *TechnologyName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $��2��$��5 0 20 0q�$
��Save��  ButtonStyle#���  ���� *SaveTechnology+�� $��3��$��5 0 20 0q�$
��Edit��#���  ���� *EditTechnology+�� $��4��$��5 0 20 0q�$��Delete��#���  ���� *DeleteTechnology+&   System.Windows.Controls.DataGrid  -   $��DataGrid��   
IsReadOnly$
 True��$
��auto��$	��Top=�  DataGridStyle#���  $��2��$��5��$��
20 10 20 0q�   AutoGenerateColumns$ False��$��Stretch=�	   CanUserAddRows$	 False��
   SelectionMode$
 Single=�   HeadersVisibility$ Column=� �� SelectedItem �� *SelectedRow+���� *TechnologyDataTable+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 .3*    MaxWidth$	 300Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ 
Technology��$	 .7*  �� *Name+