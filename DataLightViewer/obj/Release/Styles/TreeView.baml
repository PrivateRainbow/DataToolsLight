   M S B A M L   `   `   `  ���� J  FDataLightViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DataLightViewer.BehaviorsDataLightViewer.Behaviors  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Property �� Value �� 
TargetType   ExpandCollapseToggleStyle'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName	 R� KeyTime  System.Windows.Visibility
   Hidden R� Value   Visible F�Name  
GlyphColor �� Color  LatoThin  FontSizeRegular �� Mode4   .DataLightViewer.Behaviors.TreeViewItemBehavior � ColumnDefinitions � RowDefinitions d�Name �� 	ClickMode d� 	IsChecked �� RelativeSource ��Name �� CornerRadius �� Padding ��Name � LayoutTransform ��Name �� Triggers P� Property P� Value �� 
TargetName  ]� 
Conditions! �� Property" �� Value  BackgroundBlueBrush  ForegroundWhiteBrush# P� 
SourceName$ N� EnterActions% g� Duration	& W� To' N� ExitActions�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     0bhvr'clr-namespace:DataLightViewer.Behaviors  %%
  'R�       &	      'Q� i    7  7  7   7  7  �� "  R�.���  �@�OverridesDefaultStyle . ��  �@J�SnapsToDevicePixels . ��  � ��$
 Auto=���  � ��$
 Auto=���  � ��
 �������  � �� �� " R�.R��� $��Border��#��z��#��z��#��z��._��� |�.  ��.  $��4q�.���� �� "  d�.���  � ��
 �������  � |� .  ��  � �� �� " d�.R�� $��15��$��13��
������    CheckStates��.   Checked��. �� .��T� $ (UIElement.Visibility)�$ 	Collapsed��..�i� $	 0��# Z
 T� $ (UIElement.Visibility)�$ Expanded��..�i� $	 0��# Z   	Unchecked��  Indeterminate��.+�F� $ 	Collapsed��$
��Left=�$��Center=�$��1,1,1,1q�"���� 	=     � z  	= � 	=  z 	���� # �  F� $ Expanded��$
��Left=�$��Center=�$��1,1,1,1q�"����     	= � z  	= � 	=  z 	$y�Hidden=����� # �  �� "  Q�.���  � ��
 ���� ��  � ��$
 Left=���  � ��$ Center=���  � ��8   ��  � ��8  ��  � ��$ Normal"���  �@Q�
IsExpanded �� *
IsExpanded+$ TwoWay=���  �@Q�
IsSelected �� *
IsSelected+��  �@ ContextMenuClicked . �� % �@ IsBroughtIntoViewWhenSelected . ��  � �� �� " Q�.R��  �� $��19��$
��Auto ��� $
��Auto ��� $��* � �� $
��Auto ���    ExpansionStates��.   Expanded��. �� .��T� $ (UIElement.Visibility)�$ 	ItemsHost��..�i� $	 0��# Z   	Collapsed��.+�d� $ Expander��8�� $ Press=� �� *
IsExpanded+ �� *TemplatedParent+�� $ Bd��$��1��$ 5��#��z��#��z��#��z��# z��._��� $ PART_Header��$��Header��#��z�� �� �� $ 	ItemsHost��$��1��$��1��$��2��$y�	Collapsed=� P�  �@��HasItems .  . ��� $ Expander�� � y�$ Hidden=�]�   �� ! � ��" .  �� ! � ��$
" Auto��./��� $ PART_Header�� � ��$ 75��]�   �� ! � ��" .  �� ! � ��$
" Auto��./��� $ PART_Header�� � ��$ 19��P�  �@Q�
IsSelected . . ��� $ Bd��8   � ���� $ Bd��8   � ���� $ Bd�� �@��Padding$ 5q�P� $# PART_Header�� �@J�IsMouseOver . $ �� .���� .��W� $ PART_Header��$ LayoutTransform.ScaleX�$% 0:0:0.15D�$	& 1.2X�W� $ PART_Header��$ LayoutTransform.ScaleY�$% 0:0:0.15D�$	& 1.2X�' �� .���� .��W� $ PART_Header��$ LayoutTransform.ScaleX�$% 0:0:0.15D�$& 1X�W� $ PART_Header��$ LayoutTransform.ScaleY�$% 0:0:0.15D�$& 1X