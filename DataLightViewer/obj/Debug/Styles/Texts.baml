   M S B A M L   `   `   `  ����J  FDataLightViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DataLightViewer.AttachedProperties"DataLightViewer.AttachedProperties  5      G(clr-namespace:DataLightViewer.ConvertorsDataLightViewer.Convertors  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089] YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310  �� MergedDictionaries �� Source   	BoolToVis  BaseControlStyle �� 
TargetType �� Property �� Value  LatoThin  FontSizeRegular �� BasedOn  BaseTextBoxStyle  	SqlEditor'   !ICSharpCode.AvalonEdit.TextEditor  FontSizeRegularX  ForegroundEditorLineBrush  SearchNodeTextBox 	 LoginTextBoxWithPlaceholder 
 LatoBold  BackgroundBlueBrush  ForegroundWhiteBrush # LoginPasswordBoxWithPlaceholder�   �DataLightViewer.BaseAttachedProperty`2[[DataLightViewer.AttachedProperties.MonitorPasswordProperty, DataLightViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]  PlaceholderTextBoxTemplate �� 
TargetType ��Name J� SnapsToDevicePixels	 ��Name
 ��Name J� IsHitTestVisible
 � Tag �� Padding �� Triggers �� Binding �� RelativeSource �� Value �� Triggers P� Property P� Value �� 
TargetName " PlaceholderPasswordBoxTemplate �� 	ConverterD   >DataLightViewer.Convertors.InvertedBooleanToVisiblityConverter�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      =attached0clr-namespace:DataLightViewer.AttachedProperties  5      3cvtors(clr-namespace:DataLightViewer.Convertors  5      ;avalon.http://icsharpcode.net/sharpdevelop/avalonedit  5        5      �� 5	   
   $ Colors.xaml?�6   �� 5
   
   $ 
Fonts.xaml?�6   %9  &	        &	      7  7  '�� �     7  &	 �     7  &	 ^    7  7  &	 
    7  &		 V    7  7  7 
 7  7  &	 h    7  7 
 7  7  &	 �    7  &	 c	    7  �� 5      6#   �� 5      " ��6%   .�5   
   ��  � ��
 �����6'   �� 5   
    � ��8   6'   �� 5   
    � ��8  6'   �� 5   
    � ��$ Normal"�6'   5      �� 5      " ��6   8   6+   �� 5      " ��6%   8   .�5   
   ��  � ��$
 Left=�67   �� 5   
    � ��$ Center=�65   5      �� 5      "   6   .�5   
   ��  � ��8   6%   �� 5   
    � ��$ Consolas)�6'   �� 5!   
    �@  WordWrap . 6%   �� 5"   
    �@  ShowLineNumbers . 6,   �� 5#   
    �@  LineNumbersForeground8  62   �� 5%   
    � ��$	 Top=�65   �� 5&   
   % �@  HorizontalScrollBarVisibility$
 Auto=�6:   �� 5'   
   # �@  VerticalScrollBarVisibility$
 Auto=�68   5(      �� 5*      " ��6&   8   .�5+   
   ��  � ��$ 5q�6$   5,      �� 5/      " ��60   8   .�51   
   ��  � ��8  6%   �� 52   
    � ��8  6'   �� 54   
    � ��$ 5q�6$   �� 55   
    � ��$ 5q�6#   �� 57   
    � ��8  6(   �� 58   
    � ��$ 2q�6,   �� 5:   
    � ��8  6'   5<      �� 5=      " G�64   .�5?   
   ��  � ��8   6%   �� 5@   
    � ��8  6'   �� 5B   
    � ��$ 5q�6$   �� 5C   
    � ��$ 5q�6#   �� 5E   
    � ��8  6(   �� 5F   
    � ��$ 2q�6,   �� 5H   
    � ��8  6'   �� 5I   
    �@ Value . 6C   5L      �� 5N      " ��69   .R�5O   
   � .+�5P      �� $ border��6   #��z��5Q   !   #��z��5R   !   #��z��5S   !    . ._�5U      �� $	 PART_ContentHost��6   |�.  $��Hidden=�6K   $��Hidden=�6r   5V      �� 5X      $
 placeholder��5Z   $    .  #��z 5Y   $   8��  # z��5\   $   $��Center=�5]   $   #��z��5^   $   ��5_      �� 5`      " ��6   .�5a      ��  � y�$ 	Collapsed=�67    5b      �� 5c       6*   �� *Text+ �� *TemplatedParent+  6t   .a�5d   "   ��  � y�$ Visible=�6?   5e      5g      5j      5l       5n   
   P� 5o       � {� .  . �5p      �� $ border��6,    �@J�Opacity$
 0.56Q�6@   5q      P� 5r       �@J�IsMouseOver . . �5s      �� $ border��60    � �� �	#FF7EB4EA6D   5t      P� 5u       �@J�IsKeyboardFocused . . �5v      �� $ border��60    � �� �	#FF569DE56D   5w      5z      �� 5{      " G�6=   .R�5|   
   � .+�5~      �� $ border��6   #��z��5   !   #��z��5�   !   #��z��5�   !    . ._�5�      �� $	 PART_ContentHost��6   |�.  $��Hidden=�6K   $��Hidden=�6r   5�      �� 5�      $
 placeholder��5�   $    .  #��z 5�   $   8��  #��z��5�   $   # z��5�   $   $��Center=�5�   $   #��z��5�   $   y�5�   $   �� * attached:HasTextProperty.Value+   5�   $   5�       5�   
   P� 5�       � {� .  . �5�      �� $ border��6,    �@J�Opacity$
 0.56Q�6@   5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ border��60    � �� �	#FF7EB4EA6D   5�      P� 5�       �@J�IsKeyboardFocused . . �5�      �� $ border��60    � �� �	#FF569DE56D   5�      5�      5�      