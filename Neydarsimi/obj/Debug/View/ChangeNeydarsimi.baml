   M S B A M L   `   `   `  ����E  ANeydarsimi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Neydarsimi.ViewNeydarsimi.View  5   	   &     Neydarsimi.View.ChangeNeydarsimi   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   )localclr-namespace:Neydarsimi.View  5   	     � Title$  Breyta neyðarsíma��5	      $	��535��6%   $	��910��62    � 
ResizeMode$ NoResize=�6>   ���#B3B7B7.��5
      �  � ColumnDefinitions 5   
   �� 5      $	��260 �6   �� 5      $	��650 �6   .+�5   
   �� $��0��6   $��Breyta neyðarsíma��6#   $	��490��6>   $	��250��6K   $	��Top=�6W   $��Center=�6o   $��6,5,5,0q�6�   $��2��6�   .��5      � .+�5      �� -   5         ��Name$ xTulkurView��5      $	��222��61   $	��150��6=   $	��Top=�6J   $��Center=�6b   $��5q�6   ��6�   �� *
Tulkslisti+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *SelectTulkur+   CommandParameter 6U   �� 	 �� ElementName$	 xTulkurView��
 �� Path$
 SelectedItem�6�   5       �� View 5      �� 5      .P�5      �� $
��Nafn��6-    �� Width$	 210��6;    �� DisplayMemberBinding 6G   �� *nafn+5      5      �� 5      $��Túlkur��6   $	��Top=�6)   $
��Left=�6A   $��
10,160,0,0q�6\   �� 5       $	��Top=�6   $
��Left=�62   $��110,160,0,0q�6M   $	��120��6b   $��25��6n   ��6z   �� *	TulkurBox+�� 5!      $��(Nýja) Frá��6   $	��Top=�6-   $
��Left=�6E   $��
10,190,0,0q�6`   (  "System.Windows.Controls.DatePicker  5"      $��25��6   $	��120��6*   $
��Left=�66   $	��Top=�6Q   $��110, 190, 0,0q�6i      SelectedDate 6�   �� *Nyr_Byrja_dagur+ �� StringFormat$ 	dd/MM/yyy���� 5#      $
��Frá��6   $	��Top=�6&   $
��Left=�6>   $��
10,220,0,0q�6Y   �� 5$      $	��Top=�6   $
��Left=�62   $��110,220,0,0q�6M   $	��120��6b    �� 
IsReadOnly . $��25��6�   ��6�   �� *Byrja_dagur+�� 5%      $��(Nýja) Til��6   $	��Top=�6-   $
��Left=�6E   $��
10,250,0,0q�6`     5&      $��25��6   $	��120��6*   $
��Left=�66   $	��Top=�6Q   $��110, 250, 0,0q�6i    6�   �� *Nyr_Endir_dagur+$ 	dd/MM/yyy���� 5'      $	��Til��6   $	��Top=�6&   $
��Left=�6>   $��
10,280,0,0q�6Y   �� 5(      $	��Top=�6   $
��Left=�62   $��110,280,0,0q�6M   $	��120��6b    . $��25��6�   ��6�   �� *Endir_dagur+�� 5)      $��Klukk - inn��6   $	��Top=�6.   $
��Left=�6F   $��
10,310,0,0q�6a   �� 5*      $	��Top=�6   $
��Left=�62   $��110,310,0,0q�6M   $	��120��6b   $��25��6n   ��6z   �� *KlukkInnBox+�� 5+      $��Klukk - út��6   $	��Top=�6-   $
��Left=�6E   $��
10,340,0,0q�6`   �� 5,      $	��Top=�6   $
��Left=�62   $��110,340,0,0q�6M   $	��120��6b   $��25��6n   ��6z   �� *
KlukkUtBox+�� 5-      $��Vettvangur ��6   $	��Top=�6.   $
��Left=�6F   $��
10,370,0,0q�6a   �� 5.      $	��Top=�6   $
��Left=�62   $��110,370,0,0q�6M    . $	��120��6t   $��25��6�   ��6�   �� *VettvangurBox+�� 5/      $��Nýr vettvangur ��6   $	��Top=�62   $
��Left=�6J   $��
10,400,0,0q�6e   �� 50      $��25��6   $	��120��6(   $	��Top=�64   $
��Left=�6L   $��110,400,0,0q�6g    �� SelectedValuePath$ tegund��6�    �� DisplayMemberPath$ tegund��6  ��6}   �� *VettvangurComboBox+ �� SelectedValue 6�   �� *VettvangurComboBox_old+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 51      $��Breyta��6   $��25��6*   $��60��66   $	��Top=�6A   $
��Left=�6Y   $��105,430,0,0q�6t   ��6�   �� *ChangeNeydarsimi_CMD+�� 52      -   5        $
��Loka��52      $��25��6(   $��60��64   $	��Top=�6?   $
��Left=�6W   $��170,430,0,0q�6r   6�   53      54      �� 56   
   $��1��6   $��Listi neyðarsíma��6#   $	��490��6=   $	��625��6J   $	��Top=�6V   $
��Left=�6n   $��5,5,0,0q�6�   $��2��6�   .��57      &   System.Windows.Controls.DataGrid  -   5          Name$ 	xListView��57      $	��600��6*   $	��455��66   ��6C   �� $
 NeydarsimiData� 58        59      $ SelectionChanged��6%   . 5:         60   �� *SelectionChangedCommand+ 6\   �� $	 	xListView��$
 SelectedItem�6�   5;         Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      -   5        Nafn��,  &System.Windows.Controls.DataGridColumn   Header$
 Nafn��5>   7      Width5	  /System.Windows.Controls.DataGridLengthConverter$	 130	 6E      DisplayIndex$ 0��6j   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6Q   �� *nafn+6j     5?      -   5        Frá��$
 Frá��5?   6   $	 100	 6C   $ 1��6i    6O   �� *byrja+6i     5@      -   5        Til��$	 Til��5@   6   $	 100	 6C   $ 2��6i    6O   �� *endir+6i     5A      -   5        
Klukka_inn��$ Kl��5A   =   $ 60	 6I   $ 3��6s    6T   �� *
timi_byrja+6s     5B      -   5        
Klukkan_ut��$ Kl��5B   =   $ 60	 6I   $ 4��6s    6T   �� *
timi_endir+6s     5C      -	   5        
Vettvangur��$ 
Vettvangur��5C   =   $	 160	 6Q   $ 5��6x    6]   �� *tegund+6x   5E      5F      5H      5I      