   M S B A M L   `   `   `  ����O  KfitnessCenterProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:fitnessCenterProject.WindowsfitnessCenterProject.Windows  5   	   Q-clr-namespace:fitnessCenterProject.ValidationfitnessCenterProject.Validation  5   	   /    )fitnessCenterProject.Windows.Registration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:fitnessCenterProject.Windows     5   	   D
validation-clr-namespace:fitnessCenterProject.Validation     5   	     � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   
������� � Title$ Registration��5   	   $	��450��6   $	��650��6+   .��5      � .+�5   
   �� -   5        
�������$��Register��5   #   $
��Left=�66   $��26��6Q   $��138,359,0,0q�6]   $	��Top=�6r   $	��109��6�   6�   �� 5   
   -   5        
�������$
��Exit��5   #   $
��Left=�62   $��26��6M   $��406,359,0,0q�6Y   $	��Top=�6n   $	��110��6�   6�   �� 5   
   -   5        $��textBoxName��5      
���   �$
��Left=�69   $��24��6T   $��	96,90,0,0q�6`    �� TextWrapping$
 Wrap=�6s   $	��Top=�6�   $	��166��6�   �� 5   
   -   5        $��textBoxLastName��5      
���   �$
��Left=�6=   $��24��6X   $��
96,155,0,0q�6d   $
 Wrap=�6x   $	��Top=�6�   $	��166��6�   �� 5   
   -   5        $��textBoxJMBG��5      
���   �$
��Left=�69   $��24��6T   $��
96,222,0,0q�6`   $
 Wrap=�6t   $	��Top=�6�   $	��166��6�   �� 5   
   -   5        $��textBoxEmail��5      
���   �$
��Left=�6:   $��24��6U   $��447,222,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $	��166��6�   �� 5   
   -   5        $��textBoxPassword��5      
���   �$
��Left=�6=   $��24��6X   $��447,283,0,0q�6d   $
 Wrap=�6y   $	��Top=�6�   $	��166��6�   �� 5   
   $
��Bold"�6   $
��Name��6"   $
��Left=�61   $��24��6L   $��	24,90,0,0q�6X   $	��Top=�6k   $��57��6�   �� 5   
   $
��Bold"�6   $��	Last name��6"   $
��Left=�66   $��24��6Q   $��
24,155,0,0q�6]   $	��Top=�6q   $��67��6�   �� 5   
   $
��Bold"�6   $
��JMBG��6"   $
��Left=�61   $��24��6L   $��
24,222,0,0q�6X   $	��Top=�6l   $��57��6�    J� RenderTransformOrigin$ 0.543,-0.796&�6�   �� 5   
   $
��Bold"�6   $��Gender��6"   $
��Left=�63   $��24��6N   $��
351,86,0,0q�6Z   $	��Top=�6n   $��53��6�   $ 0.578,-0.284&�6�   �� 5   
   $
��Bold"�6   $��Select Address��6"   $
��Left=�6;   $��24��6V   $��351,151,0,0q�6b   $	��Top=�6w   $��91��6�   �� 5   
   $
��Bold"�6   $��Email��6"   $
��Left=�62   $��24��6M   $��351,218,0,0q�6Y   $	��Top=�6n   $��53��6�   �� 5   
   $
��Bold"�6   $��Password��6"   $
��Left=�65   $��24��6P   $��351,283,0,0q�6\   $	��Top=�6q   $��63��6�   �� 5   
   $
��11px(�6   $
��Bold"�6    $)��#I agree to the terms and conditions��62   $
��Left=�6`   $��30��6{   $��
24,283,0,0q�6�   $	��Top=�6�   $	��210��6�   $ 0.543,-0.796&�6�   �� 5   
   -   5        $��checkBoxAgree��5   &    d� 	IsChecked$ FalseY�6   
���   �$	��Yes��6O   $
��Left=�6]   $��24��6x   $��226,289,0,0q�6�   $	��Top=�6�   $��76��6�   �� 5    
   $
��Bold"�6   $��Registration��6"   $
��Left=�69   $��35��6T   $��
275,10,0,0q�6`   $	��Top=�6t   $	��117��6�   $
��18px(�6�   �� 5!   
   $
��Left=�6   $��24��6/   $��	24,45,0,0q�6;   $	��Top=�6N   $	��589��6f   �� 5"   
   -	   5        
�������$
��Back��5"   #   $
��Left=�62   $��26��6M   $��275,359,0,0q�6Y   $	��Top=�6n   $	��110��6�   6�   �� 5#   
   -
   5        $��comboBoxEnum��5#   E   
���   �$
��Left=�6Y   $��
447,92,0,0q�6t   $	��Top=�6�   $	��166��6�    �� Text 6   ��  �� Path$ Gender�6�   �� 5$   
   -   5        $��comboBoxAddresses��5$      $
��Left=�6,   $	��Top=�6G   $	��166��6_   $��447,157,0,0q�6k   5&      5'      