   M S B A M L   `   `   `  ���� J  FDataLightViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DataLightViewer.ControlsDataLightViewer.Controls  +    %DataLightViewer.Views.Main.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5controls&clr-namespace:DataLightViewer.Controls    � WindowStartupLocation$  CenterScreen=� � Title$ DataLightViewer��$	��450��$	��650��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Closing��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *CloseCommand+.���    BackgroundBlueBrush#��[   � RowDefinitions �� $
��Auto ��� $��* ��� $��* ��� $
��Auto � � ColumnDefinitions �� $
��0.4* ��� $
��Auto ��� $
��0.6* �.+�� $��0��$��0��$��3��.+�o�   ForegroundWhiteBrush#��[ .@�m� $
��File��.@�m� $	��New��.@�m� $��Project�� m� Command �� *CreateProjectCommand+	 m� Icon	 �� $��/Icons/Menu/new.png��m� $
��Open��.@�m� $��Project�� �� *OpenProjectCommand+	 �� $��/Icons/Menu/open.png��m� $
��Save�� �� *SaveProjectCommand+	 �� $��/Icons/Menu/save.png��m� $��Save As ...�� �� *SaveProjectAsCommand+	 �� $��/Icons/Menu/save.png��8   2DataLightViewer.Controls.SearchTreeViewItemControl  -   
  Name$
 	SearcTVIC��$��0��$��1��$��2��$
��Auto��$
��Auto��
������    TreeViewItemsSource �� *NodeTreeViewModel.Items+ �� Mode$ TwoWay=�   
SearchText �� *NodeTreeViewModel.SearchText+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SearchCommand �� *!NodeTreeViewModel.SearchCommand+   ClearCommand �� * NodeTreeViewModel.ClearCommand+�� $��1��$��2��$��1��$��5��$��Stretch=�$��Center=�
������ � $��1��$��2��$��2�� �� $
��0.4* ��� $
��Auto ��� $
��0.6* �.+�&   System.Windows.Controls.DataGrid  $��0��$��0 5 5 0q�   
IsReadOnly .   DbPropertiesDataGrid#��[ ���� *PropertyViewModel.Properties+�� $��1��$��Stretch=�$��Center=�$��5��
������ � $��2��
�������$��0 0 5 5q� �� $
��Auto ��� $��* �.+�9� $��0��$��
Sql-Editor��#��[  .��c� 
������ .@��� ���� *'%SqlScriptViewModel.ClearScriptCommand+.���� .+��� $��/Icons/Menu/clear.png���� $��Clear���� �� ���� *&$SqlScriptViewModel.SaveScriptCommand+.���� .+��� $��/Icons/Menu/sql.png���� $
��Save���� $��1�� J� IsManipulationEnabled .   SqlEditorTextBox#��[ ���� *SqlScriptViewModel.Script+�� $��3��$��0��$��3�� " BackgroundStatusBarOrangeBrush#��[ .@��� .���� #��[   LatoThin#��[   FontSizeRegular#��[  �� Padding$ 2q�$
��Auto������ *StatusViewModel.Status+