   M S B A M L   `   `   `  ���� S  OEmployeeManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EmployeeManagementSystem.Converter"EmployeeManagementSystem.Converter  W0clr-namespace:EmployeeManagementSystem.ViewModel"EmployeeManagementSystem.ViewModel  =    7EmployeeManagementSystem.UserControls.AddEmployeeWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     F	converter0clr-namespace:EmployeeManagementSystem.Converter     ?vm0clr-namespace:EmployeeManagementSystem.ViewModel       � 	Resources     CircleButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  TextBoxTopAlignedTextStyle �� BasedOn  NormalBackGroundColor ��Name K� ZIndex	 �� Path
 �� RelativeSource �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value  ForeGroundColor P� Property P� Value  BorderColor=  7EmployeeManagementSystem.ViewModel.AddEmployeeViewModel  	ViewModelC  =EmployeeManagementSystem.Converter.RadioButtonChoiceConverter  radiobuttonconverter?  9EmployeeManagementSystem.Converter.ButtonDisbaleConverter  ButtonDisableConverter��%  &	        &	 y     7��&	 �    &	 �    &	 �    �� " ��.���  � �� �� " ��.R��� 
������ 
������ $��1q�$ 10��._��� $��Center=�$��Center=��� " ��8   .���  � ��# �  ��  � �� �	#FF7D8683��  � �� �	#99000000��  � �� �� " ��.R�� .+��� $ 
textSource��$	��Top=�
������ $ 2������ $
	 Text�
 �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=��� #��z #��z��$ 1��.������ " ��.���  � ��
 ����  ��  �� $
	 Text�   *
textSource+  .a���  � ��# �  ��  � ��$	 Top=���  � ��# �  .�� P�  �@=�HasError$
 True��. ���  �@�ToolTip �� 
 �� *Self+$&	  (Validation.Errors)/ErrorContent�P�  �@J�IsMouseOver$
 True��. ���  � �� �#F3F3F3P�  �@J�	IsFocused$
 True��. ���  � �� �#FFFFFF��  � ��# �  P�  � {�$ False��. ���  � �� �	#33000000��  � �� �	#66000000      .���  � RowDefinitions �� $
��auto ��� $
��auto ��� $	��.7* �.+�]� $��0��$��Stretch=�$
��auto��.+��� $��Employee - Add��$��
20 20 20 0q�$��Center=�$��40(��� -   $��BackBtn��$
��Back��  ButtonStyle#���  $��70��$��32��$��Right=�$��0,0,20,7q�$��Bottom=��� $��1��$��20 10 20 10q�$��Stretch=�$	��Top=��� -    ��Name$ 
TabControl�����#507E32$	��0.5q�$��
20 0 20 20q�$��2��.@��� -   $��EmployeeDetailsTabItem��$��Employee Details�� 	 TabItemStyle#��� 	 .���� ._��� .u��  � ColumnDefinitions �� $	��.2* �$	��200���� $	��.3* �$	��300���� $	��.2* �$	��200���� $
��.31* �$	��300���� $	��.1* ��� $	��.1* � �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+���  
 CompulsoryInputTextBlock#��� 
 $	��120��$��0��$��0��$��Center=�$��Code:��$��	20 20 0 0q�$��20��$
��auto���� -   $
��Code��$
 code��$��1��$��0��$��Stretch=�$��32��$	��250��  CustomInputStyle#���  $
��auto��$	��Top=�$��0,20,0,0q����� *Code+$ TwoWay=� �� ValidatesOnDataErrors$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��1��$��0��$��Center=�$��First Name:��$��	20 20 0 0q�$��20��$
��auto���� -   $��	FirstName��$ 	firstname��$	��250��$��32��#���  $
��auto��$��1��$��1��$	��Top=�$��0,20,0,0q����� *	FirstName+$ TwoWay=�$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��1��$��2��$��Center=�$��
Last Name:��$��	20 20 0 0q�$��20���� -   $��LastName��$ lastname��$��1��$��3��$��32��#���  $
��auto��$	��Top=�$��0,20,0,0q�$	��250������ *
LastName+$ TwoWay=�$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��2��$��0��$��Center=�$��Email:��$��	20 20 0 0q�$��20���� -   $��Email��$ email��$	��250��$��2��$��1��$��32��#���  $
��auto��$	��Top=�$��0,20,0,0q����� *Email+$ TwoWay=�$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��3��$��0��$��Center=�$��	Password:��$��	20 20 0 0q�$��20���� -   $��Password��$ password��$	��250��$��3��$��1��$��32��#���  $
��auto��$	��Top=�$��0,20,0,0q����� *
Password+$ TwoWay=�$
 True��$ PropertyChanged=��� $	��120��$
��Wrap=�$��3��$��2��$��Center=�$��Confirm Password:��$��	20 20 0 0q�$
��auto�� �� TextAlignment$
 Left=��� -	   $��ConfirmPassword��$ confirm password��$	��250��$��3��$��3��$��32��$
��auto��$	��Top=�#���  $��0,20,0,0q����� *ConfirmPassword+$ TwoWay=�$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��4��$��0��$��Center=�$��Department:��$��	20 20 0 0q�$��20���� -
   $��
Department�� �� 
IsEditable$
 True�� �� 
IsReadOnly$
 True��$	��250��$��4��$��1��$��32��$
��auto��  CustomComboBoxStyle#���  $	��Top=�$��0,20,0,0q� �� Text �� *CombBoxText+$ OneWay=����� *
Department+ �� SelectedItem �� *SelectedDepartment+$ TwoWay=�$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��4��$��2��$��Center=�$��Designation:��$��	20 20 0 0q�$��20��$	��120���� -   $��Designation��$
 True��$
 True��$	��250��$��32��$
��auto��$��3��$��4��$	��Top=�#���  $��0,20,0,0q� �� *CombBoxText+$ OneWay=����� *Designation+ �� *SelectedDesignation+$ TwoWay=�$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��Center=�$��Joining Date:��$��	20 20 0 0q�$��20��$��0��$��5��(  "System.Windows.Controls.DatePicker  -   $��JoiningDate��   SelectedDateFormat$
 Long=�   DisplayDateStart 
01/01/1900   DisplayDateEnd 
2100/10/12$	��250��$��5��$��1��$��32��$
��auto��  CustomDatePickerStyle#���  $	��Top=�$��0,20,0,0q�    Text  �� *JoiningDate+! �� TargetNullValue$!  ��$
 True��$ TwoWay=�" �� StringFormat$" 
dd/MM/yyyy��$ PropertyChanged=��� $	��120��$��5��$��2��$��Center=�$��Release Date:��$��	20 20 0 0q�$��20��$
 Left=�  -   $��ReleaseDate��$
 Long=� 
01/01/1900 
2100/10/12$	��250��$��32��$
��auto��$��3��$��5��$	��Top=�#���  $��0,20,0,0q�  �� *ReleaseDate+$ PropertyChanged=�$!  ��$
 True��$ TwoWay=�$" 
dd/MM/yyyy��� $��6��$��6��.+��� -   # ��Name$# EmployeeDetailsNextBtn��$	��120��$��32��$
��Next��#���  $��Bottom=�$��Right=�$��
0,10,150,5q�{�`� $ `� 	Converter#$ [ % `� Mode$% TwoWay=�.1��� & �� ElementName$
& Code��$	 (Validation.HasError)��� $& 	FirstName��$	 (Validation.HasError)��� $& LastName��$	 (Validation.HasError)��� $& Email��$	 (Validation.HasError)��� $& Password��$	 (Validation.HasError)��� $& ConfirmPassword��$	 (Validation.HasError)��� $& 
Department��$	 (Validation.HasError)��� $& Designation��$	 (Validation.HasError)��� $& JoiningDate��$	 (Validation.HasError)��� $& ReleaseDate��$	 (Validation.HasError)��� $	��120��$��32��$��Clear��#���  $��Bottom=�$��Right=�$��0,10,5,5q����� *ClearEmployeeDetails+�� -   $��PersonalDetailsTabItem��$��Personal Details��#��� 	 {�`� #$ [ $% TwoWay=�.1��� $
& Code��$	 (Validation.HasError)��� $& 	FirstName��$	 (Validation.HasError)��� $& LastName��$	 (Validation.HasError)��� $& Email��$	 (Validation.HasError)��� $& Password��$	 (Validation.HasError)��� $& ConfirmPassword��$	 (Validation.HasError)��� $& 
Department��$	 (Validation.HasError)��� $& Designation��$	 (Validation.HasError)��� $& JoiningDate��$	 (Validation.HasError)��� $& ReleaseDate��$	 (Validation.HasError)�.���� ._��� .u��  �� $	��.2* �$	��200���� $	��.3* �$	��300���� $	��.2* �$	��200���� $
��.31* �$	��300���� $	��.1* ��� $	��.1* � �� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� #��� 
 $	��120��$��0��$��0��$��Center=�$��Date Of Birth:��$��	20 20 0 0q�$��20��$
