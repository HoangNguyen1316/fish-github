   M S B A M L   `   `   `  ����B  >QLStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QLStore.Staff_QLStore.Staff_  5   	       QLStore.Staff_.InforStaff   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:QLStore.Staff_     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStyle$
  None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   
������� � Title$ Information Staff��5   	   $	��320��6#   $	��600��60   .��5      � $��-4,0,4,0q�6    � ColumnDefinitions 5   
   �� 5      $
��0.6* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!   $��4��6.   $��
12,37,36,0q�6?    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��5   %      	Direction$	 270Q�5   %      ShadowDepth$ 1Q�5   %   	   
BlurRadius$	 10Q�5    %   ._�5"      �� -   5        $	��img��5%      $��UniformToFill=�5"      $	��152��6,   $��Stretch=�5#      $��Bottom=�5$      $��
29,0,25,10q�5%      5'      �� 5(   
   -   5        
 ��Name$
 txbName��51   '   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��5(       %  !MaterialDesignFloatingHintTextBox#��[  5)      $��0��5*      $��1��5+      $��16(�5,      $��0 0 0 0q�5-      
���iii� �� 
IsReadOnly . $��Cambria)�51      $��
10,0,123,0q�68   �� 52   
   -   5        $
 txbPhone��5:   '   $ Phone��52      #��[  53      $��1��54      $��1��55      $��16(�56      $��5 -1 0 0q�57      
���iii� . $��Cambria)�5:      $��	10,0,72,0q�5;      �� 5<   
   -   5        $
 txbID��5D   "   $ ID��5<      #��[  67   $��0��5=      $��1��5>      $��16(�5?      $��0 0 0 0q�5@      
���iii� . $��Cambria)�5D      $��
274,0,10,0q�61   �� 5F   
   -   5        $
 
txbAddress��5M   '   $ Address��5F      #��[  6<   $��2��5G      $��1��5H      $��16(�5I      $��5 -1 0 0q�5J      
���iii� . $��Cambria)�5M      $��	10,0,72,0q�6<   �� 5O   
   -   5        $
 txbBirth��5V   '   $ Birthday��5O      #��[  6=   $��4��5P      $��0��5Q      $��16(�5R      $��5 -1 0 0q�5S      
���iii� . $��Cambria)�5V      $
��10,0q�6:   �� 5X   
   -   5        $
 txbStart��5_   '   $ 	Start day��5X      #��[  6>   $��5��5Y      $��0��5Z      $��16(�5[      $��5 -1 0 0q�5\      
���iii� . $��Cambria)�5_      $��
10,0,10,10q�6:   �� 5a   
   -   5        $
 txbPos��5h   '   $ Position��5a      #��[  6=   $��3��5b      $��1��5c      $��16(�5d      $��5 -4 0 0q�5e      
���iii� . $��Cambria)�5h      $
��10,0q�68   �� 5j   
   -	   5        $
 txbsex��5q   '   $	 Sex��5j      #��[  68   $��4��5k      $��1��5l      $��16(�5m      $��5 0 0 0q�5n      
���iii� . $��Cambria)�5q      $��
10,0,201,2q�68   $��52��6L   $��Bottom=�6X   �� 5s   
   -
   5         ��Name$ btnexit��5s       � ToolTip$
 exit��5t      $��Right=�5u      $��
0,0,185,27q�5v      $��25��5w      $��25��6    , (MaterialDesignFloatingActionAccentButton#��[ 5x      ���	#FFF0974B
�������$��Bottom=�6�   ��6   Z� .��5z      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Multiply=�5{      $��20��5|      $��20��5}      5~      � 5�   
   -   5         �Name$ ProgressBar��5�       % !MaterialDesignCircularProgressBar#��[ 5�      $��1��5�   +   $��78,35,270,2q�6;   $��2��6P   $
��Auto��6]    � Triggers 5�      :� 5�       :� RoutedEvent$ Loaded��6   .[�5�      �� .��5�      �� .��5�      W�  �� TargetProperty$ Value�6.    W� From$ 0X�6P   	 W� To$	 100X�6Y    g� Duration$ 0:0:1D�6b    g� RepeatBehavior$ Forever��6s   5�      5�      5�      5�      5�      5�      