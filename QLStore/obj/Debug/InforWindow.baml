   M S B A M L   `   `   `  ����B  >QLStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:QLStoreQLStore  5   	       QLStore.InforWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:QLStore     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  InforWindow��5	   	   $	��300��6   $	��400��6+    � WindowStyle$
 None=�67    � 
ResizeMode$ NoResize=�6J   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��115* �6   �� 5      $
��384* �6   �� 5       � RowDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��3��6   
����� �.+�5      �� $��Center=�6   $��UTM Futura Extra)�65   $��16(�6S   
�������INFORMATION6�   5      �� 5   
   -   5         ��Name$ txbname��5      $��
 5 -2 2 0 q�5      $��1��5      $��1��6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Name Store��5       %  !MaterialDesignFloatingHintTextBox#��[  5       $��10,3,16.468,5q�5!      $��Candara)�5"      $��16(�5#      �� 5$   
   -   5        $ 
txbAddress��5&      $��
 5 -2 2 0 q�5%      $��1��5'      $��2��6   $ Address��5(      #��[  5)      $��10,3,16.468,10q�5*      $��Candara)�5+      $��16(�5,      �� 5-   
   -   5        $ txbMail��5.      $��
 5 -2 2 0 q�5/      $��1��50      $��3��6   $ Gmail��51      #��[  52      $��10,5,16.468,4q�53      $��Candara)�54      $��16(�55      �� 56   
   -   5         ��Name$ cmbstaff��57      $��40��58      $��1��59      $��4��6   $ Staff��5:      $��10,5,16.468,10q�5;      $��Candara)�5<      $��	 5 9 2 0 q�5=      $��16(�5>      �� 5?   
   -   5         ��Name$ btnedit��5@      
����� �$��1��5B      $��5��5C      $��Arial)�5D      $��15(�5E      $��
ExtraBlack"�5F      
������� $  MaterialDesignRaisedAccentButton#��[ 5H      	 � ToolTip$5	 /Resource name: MaterialDesignRaisedAccentButton��5I      $��213,12,23,12q�6?   .��6k   Edit5K      �� 5L   
   $
��Name��6   $��Corbel)�6   $��18(�63   
������$
��Left=�6Y   $��	35,22,0,0q�6t   $��1��6�   $	��Top=�6�   $
��Bold"�6�   �� 5M   
   $��Address��6   $��Corbel)�6"   $��18(�66   
������$
��Left=�6\   $��	19,17,0,0q�6w   $��2��6�   $	��Top=�6�   $
��Bold"�6�   �� 5N   
   $��Gmail��6   $��Corbel)�6    $��18(�64   
������$
��Left=�6Z   $��	35,22,0,0q�6u   $��3��6�   $	��Top=�6�   $
��Bold"�6�   �� 5O   
   $��
List staff��6   $��Corbel)�6%   $��18(�69   
������$
��Left=�6_   $��	13,14,0,0q�6z   $��4��6�   $	��Top=�6�   $
��Bold"�6�   �� 5P   
   -   5        $ btnSave��5Q      
����� �$��1��5S      $��5��5T      $��Arial)�5U      $��15(�5V      $��
ExtraBlack"�5W      
�������#��[ 5Z      $5	 /Resource name: MaterialDesignRaisedAccentButton��5[      $��116,12,115,12q�6G   $
��Save��6^   �� 5\   
   -   5        $ btnexit��5]      
����� �$��1��5_      $��5��5`      $��Arial)�5a      $��15(�5b      $��
ExtraBlack"�5c      
�������#��[ 5e   .   $5	 /Resource name: MaterialDesignRaisedAccentButton��5f      $��26,14,210,10q�6G   $
��Exit��6]   5h      5i      