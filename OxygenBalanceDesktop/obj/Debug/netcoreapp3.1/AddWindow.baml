   M S B A M L   `   `   `  ����O  KOxygenBalanceDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OxygenBalanceDesktopOxygenBalanceDesktop  5   	   $    OxygenBalanceDesktop.AddWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OxygenBalanceDesktop     5   	      	AddButton  � Title#  �   5   	   $	��400��6-   $	��350��6:   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��0.5* �6   .+�5   
   ��   AddTextBoxIntroduction#���  6     TextBlockStyle12#���  6D   $��0��6o   $��2��6|   �� 5   
     GroupBoxStyle#���  6   $��1��6;   $��2��6H   .��5      �� .+�5      �� #���  6     AddName#���  6G   �� 5      -   5        $��	EnterName��5   M     TextBoxStyle#���  6   $��10q�6A   6^   5      5      �� 5   
   #���  6   $��2��6;   $��0��6H   .��5      �� .+�5      	� -   5        $��RadioBalance��5   x     RadioButtonStyle#���  6     BalanceRadioButton#���  6I   6�   �� 5      -   5        $��EnterBalance��5   M   #���  6   $��10q�6A   6a   5       5!      �� 5"   
   #���  6   $��2��6;   $��1��6H   .��5#      �� .+�5$      	� -   5        $��RadioFormula��5$   x   #���  6     FormulaRadioButton#���  6I   6�   �� 5%      -   5        $��EnterFormula��5%   M   #���  6   $��10q�6A   6a   5&      5'      �� 5(   
   -   5        $��	ShowLabel��5(   V    	 
LabelStyle#��� 	 6   $��3��65   $��2��6B   6V   �� 5)   
   -   5        $��	AddButton��5)   ~    
 ButtonStyle#��� 
 6   #���   67   $��4��6]   $��2��6j   6�   5*      5+      