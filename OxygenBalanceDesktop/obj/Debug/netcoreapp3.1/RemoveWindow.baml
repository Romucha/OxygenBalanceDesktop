   M S B A M L   `   `   `  ����O  KOxygenBalanceDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OxygenBalanceDesktopOxygenBalanceDesktop  5   	   '    !OxygenBalanceDesktop.RemoveWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OxygenBalanceDesktop     5   	      RemoveButton  � Title#  �   5   	   $	��300��60   $	��250��6=   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $
��0.5* �6   .+�5   
   ��   ChooseElementToRemove#���  6     TextBlockStyle#���  6C    �� Padding$ 0q�6l   $��12(�6x    �� TextAlignment$ Center=�6�   $��0��6�   �� 5   
   -   5        $��
RemoveList��5   ;     ComboBoxStyle#���  6   $��1��6M   6Z   �� 5   
   -   5        $��RemoveLabel��5   5     
LabelStyle#���  6   $��2��6H   �� 5   
   -   5        $��RemoveButton��5   `   #���   6     ButtonStyle#���  6:   $��3��6�   5      5      