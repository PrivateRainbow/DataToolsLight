   M S B A M L   `   `   `  ����J  FDataLightViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:DataLightViewer.BehaviorsDataLightViewer.Behaviors  5   	   C&clr-namespace:DataLightViewer.ControlsDataLightViewer.Controls  5   	   +    %DataLightViewer.Views.Main.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   /b'clr-namespace:DataLightViewer.Behaviors  5   	   5controls&clr-namespace:DataLightViewer.Controls  5   	     � WindowStartupLocation$  CenterScreen=�5
   	    � Title$ DataLightViewer��5   	   $	��450��6!   $	��650��6.   .��5      �    BackgroundBlueBrush#��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��Auto �6   �� 5      $
��0.6* �6   .+�5    
   � $��0��6   $��0��5!      $��3��5"      .+�5$      o�   ForegroundWhiteBrush#��[ 6   .@�5%      m� $
��File��6   .@�5&      m� $	��New��6   .@�5'      m� $��Project��6#    m� Command 5(   #   �� *CreateProjectCommand+ m� Icon 5)      �� 5*   "   $��/Icons/Menu/new.png��6(   5,      5-      m� 5.      $
��Open��6   .@�5/      m� $��Project��6#    50   #   �� *OpenProjectCommand+ 51      �� 52   "   $��/Icons/Menu/open.png��6(   54      55      m� 56      $
��Save��6    57      �� *SaveProjectCommand+ 58      �� 59      $��/Icons/Menu/save.png��6$   5;      m� 5<      $��Save As ...��6    5=      �� *SaveProjectAsCommand+ 5>      �� 5?      $��/Icons/Menu/save.png��6$   5A      5B      m� 5C      $��Tools��6   .@�5D      m� $��Connect to server ...��6    5E      �� *ConnectToServerCommand+ 5F      �� 5G      $��/Icons/Menu/connector.png��6$   5I      5J      5K      5L      8   2DataLightViewer.Controls.SearchTreeViewItemControl  5R   
   $��0��5S      $��1��5T      $��2��5U      $
��Auto��5V      $
��Auto��5W      
������    TreeViewItemsSource 5Y      �� *NodeTreeViewModel.Items+ �� Mode$ TwoWay=�   
SearchText 5Z      �� *NodeTreeViewModel.SearchText+$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
   SearchCommand
 5[      �� *!NodeTreeViewModel.SearchCommand+   ClearCommand 5\      �� * NodeTreeViewModel.ClearCommand+�� 5c   
   $��1��6   $��2��6$   $��1��65   $��5��6E   $��Stretch=�5d      $��Center=�5e      
������ 5f      � 5l   
   $��1��6   $��2��5m      $��2��5n       5p      �� 5q      $
��.35* �6    �� 5r      $
��Auto �6    �� 5s      $
��.65* �6    .+�5v      &   System.Windows.Controls.DataGrid  $��0��6   $��0 5 5 0q�5w         
IsReadOnly .   DbPropertiesDataGrid#��[ 5y      ��5z      �� *PropertyViewModel.Properties+�� 5|      $��1��6   $��Stretch=�5}      $��Center=�5~      $��5��5      
������ 5�      � 5�      $��2��6     ForegroundEditorLineBrush#��[ 5�      $��0 0 5 5q�5�       5�      �� 5�      $
��Auto �6$   �� 5�      $��* �6$   .+�5�      9� $��0��6   $��
Sql-Editor��5�      #��[ 5�      #��[  5�      $��0 0 0 5q�5�      .��5�      c� 
������ .@�5�      �� ��6!   �� *'%SqlScriptViewModel.ClearScriptCommand+.��5�      �� .+�5�   "   �� $��/Icons/Menu/clear.png��6(   �� 5�   "   $��Clear��6,   5�      5�      �� 5�      �� 5�      ��6"   �� *&$SqlScriptViewModel.SaveScriptCommand+.��5�      �� .+�5�   "   �� $��/Icons/Menu/sql.png��6(   �� 5�   "   $
��Save��6,   5�      5�      5�      5�      ] YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310'  !ICSharpCode.AvalonEdit.TextEditor  5�      ?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  5�      -   5          Name$ AvalongTextEditor��5�      $��1��5�        	SqlEditor#��[ 5�         SyntaxHighlighting 5�      �� *SyntaxHighlighter+$ TwoWay=�   Text. 5�   8   .  (System.Windows.Interactivity.Interaction   	Behaviors 5�      3   -DataLightViewer.Behaviors.AvalonEditBehaviour  5�         AvalonContent 60   �� *SqlScriptViewModel.Script+$ TwoWay=�$	 PropertyChanged=�. 5�   /   5�      5�      5�      �� 5�   
   $��3��6   $��0��5�      $��3��5�       " BackgroundStatusBarOrangeBrush#��[ 5�      .@�5�      �� .��5�      �� #��[ 5�        LatoThin#��[ 5�        FontSizeRegular#��[ 5�       �� Padding$ 2q�5�      $
��Auto��5�      ��5�      �� *StatusViewModel.Message+5�      5�      5�      5�      5�      