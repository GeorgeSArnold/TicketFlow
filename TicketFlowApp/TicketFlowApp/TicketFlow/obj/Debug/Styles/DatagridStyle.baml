   M S B A M L   `   `   `  ����b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� 
ResourceId �� TypeInTargetAssembly&    System.Windows.Controls.DataGrid �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �Name	 J� Opacity
 � Points �� Stretch �� Triggers P� Property P� Value �� 
TargetName   DataGridStyle15  /System.Windows.Controls.DataGridLengthConverter3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth   Opacity �� Padding ��Name � ColumnDefinitions � RowDefinitions    SelectAllCommand7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!    HeadersVisibilityConverter �� 	Converter �� RelativeSource �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name    Column! ��Name" �� CanContentScroll# ��Name$ �� ScrollableHeight% � Maximum& �� Orientation' �� ViewportHeight( �� ViewportSize*) �� #ComputedVerticalScrollBarVisibility* � Value+ �� Mode, �� Mode- ]�Name. ]� DecreaseRepeatButton/ ]� IncreaseRepeatButton0 ]� Thumb1 �� ScrollableWidth2 �� ViewportWidth,3 �� %ComputedHorizontalScrollBarVisibility4 �� Triggers5 ]� 
Conditions6 �� Property7 �� Value  DataGridCellStyle1*  $System.Windows.Controls.DataGridCell  ColumnHeaderGripperStyle  DataGridColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader3   -Microsoft.Windows.Themes.DataGridHeaderBorder8   	IsPressed9 J� IsMouseOver:   	IsHovered;   CanUserSort<   IsClickable=   SortDirection>   SortDirection?   SeparatorVisibility@   SeparatorVisibilityA   SeparatorBrushB   SeparatorBrushC n�Name  DataGridRowStyle1)  #System.Windows.Controls.DataGridRowD ��NameE �� CornerRadius?	  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?
  9System.Windows.Controls.Primitives.DataGridCellsPresenterF   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenterG   DetailsVisibility$H 	  SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientationI   Vertical#J    RowDetailsScrollingConverter:  4System.Windows.Controls.Primitives.DataGridRowHeader
K   Row�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      UthemeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  5      %�  (��       5      $" DataGridSelectAllButtonStyle��"   )&	  �    &	      &	 �    &	 �    7  7  &	 6    �� 6   "  ��6{   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5	      � .+�5
      �� $ Border��6$   #��� ��64    . 6u   � 5      $ Arrow��6"   
���   �$��Right=�6>   $��8,8,3,3q�6Z   $
	 0.15Q�6k   
 �   ��� ��� ��� ��� $ Uniform=�6�   $��Bottom=�6�   5       5      P� 5       �@J�IsMouseOver . . �5      �� $ Border��67   # � ��6K    � ��5      P� 5       � �� . . �5      �� $ Border��65   # � ��6I    � ��5      P� 5       � {� .  . �5      �� $ Arrow��6;    � y�$ 	Collapsed=�6N   5      5      5      5      �� 5      "    6#   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � �� �#2225286'   �� 5   
    � ��$	 0.3q�6,   �� 5    
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5!   
    � �� . 6:   �� 5"   
    �@��PanningMode$
 Both=�65   �� 5#   
    �@��IsFlicksEnabled .  63   �� 5$   
    �@  AutoGenerateColumns .  60   �� 5%   
    �@  HeadersVisibility$ Column=�6.   �� 5&   
    � ��$ 0 10 0 0q�6#   �� 5'   
    �@  SelectionMode$ Single=�6*   �� 5(   
    �@  SelectionUnit$ FullRow=�6*   �� 5)   
    �@  CanUserAddRows .  6+   �� 5*   
    �@  CanUserDeleteRows .  6.   �� 5+   
    �@  CanUserResizeRows .  6.   �� 5,   
    � ��$ 15(�6%   �� 5-   
    �@  ColumnWidth$ * 6(   �� 5.   
    �@  GridLinesVisibility$
 None=�60   �� 5/   
    �@J�Effect 50        51      $ Black��6#   $	 270Q�61   $ 3Q�6A   $	 0.5Q�6Q   53      �� 54   
    � �� 55      �� 56      "   6"   .R�57      �� 
������ #��z��66   #��z��6b   # z��6�    . ._�58      �� $ DG_ScrollViewer��6'   |�.  ��59      �� 5:   "   " ��62   .R�5;   &   �  5<   *   �� 5=   .   $
��Auto �6?   �� 5>   .   $��* �6?   �� 5?   .   $
��Auto �6?    5A   *   �� 5B   .   $
��Auto �6<   �� 5C   .   $��* �6<   �� 5D   .   $
��Auto �6<   .+�5F   *   �� #��Z 61   |�.  ��6r   C� *�� $" DataGridSelectAllButtonStyle��"   +y�6�   �� *HeadersVisibility+# Z # Z  �� "   ��6�  �� *CellsPanelHorizontalOffset+ �� "     5G   *   $! PART_ColumnHeadersPresenter��6I   $��1��6n   y�6~   �� *HeadersVisibility+# Z  # Z  �� "   �� 5H   *   $!! PART_ScrollContentPresenter��6A   #" z��6f   $��2��6�   $��1��6�   �� 5K   *   $# PART_VerticalScrollBar��64   $��2��5L   .   #% z$ 6>   $& Vertical=�5M   .   $��1��6E   #( z' 5O   .   #y�z) 5P   .   * 5N   .   �� *VerticalOffset+$+ OneWay=� �� $, TemplatedParent=���5Q   .   �� 5R   2   " ��6B   .R�5S   6   � 
������ .+�5T   :   �� 
������ 
���  ��$��1q�6l   ]� 5U   :   $- 
PART_Track��6@   . 5V   >   �� 5W   B   $��ScrollBar.LineUpCommand��6O   $	 0Q�6q   / 5Y   >   �� 5Z   B   $��ScrollBar.LineDownCommand��6O   $	 0Q�6s   0 5\   >   n� 5]   B   
������ $		 0.5Q�6a   5_   ;   5`   7   5a   3   5c   +   � 5l   *   $��1��6/   $��2��6?    5m   .   �� 5n   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� 5o   2   $��* �6C   .+�5q   .   �� $# PART_HorizontalScrollBar��68   $��1��6Z   #% z1 6j   $& 
Horizontal=�6�   #( z2 6  #y�z3 6D  * 6�   �� *HorizontalOffset+$+ OneWay=� �� $, TemplatedParent=�6D  5r   +   5s   '   5t   #   .��5v      �� # z 6-   5w      5x      5y      5{      4 5|   
   ]� 5}      5 5~      �� 5      6 �@��
