   M S B A M L   `   `   `  ����O  KfitnessCenterProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:fitnessCenterProject.WindowsfitnessCenterProject.Windows  5   	   7    1fitnessCenterProject.Windows.InstructorMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:fitnessCenterProject.Windows     5   	   
�������  � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ 
Instructor��5   	   $	��650��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��63* �6   �� 5      $
��334* �6   .+�5   
   �� -   5        
�������$��LogOut��5   $   $
��Left=�65   $��129,551,0,0q�6P   $	��Top=�6e   $	��100��6}   $��33��6�   $��1��6�   �� 5   
   -   5        
�������$
��Exit��5   #   $
��Left=�62   $��297,551,0,0q�6M   $	��Top=�6b   $	��100��6z   $��33��6�   $��1��6�   �� 5   
   $
��Bold"�6   $��22(�6"   $��
Instructor��60   $
��Left=�6E   $	��Top=�6`   $��1��6x   $��
204,31,0,0q�6�   �� 5   
   $
��Left=�6   $��28��6/   $��	66,75,0,0q�6;   $	��Top=�6N   $	��656��6f   $��2��6r   �� 5   
   $
��Bold"�6   $��16(�6"   $��	User Data��60   $
��Left=�6D   $	��Top=�6_   $��1��6w   $��219,103,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $'��!instructorDataInformationDataGrid��5   �      AutoGenerateColumns . 
���   �   
IsReadOnly . $
��Left=�6�   $��57��6�   $	��Top=�6  $	��528��6   $��1��6,  $��
10,160,0,0q�6<   �� SelectedItem 6�   ��  �� Path$ selectedInstructor�6<  �� 5   
   -   5        
�������$��Check Beginners��5   #   $
��Left=�6=   $	��Top=�6X   $	��100��6p   $��1��6|   $��360,250,0,0q�6�   $��33��6�   6�   �� 5   
   -   5        
�������$��Check Trainings��5   #   $
��Left=�6=   $	��Top=�6X   $��97��6p   $��1��6{   $��
78,250,0,0q�6�   $��33��6�   6�   �� 5   
   -   5        
�������$��Change Data��5   #   $
��Left=�69   $	��Top=�6T   $	��100��6l   $��1��6x   $��219,250,0,0q�6�   $��33��6�   6�   �� 5   
   -   5        
�������$��Create Training��5   #   $
��Left=�6=   $	��Top=�6X   $	��100��6p   $��1��6|   $��148,475,0,0q�6�   $��31��6�   6�   �� 5   
   -   5        
�������$��Delete Training��5   #   $
��Left=�6=   $	��Top=�6X   $	��100��6p   $��1��6|   $��280,475,0,0q�6�   $��31��6�   6�     5   
   -	   5        $��trainingInformations��5   �    . 
���   � . $
��Left=�6�   $��84��6�   $	��Top=�6�   $	��528��6  $��1��6  $��
10,363,0,0q�6,   6   �� $ selectedTraining�6,  �� 5   
   $
��Bold"�6   $��16(�6"   $��Trainings data��60   $
��Left=�6I   $	��Top=�6d   $��1��6|   $��204,314,0,0q�6�   5      5       