   M S B A M L   `   `   `  ����  Buyers_and_orders$    Buyers_and_orders.ReportDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  ReportDialog��5   	   $	��450��6   $	��700��6.   $	��500��6=   $	��800��6J   .��5      � .+�5	   
   �� $
��Left=�6   $��90��6/   $��	25,25,0,0q�6;    �� TextAlignment$ Center=�6N   $����Вывести клиентов, оплативших заказы на сумму, превышающую заданную + саму эту сумму.��5
      $
��Wrap=�5      $	��Top=�6(   $	��200��6@   $��15(�6L   �� 5   
   $
��Left=�6   $��25��6/   $��
250,25,0,0q�6;   $ Center=�6O   $d��^Вывести список клиентов, заказавших заданный товар��5      $
��Wrap=�5      $	��Top=�6(   $	��400��6@   $��15(�6L   �� 5   
   $ ��Введите сумму:��6   $
��Left=�6)   $��
25,110,0,0q�6D   $	��200��6X   $	��Top=�5      $��Center=�6(   $��15(�6L   �� 5   
   -   5         ��Name$	 Sum��5      $
��Left=�5      $��
25,140,0,0q�6-   $��15(�6A   $�� ��5       �� TextWrapping$
 Wrap=�6   $	��Top=�6.   $	��200��6F   5      �� 5   
   -   5         ��Name$ 	SumReport��5   8   $��Открыть отчет��5      $
��Left=�6)   $��	25,0,0,25q�6D   $��Bottom=�5      $	��200��6,   6K   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CustomerProductGrid��5      $��250,50,25,25q�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��6/      
IsReadOnly$
 True��6F   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$0
 *Название товара/услуги��6%      MinWidth$	 200Q�5   %      MaxWidth$	 400Q�64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   E   ��  �� Path$
 Name�5   4     5      $
 Артикул��6%   $	 125Q�5   %   $	 200Q�64    5   6   �� $
 Code�5   4     5      $
 Цена��6%   $	 125Q�5   %   $	 200Q�64    5   3   �� $ Price�5   4     5       $
 Количество��6%   $	 125Q�5!   %   $	 200Q�64    5    9   �� $ Number�5!   4    � ContextMenu 5#      �� 5$      -   5         ��Name$ DataGridContextMenu��5$      .@�5%      m� -   5         m�Name$ ChooseProduct��5%      $-��'Отчет по этому товару��66   6U   5&      5(      5)      5*      