   M S B A M L   `   `   `  ����?  ;Yamb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YambYamb  5   	       
Yamb.Rules   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Yamb     5   	   -   5        ���#E2F1FC  � Title$  Yahtzee Rules��5	   	   $	��800��6   $	��600��6,    � Icon$ Images/logo.png��5
   	    � 
ResizeMode$ NoResize=�6     � 	Resources 5       �� 
TargetType   CoolButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 P� Property P� Value N� EnterActions �� TargetProperty	 �� To g� Duration N� ExitActions��%E  &	        �� 5   
   " ��6   .�5      ��  � �� �#B6DAF86+   �� 5       � ��
 �   �6+   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$	 150��6&   �� 5       � ��$	 200��6'   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Segoe UI)�6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 10��5      ._�5      �� $��Center=�6/   $��Center=�5   ,   5       5!      5#      	 5&      P� 5'      
 �@J�IsMouseOver .  5(      �� 5)      .��5*      �� .��5+   "   �� $1 +(Button.Background).(SolidColorBrush.Color)�61   $ #A2CFF2X�5,   .   $ 0:0:0.3D�5-   .   5.      5/       51      �� 52      .��53      �� .��54   "   �� $1 +(Button.Background).(SolidColorBrush.Color)�61   $ #B6DAF8X�55   .   $ 0:0:0.3D�56   .   57      58      5:      5<      5=      .��5>      � .+�5?   
   �� $��RULES��6   $��Center=�6!   $	��Top=�6>   $��40(�6V   $��Segoe UI)�6d   $��SemiBold"�6z   $��0 10 0 0q�6�   �� 5@   
   $��15(�6   $
��Left=�6"   $	��237��6=   $��42��6I   $	��Top=�6U   $��	62,87,0,0q�6m   $��SemiBold"�6�   $+��%Description of the rows in the table:��6�   �� 5A   
   $��14(�6   $
��Left=�6"   $	��445��6=   $��42��6I   $	��Top=�6U   $��
62,116,0,0q�6m   $E��?1. Ones to sixes - the sum of five dice with the selected value��6�   �� 5B   
   $��14(�6   $
��Left=�6"   $	��372��6=   $��41��6I   $	��Top=�6U   $��
62,144,0,0q�6m   $.��(2. Maximum - a maximum sum of five dice:��6�   �� 5C   
   $��14(�6   $
��Left=�6"   $	��348��6=   $��43��6I   $	��Top=�6U   $��
62,167,0,0q�6m   $-��'3. Minimum - a minimum sum of five dice��6�   �� 5D   
   $��14(�6   $
��Left=�6"   $	��499��6=   $��42��6I   $	��Top=�6U   $��
62,194,0,0q�6m   �� 6�   $T�N4. Scale - the selected dice must have the values ​​1,2,3,4,5 (40 points) ��6�   �� 6�   �� 6�   $#�     or 2,3,4,5,6 (50 points)��6�   6  �� 5E   
   $��14(�6   $
��Left=�6"   $	��462��6=   $��41��6I   $	��Top=�6U   $��
62,241,0,0q�6m   �� 6�   $I�C5. Trilling - 3 of the same dice. 20 points are added to the sum of��6�   �� 6�   �� 6�   $�    those three dice��6�   6  �� 5F   
   $��14(�6   $
��Left=�6"   $	��516��6=   $��42��6I   $	��Top=�6U   $��
62,283,0,0q�6m   �� 6�   $V�P6. Full - 3 of the same + 2 of the same dice. 30 points are added to the sum of ��6�   �� 6�   �� 6�   $�    those five dice��6�   6  �� 5G   
   $��14(�6   $
��Left=�6"   $	��435��6=   $��41��6I   $	��Top=�6U   $��
62,325,0,0q�6m   �� 6�   $F�@7. Poker - 4 of the same dice. 40 points are added to the sum of��6�   �� 6�   �� 6�   $�    those four dice��6�   6�   �� 5H   
   $��14(�6   $
��Left=�6"   $	��496��6=   $��42��6I   $	��Top=�6U   $��
62,366,0,0q�6m   �� 6�   $I�C8. Yahtzee - 5 of the same dice. 50 points are added to the sum of ��6�   �� 6�   �� 6�   $�    those five dice��6�   6  �� 5J   
   $��Images/arr.png��6   $��44,456,438,308q�6(    J� RenderTransformOrigin$ 0.5,0.5&�6@   $��20��6`   z�5K      V� 5L      .~�5M      �� �� 5N      �� 5O       �� Angle$ 90Q�6&   T� 5P      5Q      5S      �� 5T   
   $��Images/arr.png��6   $��44,492,438,272q�6(   $ 0.5,0.5&�6@   $��20��6`   z�5U      V� 5V      .~�5W      �� �� 5X      �� 5Y      $	 -90Q�6&   T� 5Z      5[      5]      �� 5^   
   $��15(�6   $
��Left=�6"   $	��316��6=   $��40��6I   $	��Top=�6U   $��
62,424,0,0q�6m   $��SemiBold"�6�   $.��(Description of the columns in the table:��6�   �� 5_   
   $��15(�6   $
��Left=�6"   $	��326��6=   $��39��6I   $	��Top=�6U   $��122,452,0,0q�6m   $��- Only fills down��6�   �� 5`   
   $��14(�6   $
��Left=�6"   $	��360��6=   $��38��6I   $	��Top=�6U   $��122,491,0,0q�6m   $��- Only fills up��6�   �� 5a   
   $��14(�6   $
��Left=�6"   $	��336��6=   $��40��6I   $	��Top=�6U   $��
96,524,0,0q�6m   $'��!Free - Filled in by choice (Free)��6�   �� 5b   
   $��14(�6   $
��Left=�6"   $	��482��6=   $��39��6I   $	��Top=�6U   $��
96,549,0,0q�6m   $C��=Call - Must be announced after the first throw (Announcement)��6�   �� 5d   
   $��15(�6   $
��Left=�6"   $	��482��6=   $	��110��6I   $	��Top=�6V   $��
62,588,0,0q�6n   $��SemiBold"�6�   �� 6�   $O�IAfter the last throw, the result is automatically calculated according to��6�   �� 6�   �� 6�   $"�the formula for the columns:��6   6'  �� 5e   
   $��14(�6   $
��Left=�6"   $	��482��6=   $��38��6I   $	��Top=�6U   $��
62,640,0,0q�6m   �� 6�   $9�3Rk=1+2+3+4+5+6+A+(Maximum-Minimum)*Ones+S+T+F+P+Y, ��6�   �� 6�   �� 6�   $1�+where A=30 only if 1+2+3+4+5+6>=60 else A=0��6�   6  �� 5f   
   -   5        $��CloseButton��5f      $��Close��6$   $	��264��64   $��52��6@   #��[  6f   $��Bottom=�6�   $��0 0 0 10q�6�   5g      5h      