��auto��  -   $	��DOB��$
 Long=� 
01/01/1900 
2100/12/31$��1��$��0��$��Stretch=�$��32��$	��250��#���  $
��auto��$	��Top=�$��0,20,0,0q�  �� *DOB+$ PropertyChanged=�$!  ��$
 True��$ TwoWay=�$" 
dd/MM/yyyy���� #��� 
 $	��120��$��0��$��2��$��Center=�$��Contact Number:��$��	20 20 0 0q�$
��auto��$
��auto���� -   $ ContactNumber��$ contact number��$	��250��$��32��#���  $
��auto��$��3��$��0��$	��Top=�$��0,20,0,0q����� *ContactNumber+$ TwoWay=�$
 True��$ PropertyChanged=��� #��� 
 $	��120��$��1��$��0��$��Center=�$��Gender:��$��	20 20 0 0q�$��20���� $
��auto��$��0,20,0,0q�$��Stretch=�$��32��$	��250��' �� Orientation$' 
Horizontal=�$	��Top=�$��1��$��1��.+�	� $
��Male��  RadioButtonStyle#���  ( d� 	IsChecked( �� *Gender+$
 True��) �� 	Converter#) [ * �� ConverterParameter$
* Male��	� $��Female��$��10 0 0 0q�#���  ( �� *Gender+#) [ $* Female���� #��� 
 $	��120��$��1��$��2��$��Center=�$��Marital Status:��$��	20 20 0 0q�$��20���� -   $��MaritalStatus��$
 True��$
 True��$	��250��$��1��$��3��$��32��$
