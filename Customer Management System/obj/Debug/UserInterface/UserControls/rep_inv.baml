   M S B A M L   `   `   `  ����  Customer Management System(    "UserInterface.UserControls.rep_inv   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��380��5      $	��505��6,   .��5      � $��0,0,-170,-170q�6     � RowDefinitions  5   
   �� 5	      $	��19* �6   �� 5
      $	��36* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgPendings��5      
����ح�$��Medium"�6<      
MyDataGrid#��[  6q   $��-195,-40,10,0q�6�   $	��445��6�   $	��Top=�6�   $��2��6      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
product id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6=      CellTemplate 5      �� 5      .R�5      ��  �� TextAlignment$
 Left=�6C   ��6(   ��  �� Path$	 pId�6Z   5      5        5      $ Quantity��6)   $ 1* 6;    5      �� 5      .R�5      �� $
 Left=�6G   ��6(   �� $ Quantity�6^   5      5        5%      $
 date��6)   $ 1* 67    5&      �� 5'      .R�5(      �� $ Right=�6(   ��6>   �� $
 Date�6[   5)      5+      5W      5Y      5Z      