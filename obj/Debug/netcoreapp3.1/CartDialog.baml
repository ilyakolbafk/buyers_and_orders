   M S B A M L   `   `   `  ����  Buyers_and_orders"    Buyers_and_orders.CartDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
CartDialog��5   	   $	��300��6   $	��500��6,   $	��450��6;   $	��800��6H   .��5      � .+�5	   
   �� -   5         ��Name$ CheckoutButton��5	      $	��125��6)   $��20��65   $��Center=�6A   $��Center=�5
      $!��Оформить заказ��65   $��Right=�6N   $��	0,25,25,0q�5      $	��Top=�6$   6<   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CustomerProductGrid��5      $��25,25,200,25q�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��6/      
IsReadOnly$
 True��6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$0 *Название товара/услуги��6%      MinWidth$	 200Q�5   %   	   MaxWidth$		 400Q�64   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5   E   ��  �� Path$
 Name�5   4     5      $ Артикул��6%   $	 125Q�5   %   $		 200Q�64   
 5   6   �� $
 Code�5   4     5      $ Цена��6%   $	 125Q�5   %   $		 200Q�64   
 5   3   �� $ Price�5   4     5      $ Количество��6%   $	 125Q�5   %   $		 200Q�64   
 5   9   �� $ Number�5   4    � ContextMenu 5      �� 5      -   5         ��Name$ DataGridContextMenu��5      .@�5      m� -   5         m�Name$ RemoveProductFromCart��5      $��Удалить товар��6>   5      5      5      �� 5    
   $(��"Стоимость корзины:��6   $��Right=�6-   $��24��6I   $��	0,75,25,0q�6U   $	��Top=�5!      $	��125��6(   �� 5"   
   -   5         ��Name$
 Cost��5"      $�� ��6   $��Right=�6)   $��24��6E   $��
0,100,25,0q�6Q   $	��Top=�5#      $	��125��6(   $��Center=�64   5$      5%      