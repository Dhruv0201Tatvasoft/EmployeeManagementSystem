   M S B A M L   `   `   `  ���� S  OEmployeeManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EmployeeManagementSystem.Converter"EmployeeManagementSystem.Converter  \ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows Y1clr-namespace:EmployeeManagementSystem.Behaviours#EmployeeManagementSystem.Behaviours  l hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting ��clr-namespace:System.Windows.Controls.DataVisualization.Charting.Primitives;assembly=System.Windows.Controls.DataVisualization.Toolkit=System.Windows.Controls.DataVisualization.Charting.Primitives ;    5EmployeeManagementSystem.UserControls.DashboardWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     F	converter0clr-namespace:EmployeeManagementSystem.Converter     Kvsm;clr-namespace:System.Windows;assembly=PresentationFramework     ?b1clr-namespace:EmployeeManagementSystem.Behaviours     �chart{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     �chartingpremitives�clr-namespace:System.Windows.Controls.DataVisualization.Charting.Primitives;assembly=System.Windows.Controls.DataVisualization.Toolkit       � 	Resources     PieDataPointStyle �� 
TargetType6   0EmployeeManagementSystem.Behaviours.PieDataPoint �� Property �� ValueE  ?System.Windows.Controls.DataVisualization.Charting.PieDataPoint �� 
TargetType J� Opacity'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   States   System.Windows.VisualState
   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration   TextedGeometry �� StrokeMiterLimit ^� ToolTip �� RelativeSource   GeometrySelection J� IsHitTestVisible   GeometryHighlight7  1EmployeeManagementSystem.Converter.ColorConverter  colorConverter  GraphColor1  GraphColor2  GraphColor3  GraphColor4  GraphColor5  GraphColor6  GraphColor7 	 GraphColor8 
 GraphColor9  GraphColor10�� %R  &	        &	 +    &	 0    &	 A    &	 R    &	 c    &	 t    &	 �    &	 �    &		 �    &	
 �    &	 �    �� "  .���  � �� �	#FFFFFFFF��  � ��$ 1q���  � ��$ False����  �@ RatioStringFormat$ {0:p1}����  � �� �� "  .R�� $
��Root��$ 0Q�   CommonStates��   $ 0:0:0.1D�.	   
Normal��  	MouseOver��.
 �� .��W� $ MouseOverHighlight��$ Opacity� 0.6$ 0D�  SelectionStates��   $ 0:0:0.1D�.	   
Unselected��  Selected��.
 �� .��W� $ SelectionHighlight��$ Opacity� 0.6$ 0D�  RevealStates��   $ 0:0:0.5D�.	   	Shown��.
 �� .��W� $
 Root��$ Opacity� 1$ 0D�  
Hidden��.
 �� .��W� $
 Root��$ Opacity� 0$ 0D�.+�F� $��Slice��#��z #��z��#��z��$ 1Q� �� .+��� $
��Bold"�
��� � ����� *IndependentValue+ �� *TemplatedParent+�� ���� *DependentValue+ �� *TemplatedParent+F� $��SelectionHighlight��#��z ���	#FFFF0000$ 1Q�$ False��$ 0Q�F� $��MouseOverHighlight��#��z ���	#FFFFFFFF$ 1Q�$ False��$ 0Q�  ��#132a13����#31572c����#4f772d����#90a955����#87986a����#53a548����#344e41����#3a5a40����#588157����#a3b18a��.��� -   $��mainGrid��$��20q� � ColumnDefinitions �� ��  � RowDefinitions �� �� .+�>  8System.Windows.Controls.DataVisualization.Charting.Chart  -     Name$ DesignationWiseEmployee��$��0��$��0��   Title$ Designation-wise Employee��$��10q����� "  .R��� 
���   �$��1q�._��  �� $
��auto ��� $
��auto ��� $��* �.+���  K� ZIndex$ 99��$��30(�$
��Wrap=�$��0��#��z $��Center=�$��Center=�� $��1��$ 99�� � Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��0,0,0,0q�.+���  �� Orientation$ 
Horizontal=�$��0,0,10,0q�.+��� #��[ $��10��$��15���� $��Calibri)�$��5 0 5 0q�$��	Developer��
���   �$��Center=��� $ 
Horizontal=�.+��� #��[ $��10��$��15���� $��Calibri)�$��5 0 5 0q�$��Manager��
���   �$��Center=��� $ 
Horizontal=�.+��� #��[ $��10��$��15���� $��Calibri)�$��5 0 5 0q�$��Senior Developer��
���   �$��Center=��� $ 
Horizontal=�.+��� #��[ $��10��$��15���� $��Calibri)�$��5 0 5 0q�$��	Team Lead��
���   �$��Center=�M	  GSystem.Windows.Controls.DataVisualization.Charting.Primitives.EdgePanel	   	 Name$ 	ChartArea��$��2��   ChartAreaStyle#��z    Series. 3
  -EmployeeManagementSystem.Behaviours.PieSeries
  H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries    IndependentValuePath$  Designation��!   DependentValuePath$! Count��$��Stretch=�"   ItemsSource" �� *DesignationWiseEmployee+#   DataPointStyle# �� "  $ �� BasedOn#$ [  .���  � �� �� *Designation+% �� 	Converter#% [   -   $��employeeChart��$ Employee��
������ $��1��$��0��$	��10 q����� "  .R��� 
���   �$��1q�._��  �� $
��auto ��� $
��auto ��� $��* �.+��� $ 99��$��30(�$
��Wrap=�$��0��#��z $��Center=�$��Center=��� $��1��$ 99��$ 
Horizontal=�$��Center=�$	��Top=�$��0,10,0,0q�.+��� $ 
Horizontal=�$��0,0,10,0q�.+��� #��[ $��10��$��15���� $��Calibri)�$��5 0 0 0q�$
��Join��
���   �$��Center=��� $ 
Horizontal=�.+��� #��[ $��10��$��15���� $��Calibri)�$��5 0 0 0q�$��Release��
���   �$��Center=�	  $ 	ChartArea��$��2�� E  ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  
�������" �� *PastSixMonthJoinedEmployee+&   IndependentValueBinding& �� *Month+'   DependentValueBinding' �� *Count+# �� H  BSystem.Windows.Controls.DataVisualization.Charting.ColumnDataPoint"  .���  � �� �� "  .R�� .+��� #��[ ( � ToolTip( �� $
��Bold"�$��Calibri)����� *Month+�� $��Calibri)�$��0 5 0 0q�
�������$
��Bold"�$��Center=�$	��top=����� *Count+  ?  9System.Windows.Controls.DataVisualization.Charting.Series)   Title$) Released��" �� *PastSixMonthReleaseDataTable+& �� *Month+' �� *Count+# �� "  .���  � �� �� "  .R�� .+��� #��[ ( �� $
��Bold"�$��Calibri)����� *Month+�� $��Calibri)�
�������$
��Bold"�$��0 5 0 0q�$��Center=�$	��Top=����� *Count+*   Axes* E  ?System.Windows.Controls.DataVisualization.Charting.CategoryAxis  =  7System.Windows.Controls.DataVisualization.Charting.Axis+   Orientation$+ X=�$y�Hidden=�C  =System.Windows.Controls.DataVisualization.Charting.LinearAxis  D  >System.Windows.Controls.DataVisualization.Charting.DisplayAxis,   ShowGridLines$, False��$+ Y=�$y�Hidden=�  -   $ TechnologyWiseProject��$��0��$��1��$ Technology-wise Project��$��10q����� "  .R��� 
���   �$��1q�._��  �� $
��auto ��� $
��auto ��� $��* �.+��� $ 99��$��30(�$
��Wrap=�$��0��#��z $��Center=�$��Center=�� $��1��$ 99��$ 
Horizontal=�$��Center=�$	��Top=�$��0,10,0,0q�.+��� ���� *TechnologyNames+���� .R��� $ 
Horizontal=�.+��� $��5 0 0 0q�$��10��$��15������ *Id+#% [ �� $��Calibri)�$��5 0 0 0q�
���   �$��Center=����� *Name+���� .R�� $ 
Horizontal=�	  $ 	ChartArea��$��2��#��z . 
  -   - 
 Name$- TecnologyWiseProjectChart��$
  Name��$! Count��$��Stretch=�" �� *TechnologyWiseProject+# �� "  #$ [  .���  � �� �� *Id+#% [   -   $��SkillWiseEmployee��$ Skill-wise Employee��
������ $��1��$��1��$��10q����� "  .R��� 
���   �$��1q�._��  �� $
��auto ��� $
��auto ��� $��* �.+��� $ 99��$��30(�$
��Wrap=�$��0��#��z $��Center=�$��Center=�� $��1��$ 99��$ 
Horizontal=�$��Center=�$	��Top=�$��0,10,0,0q�.+��� ���� *SkillsNames+���� .R��� $ 
Horizontal=�.+��� $��5 0 0 0q�$��10��$��15������ *Id+#% [ �� $��Calibri)�$��5 0 0 0q�
���   �$��Center=����� *Name+���� .R�� $ 
Horizontal=�	  $ 	ChartArea��$��2��   
�������" �� *SkillWiseEmployee+& �� *Name+' �� *Count+# �� "  .���  � �� �� "  .R�� .+��� ���� *	SkillId+#% [ ( �� $
��Bold"�$��Calibri)����� *Name+�� $��Calibri)�
�������$��0 5 0 0q�$
��Bold"�$��Center=�$	��top=����� *Count+*   $+ X=�$y�Hidden=�  $, False��$+ Y=�$y�Hidden=