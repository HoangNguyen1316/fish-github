   M S B A M L   `   `   `  ����B  >QLStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QLStore.StatisticQLStore.Statistic  5      ` \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5	      %    QLStore.Statistic.StatisticPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:QLStore.Statistic     5      gchart1Tclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5	      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         StatisticVM  � DataContext#  [  5       N� Title$ StatisticPage��5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��2��5      $��25��5      $��0q�5      $��Center=�5       $	��Top=�5!      $%��THỐNG KÊ LOẠI SẢN PHẨM��5"      $��Sitka Subheading)�5#      $��22(�5$      $
��Bold"�5%      �� 5&   
   $��2��5'      $��10,0,0,0q�5(      $��0q�5)      $>��8So sánh tỷ lệ bán được của từng loại (%)��5*      $��14(�5+      $��Light"�5,       J� Opacity$
 0.65Q�5-      -  'De.TorstenMandelkow.MetroChart.PieChart  50   
   $��2��51      $��2��52      $��5,0,5,0q�53      $��0q�54      $	��300��55      
������ .  (De.TorstenMandelkow.MetroChart.ChartBase   ChartTitleVisibility$ Hidden=�57      $��Sitka Subheading)�58         SelectedBrush
 ����    Series 5;      0  *De.TorstenMandelkow.MetroChart.ChartSeries  -   5        $��	pieChart1��5<         DisplayMember$ Type_Product1��5=      	   SeriesTitle$	 Tỷ trọng bán��5?      
   ValueMember$
 Num_Of_Product��5@      ��5>      ��  �� Path$ ListTypeProduct� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5@      5B      9  3De.TorstenMandelkow.MetroChart.ClusteredColumnChart  5E   
   $��1��5F      $��5,-15,5,-35q�5G      $��0q�5H      
������    ChartLegendVisibility$ Hidden=�5J         ChartSubTitle$+ %Số sản phẩm của từng loại��5K         
ChartTitle$  ��5L      $��Sitka Subheading)�5M       5O        -   5        $��columnChart1��5P      $ NameType��5Q      $	  ��5S      $
 
AmountType��5T      ��5R      �� $ ListInstanceStatistic�$ TwoWay=�$ PropertyChanged=�5T      5V        5Y   
   -   5        $��myChart��5Z      $��1��5[      $��1��5\      $��5,-15,5,-35q�5]      $��0q�5^      
������ $ Hidden=�5`      $3 -Số tiền bán được của từng loại��5a      $  ��5b      $��Sitka Subheading)�5c       5e        -   5        $��columnChart2��5f      $ NameType��5g      $	  ��5i      $
 TotalProceed��5j      ��5h      �� $ ListInstanceStatistic�$ PropertyChanged=�$ TwoWay=�5j      5l      �� 5o   
   $��25��5p      $��25��5q      $
��Left=�5r      $	��Top=�5s      
������ ���#303030-  'System.Windows.Input.NavigationCommands   
BrowseBack#��Z 5v       / +MaterialDesignFloatingActionMiniLightButton#��[ 5w      .��5x      '  !MaterialDesignThemes.Wpf.PackIcon  $��20��5y      $��20��5z         Kind$ KeyboardArrowLeft=�5{      5|      �� 5   
   $��25��5�      $��25��5�      $��28,0,0,0q�5�      $
��Left=�5�      $	��Top=�5�      
������ ���#303030   BrowseForward#��Z 5�      #��[ 5�      .��5�        $��20��5�      $��20��5�      $ KeyboardArrowRight=�5�      5�      	� 5�   
   -   5        $��rdoSpecific��5�      $��2��5�      $��1��5�      $��
145,30,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��THỜI GIAN CỤ THỂ��5�      $��Sitka Subheading)�5�      $��14(�5�      $
��Bold"�5�       	� 	GroupName$ 	Statistic��5�       d� 	IsChecked 5�      �� *IsChooseTemplateSelected+	� 5�   
   -   5        $��	rdoOption��5�      $��2��5�      $��0��5�      $��	10,30,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��THỜI GIAN TÙY CHỌN��5�      $��Sitka Subheading)�5�      $��14(�5�      $
��Bold"�5�      $ 	Statistic��5�      �� 5�   
   $��0��5�      $��1��5�      $��80��5�      $��0,5,10,0q�5�      $��Right=�5�      $	��Top=�5�      
����  �$��Refresh��5�       � ToolTip$ Đóng��5�      ��5�      �� *UpdateStatitis+5�      (  "System.Windows.Controls.DatePicker  5�   
   -   5        $��editFromDate��5�      $��2��5�      $	��170��5�      $��	30,60,0,0q�5�      $
��Left=�5�      $	��Top=�5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Từ ngày��5�      $��Sitka Subheading)�5�      $��14(�5�      $
��Bold"�5�       ( $MaterialDesignFloatingHintDatePicker#��[ 5�      {�5�      �� *	IsChecked+ �� ElementName$ 	rdoOption��   SelectedDate 5�      �� *StartTimePicker+$ OneWayToSource=�5�        5�   
   -   5        $��
editToDate��5�      $��2��5�      $	��170��5�      $��
30,110,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $ Đến ngày��5�      $��Sitka Subheading)�5�      $��14(�5�      $
��Bold"�5�      #��[ 5�      {�5�      �� *	IsChecked+$ 	rdoOption�� 5�      �� *EndTimePicker+$ OneWayToSource=�5�      �� 5�   
   -	   5        $��
ChooseYear��5�      $��2��5�      $��1��5�      $��70��5�      $��
130,65,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $
 Year��5�      
������ $��Sitka Subheading)�5�      $��14(�5�      $
��Bold"�5�       �� MaxDropDownHeight$	 100��5�       J� RenderTransformOrigin$ 0.482,0.071&�5�       & "MaterialDesignFloatingHintComboBox#��[ 5�      {�5�      �� *	IsChecked+$ rdoSpecific����5�      �� *
ListOption+ �� SelectedIndex 5�      �� *ItemIndexOption+5�      �� 5�   
   -
   5        $��editYear��5�      $��2��5�      $��1��5�      $��60��5�      $��
223,65,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $
 Year��5�      
������ $��Sitka Subheading)�5�      $��14(�5�      $
��Bold"�5�      $	 100��5�      $ 0.482,0.071&�5�      #��[ 5�      {�5�      �� *	IsChecked+$ rdoSpecific����5�      �� *
ListYear+ �� SelectedItem 5�      �� *ItemIndexYear+ �� SelectedValue 5�      �� *
YearFrom+$ TwoWay=�5�      �� 5   
   -   5        $��editWeek��5     $��2��5     $��1��5     $��90��5     $��
315,65,0,0q�5     $
��Left=�5     $	��Top=�5     $ 
ChooseItem��5     
������ $��Sitka Subheading)�5
     $��14(�5     $
��Bold"�5     $	 100��5     #��[ 5     {�5     �� *	IsChecked+$ rdoSpecific����5     �� *ListSpecificOptionView+$ PropertyChanged=� 5     �� *ItemIndexSpecific+5     5     5     