��auto��#���  $	��Top=�$��0,20,0,0q� �� *MaritalStatusCombBoxText+$ OneWay=����� *MaritalStatus+ �� *SelectedMaritalStatus+$ TwoWay=�$
 True���� #��� 
 $	��120��$��2��$��0��$	��Top=�$��Present Address:��$��	20 20 0 0q�$
��auto���� -   $��PresentAddress��$ present address��$	��250��+ �� MaxLines$+ 20��$��80��$��2��$��1��$
��auto��#��[ $
��auto��$	��Top=�$��0,20,0,0q����� *PresentAddress+$ TwoWay=�$
 True��$ PropertyChanged=��� $
��Wrap=�$	��120��$��2��$��2��$	��Top=�$��Permanent Address:��$��	20 20 0 0q�$
��auto��$
 Left=��� $��0 20 0 0q�$��2��$��3��$	��top=�$
��auto��$' Vertical=�.+��� $	��250��$
��auto��$
��auto��$	��Top=�  CustomCheckBoxStyle#���  $��Same as Peresent��( �� *IsCheckBoxChecked+$ TwoWay=��� -   $ PermanentAddress��$ permanent address��$	��250��$+ 20��$��80��$��2��$��1��$
��auto��#��[ $
��auto��$	��Top=�$��0,20,0,0q����� *PermanentAddress+$ TwoWay=�$
 True��$ PropertyChanged=�� $��4��$��6�� �� $��* ��� $
