   M S B A M L   `   `   `  ����  Buyers_and_orders,    &Buyers_and_orders.CustomerReportDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  CustomerReportDialog��5   	   $	��300��6&   $	��400��66   $	��500��6C   $	��700��6R   .��5      � .+�5	   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CustomerGrid��5	      $��25,25,25,25q�5
         AutoGenerateColumns$ False��5         CanUserAddRows$ False��6/      
IsReadOnly$
 True��6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО��6%      MinWidth$	 200Q�5   %      MaxWidth$	 500Q�64   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   2   �� 
 �� Path$
 FullName�5   4     5      $ E-Mail��6%   $	 125Q�5   %   $	 200Q�64   	 5   5   �� $
 EMail�5   4     5      $! Номер телефона��6%   $	 125Q�5   %   $	 200Q�64   	 5   =   �� $
 PhoneNumber�5   4     5      $ 
Адрес��6%   $	 150Q�5   %   $	 250Q�64   	 5   4   �� $
 Address�5   4     5      $ Дата заказа��6%   $	 100Q�5   %   $	 200Q�64   -   5        OrderTimeColumn��	 5   :   �� $
 	OrderTime�5   C     5      $ Сумма заказов��6%   $	 100Q�5   %   $	 200Q�64   -   5        OrdersSumColumn��	 5   <   �� $
 	OrdersSum�5   C   5      5      5      