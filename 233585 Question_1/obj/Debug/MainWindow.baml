   M S B A M L   `   `   `  ����  
Question_1    Question_1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Aav2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6G     � Title$  Student Progress Tracker��5   	   $	��450��6*   $	��800��67   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��207* �6   �� 5	      $
��193* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10,10,10,10q�6;   $��2��6P   .+�5      �� -   5         ��Name$ GradeFilter��5      $	��150��6-   $��5q�69   �� 5      -   5        $ SubjectFilter��5      $	��150��6/   $��5q�6;   �� 5      -   5        $��Apply Filter��5      $	��100��6,   $��5q�68   6C   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ StudentDataGrid��5      $��1��6,      AutoGenerateColumns .  $��10,10,231,10q�6U      
IsReadOnly . $��2��6}      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     5      $	 Grade��6%   $	
 100 6N    64   �� *Grade+6N     5      $	 Subject��6%   $	
 150 6R    66   �� *	Subject+6R     5      $	 Marks��6%   $	
 100 6N    64   �� *Marks+6N     5      $	 Attendance (%)��6%   $	
 150 6\    6=   �� *
Attendance+6\   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5      �� -   5        $��Add Student��5      $	��100��6+   $��5q�67   6B   �� 5       -   5        $��Edit Student��5       $	��100��6,   $��5q�68   6C   �� 5!      -   5        $��Delete Student��5!      $	��100��6.   $��5q�6:   6E   � 5"      -   5         �Name$ GradeProgressBar��5"      $	��200��64   $��20��6@   $��5q�6L   $y�	Collapsed=�6W   5#      5$      5%      