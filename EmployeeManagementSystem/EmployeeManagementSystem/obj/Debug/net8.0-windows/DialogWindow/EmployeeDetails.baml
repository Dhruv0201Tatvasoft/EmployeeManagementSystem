   M S B A M L   `   `   `  ����  EmployeeManagementSystem;    5EmployeeManagementSystem.DialogWindow.EmployeeDetails   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ Employee Details��5   	   $	��400��6"   $	��750��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         NormalBackGroundColor �� Color  HoverBackGroundColor  PressedBackGroundColor  DisabledBackGroundColor  BorderColor  ForeGroundColor  DisabledForeGroundColor  DataGridStyle �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers	 P� Property
 P� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     &	 �     7  7  7  �� 5   
   $ #FAFAFA��68   �� 5   
   $ #669E40��67   �� 5   
   $ #60943C��69   �� 5   
   $ #C5E0B4��6:   �� 5   
   $ #507E32��6.   �� 5   
   $ 	#99000000��62   �� 5   
   $ #AFABAB��6:   �� 5   
   "  6&   .�5      ��   �@ AlternatingRowBackground �#EBF1E969   �� 5       � �� �#0000006+   �� 5       �@ RowStyle 5      �� 5      "  6   .�5      ��  � �� �#00000067    5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   ��  � ��8   6?   5      5      5       �� 5"       �@ 	CellStyle 5#      �� 5$      "  6   .�5%      ��  � �� 5&      �� 5'   "   "  62   .R�5(   &   � #��z��6+   .+�5)   *   �� $��Center=�6;   5*   '   5+   #   5-      �� 5.       � ��$ 50��63   �� 5/       �@��TextAlignment$ Center=�6D   �� 50       � �� �#00000067    51      P� 52      	 �@ 
IsSelected$

 True��6<   . �53   "   ��  � ��8  6?   54      56      58      �� 5:       �@ ColumnHeaderStyle 5;      �� 5<      "  6   .�5=      ��  � ��$ Center=�6G   �� 5>       � �� �#70AD4767   �� 5?       � �� �#FFFFFF67   �� 5@       � ��$ 50��63    5A      P� 5B      	 �@J�IsMouseOver$

 True��6=   . �5C   "   ��  � ��8  6?   5D      5F      5H      5I      5K      .��5L      �� .��5M   
   � $��20q�6    � ColumnDefinitions 5O      �� 5P      $	��.2* �6#   �� 5Q      $	��.7* �6#    � RowDefinitions 5S      �� 5T      $��30��6    $	��.2* �6/   $��50��6<   �� 5U      $��30��6    $	��.2* �6/   $��50��6<   �� 5V      $��30��6    $	��.2* �6/   $��50��6<   �� 5W      $��30��6    $	��.2* �6/   $��50��6<   �� 5X      $��30��6    $	��.2* �6/   $��50��6<   �� 5Y      $��30��6    $	��.2* �6/   $��50��6<   �� 5Z      .+�5\      �� $��Employee Code:��6   $
��Left=�6.   $��Center=�6I   $��0��6d   $��0��6t   �� 5]      $��Name:��6   $
��Left=�6%   $��Center=�6@   $��0��6[   $��1��6k   �� 5^      $��Email:��6   $
��Left=�6&   $��Center=�6A   $��0��6\   $��2��6l   �� 5_      $��Department:��6   $
��Left=�6+   $��Center=�6F   $��0��6a   $��3��6q   �� 5`      $��Designation:��6   $
��Left=�6,   $��Center=�6G   $��0��6b   $��4��6r   �� 5a      $��Joining Date:��6   $
��Left=�6-   $��Center=�6H   $��0��6c   $��5��6s   �� 5b      $��Experience:��6   $
��Left=�6,   $	��Top=�6G   $��0��6_   $��6��6o   �� 5c      -   5         ��Name$
 Code��5c      $
��Left=�6&   $��Center=�6A   $��1��6\   $��0��6l   �� 5d      -   5        $ EmployeeName��5d      $
��Left=�6.   $��Center=�6I   $��1��6d   $��1��6t   �� 5e      -   5        $ Email��5e      $
��Left=�6'   $��Center=�6B   $��1��6]   $��2��6m   �� 5f      -   5        $ 
Department��5f      $
��Left=�6,   $��Center=�6G   $��1��6b   $��3��6r   �� 5g      -   5        $ Designation��5g      $
��Left=�6-   $��Center=�6H   $��1��6c   $��4��6s   �� 5h      -   5        $ JoiningDate��5h      $
��Left=�6-   $��Center=�6H   $��1��6c   $��5��6s     5i      -   5          Name$ 
Experience��5i   )      
IsReadOnly$
 True��6   $��6��6=   $��1��6J      AutoGenerateColumns$ False��6Z   $	��Top=�6v   #��[ 6�   $��1,0,19,0q�5j         CanUserAddRows$ False��5k         SelectionMode$ Single=�5l         HeadersVisibility$ Column=�5m         Columns 5o      0  *System.Windows.Controls.DataGridTextColumn  5p      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 .2* 6)      Header$ Organization��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *Organization+  5q      $	 .2* 6)   $ Duration(months)��65    6O   �� *
Duration+  5r      $	 .2* 6)   $ Designation��65    6J   �� *Designation+5u      5v      5w      5x      