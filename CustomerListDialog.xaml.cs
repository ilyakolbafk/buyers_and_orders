using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Buyers_and_orders
{
    /// <summary>
    ///     Interaction logic for CustomerListDialog.xaml
    /// </summary>
    public partial class CustomerListDialog : Window
    {
        // Customers list.
        public ObservableCollection<Customer> Customers;

        /// <summary>
        ///     Constructor which fill the datagrid with customer information.
        /// </summary>
        public CustomerListDialog(ObservableCollection<Customer> customers)
        {
            Customers = customers;
            InitializeComponent();
            CustomerGrid.ItemsSource = Customers;
        }

        /// <summary>
        ///     Check the availability of the selected customer.
        /// </summary>
        private void CustomerGrid_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            CustomerOrders.IsEnabled = CustomerGrid.SelectedItem != null;
        }

        /// <summary>
        ///     Open orders of the selected customer.
        /// </summary>
        private void CustomerOrders_OnClick(object sender, RoutedEventArgs e)
        {
            var ordersDialog = new OrdersDialog(Customers[CustomerGrid.SelectedIndex].Orders, false);
            ordersDialog.ShowDialog();
        }
    }
}