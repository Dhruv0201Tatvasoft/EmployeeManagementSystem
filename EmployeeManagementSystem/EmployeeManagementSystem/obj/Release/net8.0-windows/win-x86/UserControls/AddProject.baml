   M S B A M L   `   `   `  ���� S  OEmployeeManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EmployeeManagementSystem.ViewModel"EmployeeManagementSystem.ViewModel  Y1clr-namespace:EmployeeManagementSystem.Behaviours#EmployeeManagementSystem.Behaviours  W0clr-namespace:EmployeeManagementSystem.Converter"EmployeeManagementSystem.Converter  6    0EmployeeManagementSystem.UserControls.AddProject   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  9vm0clr-namespace:EmployeeManagementSystem.ViewModel  9b1clr-namespace:EmployeeManagementSystem.Behaviours  @	converter0clr-namespace:EmployeeManagementSystem.Converter    � 	Resources     ListBoxItemStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels �� Triggers P� Property	 P� Value
 �� 
TargetName?  9EmployeeManagementSystem.Converter.ButtonDisbaleConverter  ButtonDisableConverter<  6EmployeeManagementSystem.ViewModel.AddProjectViewModel  	ViewModel��%�  &	        &	 �    &	 �    �� " ��.���  �@J�SnapsToDevicePixels$
 true����  �@�OverridesDefaultStyle$
 true����  � �� �� " ��.R��� $��Border��$ 7q�$
 True��#��z��._���  P�  �@��
IsSelected$
	 true��. ��� $
 Border�� � �� �#60943CP�  �@J�IsMouseOver$
	 True��. ��� $
 Border�� � �� �#669E40P�  � {�$	 false��. ���  � ��
 � � �    .���  � ColumnDefinitions ��  � RowDefinitions �� $
��auto ��� $
��auto ��� .+��� $��0�� �� Orientation$ Vertical=�$��Stretch=�$	��Top=�$
��auto��.+��� $��Project - Add��$��
20 20 20 0q�$��40(��� $��20 10 20 10q�$��Stretch=�$	��Top=�� $��2��$��1��$
��20 0q� �� $	��100 ��� $��* � �� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $
��Auto �.+���   CompulsoryInputTextBlock#���  $
��Left=�$��Center=�$��Code:��$��0��$��0���� -    ��Name$
 Code��
 � Tag$
 code��$��0��$��1��$	��250��$��32��$
��Left=�  CustomInputStyle#���  ���� *Code+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� ValidatesOnDataErrors$
 True���� #���  $
��Left=�$��Center=�$��Name:��$��0��$��1���� -   $ Projectname��$
 name��$��1��$��1��$	��250��$��32��$
��Left=�#���  ���� *Name+$ PropertyChanged=�$ TwoWay=�$
 True���� #���  $
��Left=�$��Center=�$��Start Date:��$��0��$��2��(  "System.Windows.Controls.DatePicker  -     Name$ StartingDate��   SelectedDateFormat$
 Long=�   DisplayDateStart 
1900/01/01   DisplayDateEnd 
2100/12/31$��2��$��1��$	��250��$��32��$
��Left=�  CustomDatePickerStyle#���     Text �� *StartingDate+ �� TargetNullValue$  ��$
 True��$ PropertyChanged=�$ TwoWay=� �� StringFormat$ 
dd/MM/yyyy���� $
��Left=�$��Center=�$��	End Date:��$��0��$��3��  -   $ 
EndingDate��$
 Long=� 
01/01/1900 
2100/12/31$��3��$��1��$	��250��$��32��$
��Left=�#���   �� *
EndingDate+$ PropertyChanged=�$  ��$
 True��$ TwoWay=�$ 
dd/MM/yyyy���� $
��Left=�$	��top=�$��Technologies:��$��0��$��4���� -    ��Name$ 	myListBox�����#507E32$��1q�$��4��$��1��$	��200��$
��Left=� �� SelectionMode$ Multiple=����� *	DataTable+ �� NotifyOnSourceUpdated$
 True������ " �� �� BasedOn# [  *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors C  =EmployeeManagementSystem.Behaviours.ListBoxSelectionBehaviour     SelectedItem �� *SelectedTechnologyRow+$ TwoWay=����� .R��� ���� *Name+�� $��2��$ 
Horizontal=�$��90,60,10,90q�.+���   ButtonStyle#���  $	��Top=�$��	30 0 30 0q�$��70��$��32��$
��Save������ *SaveProject+{�`�   `� 	Converter#  [ ! `� Mode$! TwoWay=�.1��� " �� ElementName$
" Code��# �� Path$# (Validation.HasError)��� $" Projectname��$# (Validation.HasError)��� $" StartingDate��$# (Validation.HasError)��� $" 
EndingDate��$# (Validation.HasError)��� -   #���  $��70��$��32��$	��Top=�$��Cancel��