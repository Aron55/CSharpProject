   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      Q MdotNetWPF_03_6274_2436, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:dotNetWPF_03_6274_2436dotNetWPF_03_6274_2436 5      /   )dotNetWPF_03_6274_2436.PrinterUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      6local$clr-namespace:dotNetWPF_03_6274_2436     5      -   5          >�Name$  userControl��5      $
��Auto��5
   7   $
��Auto��6D   $��1q�6R   ���	#FF080505.��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��Stretch=�6   $��2��6-   $��Stretch=�6:   $
��Auto��6V   $
��Auto��6c    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��1* �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� -   5        $��InkLabel��5      $�� Ink :��6$   �� 5      -   5        $��	PageLabel��5      $��Pages :��6%   $��1��67   $��0��6D   � 5      -   5        $��InkCountProgressBar��5      $��0��65   $��1��6B    � Value$ 0Q�6R    � ToolTip 5      �� *Value+ �� ElementName$ InkCountProgressBar�� �� StringFormat$ {0:P}��5      �� 5       -   5        $��PageCountSlider��5       $��1��6,   $��1��69   $ 0Q�6I    � Maximum$	 400Q�5!      5"      5#      �� 5$   
   $��0��6   $��Images/Printer.jpg��6   �� 5%   
   -   5         ��Name$ PrinterNameLabel��5%   #   $��Printer ��6   $��Center=�6=   $��1��6Z   $��Center=�5&      
����iA�$��16(�6B   5'      5)      5*      