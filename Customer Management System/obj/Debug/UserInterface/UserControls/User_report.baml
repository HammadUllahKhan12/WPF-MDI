   M S B A M L   `   `   `  ����  Customer Management System,    &UserInterface.UserControls.User_report   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��1089.552��5      $��531.343��60   .��5      �   � RowDefinitions  5   
   �� 5	      $
��Auto �6   �� 5
      $
��105* �6   �� 5      $	��23* �6   �� 5      $	��72* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   .+�5      �� $3��-                            Employee Reports ��6   .��5      �� -   5        $��Refresh��5      $
��Left=�6+   $��
354,-1,0,0q�6F   $	��Top=�6Z   $��75��6r   6}   5      5      � 5   
   $��1��6   $��3��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
dgPendings��5      
����ح�$��Medium"�6@      
MyDataGrid#��[  6u   $��0,10,0,0q�6�   $	��419��6�   $	��Top=�6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ User ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6>      CellTemplate 5      �� 5      .R�5   "   ��  �� TextAlignment$
 Left=�6F   ��6,   ��  �� Path$ ID�6]   5      5         5!      $
 Name��6-   $ 1* 6;    5"      �� 5#      .R�5$   "   �� $
 Left=�6E   ��6,   �� $ UN�6\   5%      5'        50      $ 	User Type��6-   $ 1* 6@    51      �� 52      .R�53   "   �� $ Right=�6,   ��6B   �� $ 	USER_TYPE�6d   54      56        57      $ Gender��6-   $ 1* 6=    58      �� 59      .R�5:   "   �� $ Right=�6,   ��6B   �� $ GENDER�6a   5;      5=        5>      $ Salary��6-   $ 1* 6=    5?      �� 5@      .R�5A   "   �� $ Right=�6,   ��6B   �� $
 SALE�6_   5B      5D        5E      $ Date/Time of Joining��6-   $ 1* 6K    5F      �� 5G      .R�5H   "   �� $ Right=�6,   ��6B   �� $ 	TIME_DATE�6d   5I      5K        5L      $ 	Phone No.��6-   $ 1* 6@    5M      �� 5N      .R�5O   "   �� $ Right=�6,   ��6B   �� $ PHONE_NO�6c   5P      5R        5S      $	 Age��6-   $ 1* 6:    5T      �� 5U      .R�5V   "   �� $ Right=�6,   ��6B   �� $	 AGE�6^   5W      5Y      5�      5�      � 5�   
   $��3��6   $��0,134.285,10,10.715q�6   $��2��69   .+�5�      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   .+�5�      �� $��Total Employee ::��6   $	��150��64   
��� � �$
��Bold"�6S     MyLabel#��[ 6e   $��34��6�   5�      �� 5�      -   5        $��	total_emp��5�   1   $
��Left=�6   {�.  $��23��6T   $��
574,18,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��120��6�   5�      5�      5�      