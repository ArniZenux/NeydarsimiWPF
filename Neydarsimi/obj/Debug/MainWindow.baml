   M S B A M L   `   `   `  ����E  ANeydarsimi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Neydarsimi
Neydarsimi  5   	       Neydarsimi.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $localclr-namespace:Neydarsimi  5   	     � Title$0  *Neyðarsími túlka - Útgáfunúmer 1.0.0��5
   	   $	��525��66   $	��900��6C    � 
ResizeMode$ NoResize=�6O   ���#B3B7B7.��5      ]� .+�5   
   o� $	��Top=�6   $��14(�6$   .@�5      m� $��	Skráning��6   .@�5      m� -   5        $��Loka (Exit)��5       m� Icon 5      �� 5      $��img\close.png��6    5      5      m� 5      $��Túlkur��6   .@�5      m� $��Nýr túlkur��6    m� Command 6/   �� *AddUser_CMD+ 5      �� 5      $��img\new_2.png��6    5      m� 5      $��Breyta túlk��6    60   �� *ChangeUser_CMD+ 5      �� 5      $��img\update.png��6    5      5      m� 5       $��Neyðarsími��6   .@�5!      m� $��Breyta neyðarsíma��6    66   �� *ChangeGSM_CMD+ 5"      �� 5#      $��img\update.png��6    5%      5'      5)      � 5*   
    � ColumnDefinitions 5+      �� 5,      $	��230 �6#   �� 5-      $	��650 �6#   .+�50      �� $��0��6   $��Túlkur��6+   $��75��6;   $	��220��6G   $��0,5,0,0q�6S   $	��Top=�6d   $��Center=�6|   .��51      � .+�52      �� $��Center=�6%   $	��Top=�6B   $��75��6Z   $��25��6e   $��Nýr túlkur��6q   $��
-80,10,0,0q�6�   ��6�   �� *AddUser_CMD+6�   �� 53      $��Center=�6%   $	��Top=�6B   $��75��6Z   $��25��6e   $��Breyta túlk��6q   $��	90,10,0,0q�6�   ��6�   �� *ChangeUser_CMD+6�   54      55      �� 57      $��0��6   $��Skrá neyðarsíma túlka��6'   $	��380��6F   $	��220��6S   $	��Top=�6_   $��Center=�6w   $��0,80,0,0q�6�   .��58      � .+�59      �� -   5         ��Name$ 	xListView��59   )   $	��Top=�6<   $��Center=�6T   $��0,5,0,0q�6q   $	��190��6�   $	��140��6�   $
��Auto=�6�   ��6�   ��  �� Path$ 
Tulkslisti�.  (System.Windows.Interactivity.Interaction   Triggers 5:   "   /  )System.Windows.Interactivity.EventTrigger  5;   *      	EventName$ SelectionChanged��69   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5<   .   6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6D   �� *SelectItemListbox_CMD+   CommandParameter 6n   ��  �� ElementName$ 	xListView��$ SelectedItem�5=   +    �� View 5?   &   �� 5@   *   .P�5A   ,   �� $
��Nafn��6;    �� Width$	 180��6I    �� DisplayMemberBinding 6U   �� *nafn+5B   '   5D      �� 5E      $
��Frá��6$   $	��Top=�62   $
��Left=�6J   $��
10,160,0,0q�6e   (  "System.Windows.Controls.DatePicker  5F      $��25��6)   $	��120��65   $
��Left=�6A   $	��Top=�6\   $��80, 160, 0,0q�6t      SelectedDate 6�   �� *Byrja_dagur+ �� StringFormat$ 	dd/MM/yyy���� 5G      $	��Til��6$   $	��Top=�62   $
��Left=�6J   $��
10,190,0,0q�6e     5H      $��25��6*   $	��120��66   $
��Left=�6B   $	��Top=�6]   $��80, 190, 0,0q�6u    6�   �� *Endir_dagur+$ 	dd/MM/yyy���� 5I      $��Klukk - inn��6$   $	��Top=�6:   $
��Left=�6R   $��
10,220,0,0q�6m   �� 5J      $	��Top=�6&   $
��Left=�6>   $��
80,220,0,0q�6Y   $	��120��6m   $��25��6y   ��6�   �� *KlukkInnBox+ �� UpdateSourceTrigger$ PropertyChanged=��� 5K      $��Klukk - út��6$   $	��Top=�69   $
��Left=�6Q   $��
10,250,0,0q�6l   �� 5L      $	��Top=�6&   $
��Left=�6>   $��
80,250,0,0q�6Y   $	��120��6m   $��25��6y   ��6�   �� *
KlukkUtBox+$ PropertyChanged=��� 5M      $��Vettvangur ��6$   $	��Top=�6:   $
��Left=�6R   $��
10,280,0,0q�6m   �� 5N      $��25��6(   $	��120��64   $	��Top=�6@   $
��Left=�6X   $��
80,280,0,0q�6s    �� SelectedValuePath$ tegund��6�    �� DisplayMemberPath$ tegund��6#  ��6�   �� *VettvangurComboBox+ �� SelectedValue 6�   �� *VettvangurComboBox_old+$ PropertyChanged=�6#  �� 5P      $��Skrá��6%   $��25��64   $��60��6@   $	��Top=�6K   $
��Left=�6c   $��140,315,0,0q�6~   ��6�   �� *BookingProject_CMD+5R      5S      �� 5U      $��1��6   $��Listi neyðarsíma túlka��6'   $	��455��6G   $	��640��6T   $	��Top=�6`   $
��Left=�6x   $��5,5,0,0q�6�   .��5V      &   System.Windows.Controls.DataGrid  -   5          Name$ 	xDataGrid��5V      $	��620��6.   $	��420��6:      AutoGenerateColumns .  ��6G   �� $ NeydarsimiData�   Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X      -   5        Nafn��,  &System.Windows.Controls.DataGridColumn   Header$
 Nafn��5X   ;      Width5	  /System.Windows.Controls.DataGridLengthConverter$	 130	 6I      DisplayIndex$ 0��6n   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6U   �� *nafn+6n     5Y      -   5        Frá��$
 Frá��5Y   :   $	 100	 6G   $ 1��6m    6S   �� *byrja+6m     5Z      -   5        Til��$	 Til��5Z   :   $	 100	 6G   $ 2��6m    6S   �� *endir+6m     5[      -   5        
Klukka_inn��$ Kl��5[   A   $ 60	 6M   $ 3��6w    6X   �� *
timi_byrja+6w     5\      -   5        
Klukkan_ut��$ Kl��5\   A   $ 60	 6M   $ 4��6w    6X   �� *
timi_endir+6w     5]      -	   5        
Vettvangur��$ 
Vettvangur��5]   A   $	 160	 6U   $ 5��6|    6a   �� *tegund+6|   5_      5`      5b      5c      5d      