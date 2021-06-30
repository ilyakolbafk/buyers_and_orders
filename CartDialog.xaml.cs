using System.Windows;
using System.Windows.Controls;

namespace Buyers_and_orders
{
    /// <summary>
    ///     Interaction logic for CartDialog.xaml
    /// </summary>
    public partial class CartDialog : Window
    {
        /// <summary>
        ///     Constructor that creates a datagrid of cart products.
        /// </summary>
        public CartDialog(Cart cart)
        {
            Cart = cart;
            InitializeComponent();
            Cost.Content = Cart.Value;
            CustomerProductGrid.ItemsSource = Cart.Products;
        }

        // Cart, contents of which are displayed in the window.
        public Cart Cart { get; set; }

        /// <summary>
        ///     Complete the dialog with creating a new order.
        /// </summary>
        private void CheckoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        /// <summary>
        ///     Check the availability of the selected product.
        /// </summary>
        private void CustomerProductGrid_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            RemoveProductFromCart.IsEnabled = CustomerProductGrid.SelectedItem != null;
        }

        /// <summary>
        ///     Remove product from the cart on user click.
        /// </summary>
        private void RemoveProductFromCart_OnClick(object sender, RoutedEventArgs e)
        {
            Cart.Remove(CustomerProductGrid.SelectedIndex);
            Cost.Content = Cart.Value;
            CustomerProductGrid.ItemsSource = Cart.Products;
            CustomerProductGrid.Items.Refresh();
        }
    }
}