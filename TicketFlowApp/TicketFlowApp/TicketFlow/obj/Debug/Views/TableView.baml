   M S B A M L   `   `   `  ����E  ATicketFlow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TicketFlow.ViewsTicketFlow.Views  5           TicketFlow.Views.TableView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:TicketFlow.Views     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      
������   � 	Resources  5      ��%    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   ��  �� CornerRadius$ 12��6   ._�5      �� $ 12��6   $��2q�5       J� Opacity$
 0.98Q�5      ��5!      �� 5"       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5#      �  � Color$ 
WhiteSmoke��6'    � Offset$ 0Q�6:   � 5$         winBorderColor3# [  6'   $
 0.24Q�6P   � 5%      # [  6'   $ 1Q�6P   5&      ��5)      �� 5*      $	 0,1&�6*   $	 1,2&�6;   .��5+      �   primaryBackcolor2# [ 6'   $	 0.1Q�6R   � 5,      # [  6'   $	 1.0Q�6P   5-      ._�50      �� $��0��6   $��2��51      	 �� Orientation$	 
Horizontal=�52      $	��Top=�53      $��10q�54      .+�57      � $	��500��6   $	��Top=�58      $��30��59      $
��Left=�5:      $��10q�5;      .+�5<      �� $
��20 0q�6$   $��Center=�5=   $   
�������
 J� IsHitTestVisible
 .   K� ZIndex$ 1��5@   $   $��Search here ...��5A   $   �� 5B      -   5         ��Name$ 	txtSearch��5B   "     textboxSearch#��[ 5C   "   5D      �� 5F      $��Search��6   $��Center=�5G      $��5q�5H        GrayButtonStyle#��[ 5I      �� 5L      $��
State Open��6   $��Center=�5M      $��5q�5N      
�������  CheckBoxStyle#��[ 5Q      5R      5S      5T      �� 5W   
   $��0��6   $��40��5X      $	 
Horizontal=�5Y      $��Right=�5Z      $��Bottom=�5[      $��8q�5\      .+�5_      	� -   5         	�Name$ 	LeftArrow��5a        pagingButton#��[ 5_      $��Center=�5`      .��5b      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 	ArrowLeft=�6     pagingButtonIcon#��[ 60   5c      �� 5e        pagingRectangle#��[ 6   �� 5h      -   5         ��Name$ 
PageNumber��5h      $��Center=�5k        
pagingText#��[ 5l      ��5j      �� *
PageNumber+5l      �� 5n      #��[ 6   	� 5q      -   5        $ 
RightArrow��5s      #��[ 5q      $��Center=�5r      .��5u        $ 
ArrowRight=�6#   #��[ 65   5v      5x      �� 5{   
   $��0��6   $��0��5|      $��
10 60 0 50q�5~      .��5�      &   System.Windows.Controls.DataGrid  -   5          Name$ 
MyDataGrid��5�       	 DataGridStyle1#��� 	 5�       
 DataGridCellStyle1   	CellStyle# � 
 5�        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5�        DataGridRowStyle1   RowStyle# �  5�         AutoGenerateColumns .  $��3q�5�      $��Center=�6&   $��Stretch=�5�         
IsReadOnly . ��5�      �� *
TicketList+ �� SelectedItem 5�      �� *SelectedTicket+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      MinWidth$ 12Q�6L      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6Z     5�      $ Number��6)   $
 auto 6T    69   �� *Number+6T     5�      $ Title��6)   $ * 6R    68   �� *Title+6R     5�      $ State��6)   $
 auto 6R    68   �� *State+6R     5�      $ Priority��6)   $
 auto 6X    6;   �� *
Priority+6X     5�      $ 
Created at��6)   $
 auto 6\    6=   �� *
Created_at+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Options��6-      CellTemplate 5�      �� 5�      .R�5�   "   �� $��1��5�   -   $��0��5�   -   $	 
Horizontal=�5�   1   $��Stretch=�5�   1   $��Center=�5�   1   $��1q�5�   1   $
��auto��5�   1   .+�5�   &   �� $��1��5�   -   $��1��5�   -     
editButton#��[ 5�   -   $��Edit Ticket��5�   -   $��Right=�5�   -   $��Stretch=�5�   -   $��5q�5�   -   ��5�   -   �� *DataContext.EditTicketCommand+ �� RelativeSource ��  �� AncestorType$ UserControlL�5�   -   5�   #   5�      5�      5�      5�      5�      5�      