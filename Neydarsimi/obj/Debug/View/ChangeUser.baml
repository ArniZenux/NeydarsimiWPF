   M S B A M L   `   `   `  ����E  ANeydarsimi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Neydarsimi.ViewNeydarsimi.View  5   	        Neydarsimi.View.ChangeUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   )localclr-namespace:Neydarsimi.View  5   	     � Title$  Breyta túlk��5	   	   $	��320��6   $	��255��6*    � 
ResizeMode$ NoResize=�66   ���#B3B7B7.��5
      � .+�5   
   �� -   5         ��Name$ 	xListView��5      $	��Top=�6'   $��Center=�6?   $��0,5,0,0q�6\   $	��220��6m   $	��165��6y   ��6�   �� *
Tulkslisti+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SelectItemListbox_CMD+   CommandParameter 6V   ��  �� ElementName$ 	xListView��	 �� Path$	 SelectedItem�6�   5      
 �� View
 5      �� 5      .P�5      �� $
��Nafn��6%    �� Width$	 210��63    �� DisplayMemberBinding 6?   �� *nafn+5      5      �� 5   
   $��	Kennitala��6   $	��Top=�6$   $
��Left=�6<   $��
10,180,0,0q�6W   �� 5   
   $	��Top=�6   $
��Left=�6*   $��
80,180,0,0q�6E   $	��150��6Y   $��25��6e   ��6q   �� *KennitalaBox+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��
Fullt nafn��6   $	��Top=�6%   $
��Left=�6=   $��
10,210,0,0q�6X   �� 5   
   $	��Top=�6   $
��Left=�6*   $��
80,210,0,0q�6E   $	��150��6Y   $��25��6e   ��6q   �� *FulltNafnBox+$ PropertyChanged=��� 5   
   $��Breyta��6   $��25��6"   $��50��6.   $	��Top=�69   $
��Left=�6Q   $��125,245,0,0q�6l   ��6�   �� *Change_user_CMD+�� 5   
   -   5        $
��Loka��5      $��25��6    $��50��6,   $	��Top=�67   $
��Left=�6O   $��180,245,0,0q�6j   6   5      5       