IsGrouping7 . 66   �� 5�      "6 �@%�IsVirtualizingWhenGrouping7 .  6X   ./�5�      ��  � �� .  6B   5�      5�      �� 5�      "   6'   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � ��$ Center=�6.   �� 5�   
    �@�FocusVisualStyle 6-   Z� �� 5�   
    � ��$
 15 0q�6#   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� #��z��6   $��0q�6G    . ._�5�      �� # z 6+   5�      5�      5�      5�      �� 5�      "  n�6-   .�5�   
   ��  � ��$ 8��6"   �� 5�   
    � ��
 ���� 6'   �� 5�   
    �@�Cursor$ SizeWE��6#   �� 5�   
    � �� 5�      �� 5�      " n�6"   .R�5�      �� #��z��6   # z��6G   5�      5�      5�      �� 5�      "   6/   .�5�   
   ��  � ��$ Center=�65   �� 5�   
    � �� �#4B545D6'   �� 5�   
    � ��
 �����6'   �� 5�   
    � ��$ 
15 0 15 10q�6#   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � .+�5�        #��z��65   #��z��6_   #��z��6�   #8 z��6�   #: z9 6�   #< z; 6  # z��6=  #> z= 6a  #@ z? 6�  #B zA 6�  ._�5�      �� #��z��6/   ��. # z 6�   #��z��6�   5�      n� 5�      $C PART_LeftHeaderGripper��6    $
��Left=�6@   8��  6[   n� 5�      $C PART_RightHeaderGripper��6    $��Right=�6A   8�� 6]   5�      5�      5�      5�      �� 5�      "   6&   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � ��
 �����6'   �� 5�   
    � ��$ 0 4 0 0q�6#   �� 5�   
    �@J�SnapsToDevicePixels . 60   �� 5�   
    �@=�ErrorTemplate 65   Z� �� 5�   
    �@ ValidationErrorTemplate 5�      �� 5�      .R�5�      �� 
���  ��$��2,0,0,0q�61   $��!��6B   $��Center=�6K   5�      5�      �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� $D 
DGR_Border��6   $	 0 8q�61   #��z��6?   $��0q�6i   $E 5��6}    . ._�5�      	   5�      �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60   .+�5�      
  $��1��65   #��zF 5�   5   # z 5�   5     5�      $��1��5�   !   $��1��61   #y�zG 5�   8  H 6!   �� *AreRowDetailsFrozen+# ZI # ZJ  �� "   68    5�      $��2��60   $H Vertical=�6A   y�6�   �� *HeadersVisibility+# ZK # Z  �� "   5�      5�      5�      5�      4 5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � �� �#4D40656/   �� 5�       � ��
 �����6/   5�      P� 5�       �@ 
IsSelected . . �5�      ��  � �� �#4D40656/   �� 5�       � ��
 �����6/   5�      ]� 5�      5 5�      �� 5�      6 �@ 
IsSelected7 . 66   �� 5�      6 �@��IsSelectionActive7 .  6F   ./�5�      ��  � �� �#dfdfdf6/   5�      5�      5�      