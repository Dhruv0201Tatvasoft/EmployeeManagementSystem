   M S B A M L   `   `   `  ����   EmployeeManagementSystem;    5EmployeeManagementSystem.DialogWindow.EmployeeDetails   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � 
ResizeMode$  CanMinimize=� � Title$ Employee Details��$	��400��$	��750�� � WindowStartupLocation$ CenterScreen=� � 	Resources    NormalBackGroundColor �� Color  HoverBackGroundColor  PressedBackGroundColor  DisabledBackGroundColor  BorderColor  ForeGroundColor  DisabledForeGroundColor  DataGridStyle �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers	 P� Property
 P� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 t     &	 �     7  7  7  �� $ #FAFAFA���� $ #669E40���� $ #60943C���� $ #C5E0B4���� $ #507E32���� $ 	#99000000���� $ #AFABAB���� "  .���   �@ AlternatingRowBackground �#EBF1E9��  � �� �#000000��  �@ RowStyle �� "  .���  � �� �#000000 P� 	 �@J�IsMouseOver$

 True��. ���  � ��8   ��  �@ 	CellStyle �� "  .���  � �� �� "  .R�� #��z��.+��� $��Center=���  � ��$ 50����  �@��TextAlignment$ Center=���  � �� �#000000 P� 	 �@ 
IsSelected$

 True��. ���  � ��8  ��  �@ ColumnHeaderStyle �� "  .���  � ��$ Center=���  � �� �#70AD47��  � �� �#FFFFFF��  � ��$ 50�� P� 	 �@J�IsMouseOver$

 True��. ���  � ��8  .���� .��� $��20q� � ColumnDefinitions �� $	��.2* ��� $	��.7* � � RowDefinitions �� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� .+��� $��Employee Code:��$
��Left=�$��Center=�$��0��$��0���� $��Name:��$
��Left=�$��Center=�$��0��$��1���� $��Email:��$
��Left=�$��Center=�$��0��$��2���� $��Department:��$
��Left=�$��Center=�$��0��$��3���� $��Designation:��$
��Left=�$��Center=�$��0��$��4���� $��Joining Date:��$
��Left=�$��Center=�$��0��$��5���� $��Experience:��$
��Left=�$	��Top=�$��0��$��6���� -    ��Name$
 Code��$
��Left=�$��Center=�$��1��$��0���� -   $ EmployeeName��$
��Left=�$��Center=�$��1��$��1���� -   $ Email��$
��Left=�$��Center=�$��1��$��2���� -   $ 
Department��$
��Left=�$��Center=�$��1��$��3���� -   $ Designation��$
��Left=�$��Center=�$��1��$��4���� -   $ JoiningDate��$
��Left=�$��Center=�$��1��$��5��  -     Name$ 
Experience��   
IsReadOnly$
 True��$��6��$��1��   AutoGenerateColumns$ False��$	��Top=�#��[ $��1,0,19,0q�   CanUserAddRows$ False��   SelectionMode$ Single=�   HeadersVisibility$ Column=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 .2*    Header$ Organization��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Organization+  $	 .2* $ Duration(months)�� �� *
Duration+  $	 .2* $ Designation�� �� *Designation+