   M S B A M L   `   `   `  ����   EmployeeManagementSystem@    :EmployeeManagementSystem.UserControls.EmployeeLoginDetails   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources   �� 
TargetType   WrapText �� Property �� Value��%/   &	        �� " ��.���  � ��$
 Wrap=�.���  � RowDefinitions �� $��50 ��� $��* �.+��� -   $��Log Out��  ButtonStyle#���  $��60��$��32��$��0��$��Right=�$��Bottom=�$��0 0 20 0q�� $��30q�$��1�� � ColumnDefinitions �� $	��.2* �$	��100���� $	��.6* ��� $	��.2* �$	��100���� $	��.6* ��� $	��.2* �$	��100���� $	��.6* � �� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $��30��$	��.2* �$��50���� $	��.3* ��� $	��.2* �.+��� $
��Wrap=�$
��Bold"�$
��Left=�$��Name:��$��2��$��0��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Employee Code:��$��0��$��0��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Email:��$��4��$��0��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��	Password:��$��0��$��1��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Joining Date:��$��2��$��1��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Release Date:��$��4��$��1��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Date Of Birth:��$��0��$��2��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Contact Number:��$��2��$��2��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Gender:��$��4��$��2��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Marital Status:��$��0��$��3��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Present Address:��$��2��$��3��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Permanent Address:��$��4��$��3��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Desigantion:��$��0��$��4��$��Center=��� $
��Wrap=�$
��Bold"�$
��Left=�$��Department:��$��2��$��4��$��Center=��� $
��Wrap=�$
��Bold"�$��0 20 0 0q�$
��Left=�$��Education Details:��$��0��$��5��$	��Top=��� $
��Wrap=�$
��Bold"�$��0 20 0 0q�$
��Left=�$��Experience Details:��$��0��$��6��$	��top=��� -    ��Name$ EmployeeCode��$
��Wrap=�$
��Left=�$��1��$��0��$��Center=��� -   $ EmployeeName��$
��Wrap=�$
��Left=�$��3��$��0��$��Center=��� -   $ Email��$
��Wrap=�$
��Left=�$��5��$��0��$��Center=��� -   $ Password��$
��Wrap=�$
��Left=�$��1��$��1��$��Center=��� -   $ JoiningDate��$
��Wrap=�$
��Left=�$��3��$��1��$��Center=��� -   $ ReleaseDate��$
��Wrap=�$
��Left=�$��5��$��1��$��Center=��� -   $ DateOfBirth��$
��Wrap=�$
��Left=�$��1��$��2��$��Center=��� -	   $ ContactNumber��$
��Wrap=�$
��Left=�$��3��$��2��$��Center=��� -
   $ Gender��$
��Wrap=�$
��Left=�$��5��$��2��$��Center=��� -   $ MaritalStatus��$
��Wrap=�$
��Left=�$��1��$��3��$��Center=��� -   $ PresentAddress��$
��Wrap=�$
��Left=�$��3��$��3��$��Center=��� -   $ PermanentAddress��$
��Wrap=�$
��Left=�$��5��$��3��$��Center=��� -   $ Desigantion��$
��Wrap=�$
��Left=�$��1��$��4��$��Center=��� -   $ 
Department��$
��Wrap=�$
��Left=�$��3��$��4��$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ 	Education��   
IsReadOnly$
 True��$��5��$��1��	   AutoGenerateColumns$	 False��$��5��$
��Left=�$	��Top=�  DataGridStyle#���  $��0 20 20 20 q�
   CanUserAddRows$
 False��   SelectionMode$ Single=�"   VerticalScrollBarVisibility$
 Auto=�   HeadersVisibility$ Column=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 .2* 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [     Header$ Qulification��   Binding �� *Qualification+  $	 .2* # [  $ Board�� �� *BoardUniversity+  $	 .2* # [  $ 	Institute�� �� *InstituteName+  $	 .2* # [  $ State�� �� *State+  $	 .2* # [  $ Passing Year�� �� *PassingYear+  $	 .2* # [  $ 
Percentage�� �� *
Percentage+ �� StringFormat$
 {0}%��  -   $ 
Experience��$
 True��$��6��$��1��$	 False��$��5��$
��Left=�$	��Top=�#���  $��0 20 20 20 q�$
 False��$
 Auto=�$ Single=�$ Column=�   $	 .2* # [  $ Organization�� �� *Organization+  $	 .2* # [  $
 From�� �� *
FromDate+$ 
dd/MM/yyyy��  $	 .2* # [  $ To�� �� *ToDate+$ 
dd/MM/yyyy��  $	 .2* # [  $ Duration(months)�� �� *
Duration+  $	 .3* # [  $ Designation�� �� *Designation+