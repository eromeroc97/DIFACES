   M S B A M L   `   `   `  ����F  BAvengersERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AvengersERPAvengersERP  5   	   (    "AvengersERP.view.UserAdministrator   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AvengersERP     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������$��	UltraBold"�5
   	   $��16(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
�������   MaterialDesignFont#���   5   	    � Title$ UserAdministrator��5   	   $	��450��6#   $	��800��60   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  $
��Left=�6   $	��400��6.   $��	232,9,0,0q�6;   $	��Top=�6N   $	��560��6f      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *name+6X     5      $
 Name��6&   $ * 64    6>   �� *name+6Z     5      $ Password��6%   $ * 67    6A   �� *	surname+6_     5      $
 Role��6%   $ * 63    6=   �� *	address+6[     5      $ Deleted?��6%   $ * 67    6A   �� *	address+6_   5      �� 5   
   $��Create New User��6   $
��Left=�6+   $��
10,231,0,0q�6F   $	��Top=�6Z   $	��140��6r   
���   �$��25��6�   �� 5   
   $��Modify User��6   $
��Left=�6'   $��
10,285,0,0q�6B   $	��Top=�6V   $	��120��6n   
���   �$��25��6�   �� 5   
   $��Delete User��6   $
��Left=�6'   $��
10,335,0,0q�6B   $	��Top=�6V   $	��120��6n   
���   �$��25��6�   �� 5   
   $��Recover User��6   $
��Left=�6(   $��
10,384,0,0q�6C   $	��Top=�6W   $	��120��6o   
���   �$��25��6�   5       5!      