   M S B A M L   `   `   `  ���� S  OEmployeeManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EmployeeManagementSystem.ViewModel"EmployeeManagementSystem.ViewModel  7    1EmployeeManagementSystem.UserControls.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     F	viewmodel0clr-namespace:EmployeeManagementSystem.ViewModel       � 	Resources  ��%    .���� ���#dad7cd �� CornerRadius$ 10�� �� Padding$ 10q�$��Center=�$��Center=�._�� $��Center=�$��Center=�$	��370��$	��520�� � ColumnDefinitions �� $	��150����  � RowDefinitions �� $
��1.5* ��� $
��0.8* ��� $
��0.8* ��� $��* �.+��� $��20q�$��0��$��35(�$��0��$��Center=�$��Login��$��2���� $��20 0 0 0q�$��Center=�$��Username��$��0��$��1��$
��Left=�$��16(��� -   $��username��
 � Tag$ email address��$��32��$��1��$��1��$	��300��$
��Left=�   CustomInputStyle#���   ���� *
UserName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��20 0 0 0q�$��Password��$��Center=�$��0��$��2��$
��Left=�$��16(��� $��2��$��1��$��Center=�.+�G� -    G�Name$ passwordBox��	 G� PasswordChar$		 ●��$��Center=�$
��Left=�$��32��$	��300���� -   
 ��Name$
 textBox��$
��Left=�#���   $��32��$	��300��$y�	Collapsed=����� *
Password+$ TwoWay=�$ PropertyChanged=��� -    ��Name$ ShowPasswordCharsCheckBox��$��Show Password����  �� Orientation$ Vertical=�$��0��$��3��$��2��$��Center=�.+��� $	��100��$��32��$��Login��  ButtonStyle#���  ���� *Login+�� -   $��txtBlock��$��15(�$��Center=�
���  �� �� TextAlignment$ Center=