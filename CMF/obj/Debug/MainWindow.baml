   M S B A M L   `   `   `  ����>  :CMF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CMFCMF  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       CMF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:CMF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a;mat1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Jcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  CMF Tool��5   	   $	��700��6   $	��800��6'    � DataContext 5	   	   �� *Main+   Locator �� Source# [  .��5      �  � ColumnDefinitions 5   
   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��0.5* �6   6,   �� 5      6   .+�5   
   �� $��FindActionGroup��6   $��14(�6,   $
��Bold"�6:   .��5      � .+�5      �� .+�5      � $��40��6    5      �� 5      $
��0.2* �6/   6>   �� 5      61   �� 5      $
��0.2* �6/   6>   .+�5      �� $
��URL:��6$   $��16(�60   $
��Bold"�6>   $��Center=�6P   6m   �� 5      $��0,0,10,0q�6"   $��1��6I   $��Center=�6Y   ��64   �� *URL+6}   �� 5       $��2��6!   $��40��61   +  %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Normal=�6=      MaterialDesignOutlinedButton#��[ 6u   
���   �
���   �
�������$��Generate��6�   ��6�   �� *GenerateURLCommand+6!  5!      � 5#      $��40��6    5$      �� 5%      $��0.17* �6/   6?   �� 5&      61   .+�5(      �� $
��Pre:��6$   $��16(�60   $
��Bold"�6>   $��Center=�6P   6m   �� 5)       �� 
IsReadOnly . $��2��64   $��16(�6d   $
��Bold"�6r   $	��0,4q�6�   $��Center=�6�   ��6D   �� *ActionGroupPre+6�   5*      � 5,      $��40��6    5-      �� 5.      $��0.17* �6/   6?   �� 5/      61   .+�51      �� $��Post:��6$   $��16(�61   $
��Bold"�6?   $��Center=�6Q   6n   �� 52       . $��2��64   $��16(�6e   $
��Bold"�6s   $	��0,4q�6�   $��Center=�6�   ��6D   �� *ActionGroupPost+6�   53      54      55      56      �� 57   
   $��GetUseReferences��6   $��1��6-   $��14(�6:   $
��Bold"�6H   .��58      �  59      �� 5:      6)   �� 5;      6)   .+�5=      �� 
�������$��0,0,2,0q�6,   $	��0,2q�6F   6U   � 5>       5?      �� 5@      $��0.15* �6(   69   �� 5A      6*   .+�5C      � $��1��6    5D      �� 5E      6.   �� 5F      6.   .+�5H      �  5I      �� 5J   "   $��0.15* �60   6A   �� 5K   "   62   .+�5M      �� $��
Dll Files:��6(   6=   �� 5N      $��1��6(   $
��Auto=�65   ��6e   �� *DllFilesName+6�   5O      � 5P      $��2��6   .+�5Q      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$9 3Copy using to this textbox(Removing and sort first)��6'    ! MaterialDesignOutlinedTextBox#��[ 6q   $��1��6�    �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�6�   ��6�   �� *	UsingText+6�   5R      5S      � 5T       5U      �� 5V      61   �� 5W      61   .+�5Y      �� $��0��6K   $	��5,5q�6[   $ Normal=�6h   #��[ 6�   
���   �
���   �
�������$��Insert dll files��6  ��6!   �� *InsertDllFilesCommand+6-  �� 5Z      $��2��6R   $	��5,5q�6b   $ Normal=�6o   #��[ 6�   
���   �
���   �
�������$��GenerateDeeReferences��6  ��6!   �� *GenerateDeeReferencesCommand+69  5[      5]      �� 5^       . $ Dee References��6,   #��[ 6Q   $��2��6�    . $
	 Wrap=�6�   ��6�   �� *	DeeResult+6�   5`      5a      5b      5c      