��Auto �.+��� -   $# PersonalDetailsNextBtn��$	��120��$��32��$
��Next��#���  $��Bottom=�$��Right=�$��
0,10,150,5q����� *AddEmployee+{�`� #$ [ $% TwoWay=�.1��� $	& DOB��$	 (Validation.HasError)��� $& ContactNumber��$	 (Validation.HasError)��� $& MaritalStatus��$	 (Validation.HasError)��� $& PresentAddress��$	 (Validation.HasError)��� $& PermanentAddress��$	 (Validation.HasError)��� $	��120��$��32��$��Clear��#���  $��Bottom=�$��Right=�$��0,10,5,5q����� *ClearPersonalDetails+�� -   $��EducationDetailsTabItem��$��Education Details��${�False��#��� 	 .���  �� $	��100 ��� .+��� $��0��$	��120��$��32��$��0 0 20 0q�$��Right=�#���  ���� *AddBlankRowEducation+���  �� $��40 ��� $��80 �.+��� $��20��$��20��$��Center=�$��Center=�$��\Icons\AddIcon.png���� $��1��$	��ADD��$
��Left=�$��Center=�&   System.Windows.Controls.DataGrid  -   $��DGrid��$��1��  DataGridStyle#���  ,   
IsReadOnly$
, True��$	��Top=�-   AutoGenerateColumns$- False��.   CanUserAddRows$. False�� �� * SelectedEmployeeEducationModel+���� *EmployeeEducationList+/   Columns/ 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn0   Header$0 Qualification��1   Width5	  /System.Windows.Controls.DataGridLengthConverter$	1 .1*	 2   CellTemplate2 �� .R��� ���� *Qualification+3   CellEditingTemplate3 �� .R��� $ qualification��#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *Qualification+$ TwoWay=�$ PropertyChanged=�  $0 Board/University��$	1 .1*	 2 �� .R��� ���� *BoardUniversity+3 �� .R��� $ board��#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *BoardUniversity+$ TwoWay=�$ PropertyChanged=�  $0 Name Of Institute��$	1 .1*	 2 �� .R��� ���� *InstituteName+3 �� .R��� $ name of school��#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *InstituteName+$ TwoWay=�$ PropertyChanged=�  $0 State��$	1 .1*	 2 �� .R��� ���� *State+3 �� .R��� $ state��#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *State+$ TwoWay=�$ PropertyChanged=�  $0 Passing Year��$	1 .1*	 2 �� .R��� ���� *PassingYear+3 �� .R��� $
 year��#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *PassingYear+$ TwoWay=�$ PropertyChanged=�  $0 
Percentage��$	1 .1*	 2 �� .R��� ���� *
Percentage+$
" {0}%��3 �� .R��� $ 
Percentage��#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *
Percentage+$ TwoWay=�$ PropertyChanged=�  $	1 .1*	 $0 Actions��2 �� .R��� $	��100��$' 
Horizontal=�.+��� 4 � ToolTip$
4 Edit��$��	10 0 10 0q�$��30��$��30������ *DataContext.EditEducationRow+
 �� 5 �� AncestorType"5  .���� $��\Icons\EditIcon.png���� $4 Delete��#��[  $��	10 0 10 0q�$��30��$��30������ *)'DataContext.RemoveEducationFromDataBase+
 �� "5  .���� $ ��\Icons\CircleCrossIcon.png��3 �� .R��� $' 
Horizontal=�$	��100��.+��� #���  $
��Save��$��	10 0 10 0q�$��40��$��30������ *DataContext.SaveEducationRow+
 �� "5  �� #��[  $4 Remove��$��	10 0 10 0q�$��30��$��30������ *%#DataContext.RemoveEducationFromList+
 �� "5  .���� $ ��\Icons\CircleCrossIcon.png���� -   $��ExperienceDetailsTabItem��$��Experience Details��${�False��#��� 	 .���  �� $	��100 ��� .+��� $��0��$	��120��$��32��$��0 0 20 0q�$��Right=�#���  ���� *AddBlankRowExperience+���  �� $��40 ��� $��80 �.+��� $��20��$��20��$��Center=�$��Center=�$��\Icons\AddIcon.png���� $��1��$	��ADD��$
��Left=�$��Center=�  -   $��ExperienceDataGrid��$��1��#���  $
, True��$	��Top=�$- False��$. False�� �� *!SelectedEmployeeExperienceModel+���� *EmployeeExperienceList+/   $0 Organization��$	1 .1*	 2 �� .R��� ���� *Organization+3 �� .R��� $ organization��#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *Organization+$ TwoWay=�$ PropertyChanged=�  $
0 From��$	1 .1*	 2 �� .R��� ���� *
FromDate+$" 
dd/MM/yyyy��3 �� .R�   
01/01/1900 
2100/12/31#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q�6   SelectedDate6 �� *
FromDate+$ TwoWay=�$ PropertyChanged=�  $0 To��$	1 .1*	 2 �� .R��� ���� *ToDate+$" 
dd/MM/yyyy��3 �� .R�   
01/01/1900 
2100/12/31#���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q�6 �� *ToDate+$ TwoWay=�$ PropertyChanged=�0
  *System.Windows.Controls.DataGridTextColumn
  $	1 .1*	 $0 Duration(months)��1  +System.Windows.Controls.DataGridBoundColumn7   Binding7 �� *
Duration+$ TwoWay=�  $0 Designation��$	1 .1*	 2 �� .R��� ���� *Designation+3 �� .R��� #���  $��Center=�$
��auto��$	��150��$��32��
���   �$��1q����� *DataContext.Designation+
 �� "5   �� *Designation+$ TwoWay=�$ PropertyChanged=�  $	1 .1*	 $0 Actions��2 �� .R��� $	��100��$' 
Horizontal=�.+��� $��	10 0 10 0q�$��30��$��30��$
4 Edit������ *DataContext.EditExperience+
 �� "5  .���� $��\Icons\EditIcon.png���� $4 Remove��#��[  $��	10 0 10 0q�$��30��$��30������ **(DataContext.RemoveExperienceFromDataBase+
 �� "5  .���� $ ��\Icons\CircleCrossIcon.png��3 �� .R��� $' 
Horizontal=�$	��100��.+��� #���  $
��Save��$��	10 0 10 0q�$��40��$��30������ *DataContext.SaveExperienceRow+
 �� "5  �� $4 Remove��$��	10 0 10 0q�$��30��$��30��#��[  ���� *&$DataContext.RemoveExperienceFromList+
 �� "5  .���� $ ��\Icons\CircleCrossIcon.png��