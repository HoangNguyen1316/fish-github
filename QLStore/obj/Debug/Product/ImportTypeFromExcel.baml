   M S B A M L   `   `   `  ����B  >QLStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:QLStore.ProductQLStore.Product  5   	   )    #QLStore.Product.ImportTypeFromExcel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:QLStore.Product     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  ImportTypeFromExcel��5	   	   $	��350��5   	   $	��500��6   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$
 Dark=�5      $��5q�5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5      .��5      � $��30��6   .+�5      �� $��Data will be added��5      $��18(�5      
�����_�$��Arial)�5      $��	ExtraBold"�5      $��Center=�5      $��Center=�5      �� 5      $��20��5      $��20��6!   
��� E�� J� Opacity$	 0.8Q�5!      
��� E��$��Right=�5#       /  +MaterialDesignFloatingActionMiniLightButton#��[  5$      .��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�5&      $��15��6&   $��15��62   5'      5(      5)      �� 5,   
   -   5        $	��100��5-      $��
Đồng ý��6   $
��Bold"�5.      
�������$��15(�50      $��Center=�51      $��Bottom=�52      
���"�"�$��Sitka Subheading)�54        MaterialDesignRaisedButton#��[ 56      $��196,0,196,12q�57   !   58      �� 5;   
   -   5        $��listData��5;      $��Sitka Subheading)�5<      $��13(�5=      $	��492��5>      $��	0,40,0,49q�5?      
���   �$
��Left=�5A       � 	Resources 5E       �� 
TargetType �� Property �� Value	 �� RelativeSource
 �� Path �� 
TargetType ]� Thumb ]� IncreaseRepeatButton ]� DecreaseRepeatButton��%�  '��       '�� �     �� 5F      " ��6   .�5G      ��  � ��$ CharacterEllipsis=�65   �� 5H       �@�ToolTip 60   �� 	 �� *Self+$

 Text�5I      �� 5J      " ��6   .�5K      ��  � ��$ 2,50,0,8q�6/   �� 5L       �@��IsFlicksEnabled .  6?   �� 5M       � ��
 ���� 63   �� 5N       � �� 5O      �� 5P      " ��6.   .R�5Q   "   ]� ��. |�.   5R   &   n� 5S   *   $��8��60   
��� � �6:    5U   &   �� 5V   *   $��ScrollBar.PageDownCommand��67   $ 0Q�6[   |�.  6g    5X   &   �� 5Y   *   $��ScrollBar.PageUpCommand��67   $ 0Q�6Y   |�.  6e   5[   #   5\      5^      5_      5`       �� View 5c      �� 5d      .P�5g      ��  �� Width$	 220��5h       �� DisplayMemberBinding 5i      �� *Type_Product_+ �� HeaderTemplate 5j      �� 5k      .R�5l   "   ��  J� Effect 5m   &   3  -System.Windows.Media.Effects.DropShadowEffect  5n   *      Color$ White��5o   -      	Direction$	 270Q�5p   -      ShadowDepth$ 1Q�5q   -      
BlurRadius$ 5Q�5r   -   ._�5t   &   �� $��
 Type Name��6,   $��1q�5u   (   $��15(�5v   (   
���   �$
��Bold"�5x   (   5y   #   5z      5|      �� 5~      $	 100��5       5�      �� *ID+ 5�      �� 5�      .R�5�   "   ��  5�   &     5�   *   $ White��5�   -   $	 270Q�5�   -   $ 1Q�5�   -   $ 5Q�5�   -   ._�5�   &   �� $��ID��6,   $��1q�5�   (   $��15(�5�   (   
���   �$
��Bold"�5�   (   5�   #   5�      5�      �� 5�      $	 155��5�       5�      �� *Num_Of_Product+ 5�      �� 5�      .R�5�   "   ��  5�   &     5�   *   $ White��5�   -   $	 270Q�5�   -   $ 1Q�5�   -   $ 5Q�5�   -   ._�5�   &   �� $��Current Amount��6,   $��1q�5�   (   $��15(�5�   (   
���   �$
��Bold"�5�   (   5�   #   5�      5�      5�      5�      �� 5�   
   -   5        $��emptyAnnounce��5�      $��Center=�5�      $��Center=�5�      $��Sitka Subheading)�5�      $��15(�5�      $y�Hidden=�5�      $`��ZKhông có dữ liệu nào hoặc dữ liệu đã tồn tại trong cơ sở dữ liệu��5�      5�      � 5�   
   -   5         �Name$ ProgressBar��5�      $��25��5�      $��25��6!    % !MaterialDesignCircularProgressBar#��[ 5�       � Triggers 5�      :� 5�       :� RoutedEvent$ Loaded��6   .[�5�      �� .��5�      �� .��5�      W�  �� TargetProperty$ Value�6.    W� From$ 0X�6P   	 W� To$	 100X�6Y    g� Duration$ 0:0:1D�6b    g� RepeatBehavior$ Forever��6s   5�      5�      5�      5�      5�      5�      