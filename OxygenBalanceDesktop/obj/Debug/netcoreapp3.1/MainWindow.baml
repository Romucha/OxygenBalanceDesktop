   M S B A M L   `   `   `  ����O  KOxygenBalanceDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OxygenBalanceDesktopOxygenBalanceDesktop  5   	   %    OxygenBalanceDesktop.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OxygenBalanceDesktop     5   	   -   5        $��
BaseWindow��5	   M      OxygenStyles.xaml#���   5   	     MainWindowTitle  � Title#  �  5	   	   $	��700��63   $	��450��6@   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��1.1* �6   �� 5      $
��1.1* �6    � RowDefinitions 5   
   �� 5      $��0.75* �6   �� 5      $��0.75* �6   �� 5      $
��1.5* �6   �� 5      $��0.75* �6   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��0.75* �6   �� 5      $��0.75* �6   �� 5      $��1* �6   .+�5   
   o� -   5         o�Name$ MainMenu��5        	MenuStyle#��[ 6!   $��2��6D   .@�5      m� -   5          ResetButton#���  5      6>   m� 5      -   5          AboutButton#���  5      6>   m� 5        Language#���  6   .@�5      m� -   5        $��EnglishSwitch��5   8   $��English��6   
 � Tag$ en-US��6,   68   m� 5       -   5        $��RussianSwitch��5    8   $��Русский��6   $ ru-RU��6,   68   5!      m� 5"        
EditButton#���  6   .@�5#      m� -   5          	AddButton#���  5#      6@   m� 5$      -   5          RemoveButton#���  5$      6C   m� 5%      -	   5        $��RestoreMenu��5%   E    	 RestroreButton#��� 	 6   6E   5&      m� 5'      -
   5         
 CloseButton#��� 
 5'      6>   5(      �� 5)   
     
ChooseFuel#���  6   $��1��67   $��0��6D     
LabelStyle#��[ 6T   �� 5*   
     ChooseOxidizer#���  6   $��3��6;   $��0��6H   #��[ 6X   �� 5+   
     ChooseThirdElement#���  6   $��5��6?   $��0��6L   #��[ 6\   �� 5,   
     ChooseDoseOfThirdComponent#���  6   $��7��6G   $��0��6T   #��[ 6d   �� 5-   
   -   5        $��FuelShow��5-   Q   $��2��6   $��1��6   #��[ 6-   6Q   �� 5.   
   -   5        $��OxidizerShow��5.   Q   $��4��6   $��1��6   #��[ 6-   6Q   �� 5/   
   -   5        $��	ThirdShow��5/   Q   $��6��6   $��1��6   #��[ 6-   6Q   �� 50   
   -   5        $��ThirdDoseShow��50   U   $��7��6   $��1��6     TextBoxStyle#��[ 6/   6j   �� 51   
   -   5        $��CalculateButton��51   =     CalculateButton#���  6   $��2��6T   $��9��6h     ButtonStyle#��[ 6u   6�   �� 52   
   -   5        $
��Fuel��52      $��2��6   $��0��6,     ComboBoxStyle#��[ 6<   6c   �� 53   
   -   5        $��Oxidizer��53      $��4��6#   $��0��60   #��[ 6@   6g   �� 54   
   -   5        $��ThirdOne��54      $��6��6#   $��0��60   #��[ 6@   6g   �� 55   
   -   5        $��ThirdSlider��55   S   $��8��6   $��0��6     SliderStyle#��[ 6.   6f   56      57      