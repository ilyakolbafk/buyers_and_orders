using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Buyers_and_orders
{
    /// <summary>
    ///     Interaction logic for OrdersDialog.xaml
    /// </summary>
    public partial class OrdersDialog : Window
    {
        // Window opened by customer or seller.
        public bool IsCustomer;

        // Customer order list.
        public List<Order> Orders;

        /// <summary>
        ///     Constructor fills the datagrid with orders and shows the sum of paid orders.
        /// </summary>
        public OrdersDialog(List<Order> orders, bool isCustomer)
        {
            Orders = orders;
            IsCustomer = isCustomer;
            InitializeComponent();
            CustomerOrderGrid.ItemsSource = orders;
            PaidSum();
        }

        /// <summary>
        ///     Allow payment for the order only if it is processed and not paid.
        /// </summary>
        private void CustomerOrderGrid_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (!IsCustomer) PayForOrder.IsEnabled = false;
            else
                PayForOrder.IsEnabled = CustomerOrderGrid.SelectedItem != null
                                        && !Orders[CustomerOrderGrid.SelectedIndex].IsPaid()
                                        && Orders[CustomerOrderGrid.SelectedIndex].IsProcessed();
        }

        /// <summary>
        ///     Pay for the order and change the sum of paid orders.
        /// </summary>
        private void PayForOrder_OnClick(object sender, RoutedEventArgs e)
        {
            Orders[CustomerOrderGrid.SelectedIndex].Pay();
            PaidSum();
            CustomerOrderGrid.Items.Refresh();
        }

        /// <summary>
        ///     Change the sum of paid orders.
        /// </summary>
        private void PaidSum()
        {
            Sum.Content = Orders.Where(x => x.IsPaid()).Sum(x => x.Value);
        }
    }
}