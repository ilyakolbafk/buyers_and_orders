using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Buyers_and_orders
{
    /// <summary>
    ///     Interaction logic for ReportDialog.xaml
    /// </summary>
    public partial class ReportDialog : Window
    {
        // The minimum sum of paid orders.
        public double OrderSum;

        // Shop product list.
        public ObservableCollection<Product> Products;

        // Product selected by the seller as defective.
        public Product SelectedProduct;

        /// <summary>
        ///     Constructor fills the datagrid with products.
        /// </summary>
        public ReportDialog(ObservableCollection<Product> products)
        {
            Products = products;
            InitializeComponent();
            CustomerProductGrid.ItemsSource = Products;
        }

        /// <summary>
        ///     Determine the product selected by the seller.
        /// </summary>
        private void ChooseProduct_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            SelectedProduct = Products[CustomerProductGrid.SelectedIndex];
        }

        /// <summary>
        ///     Open product selection if the seller has selected a datagrid row.
        /// </summary>
        private void CustomerProductGrid_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            SumReport.IsEnabled = CustomerProductGrid.SelectedItem != null;
        }

        /// <summary>
        ///     Check the field for a number for number and for positivity.
        /// </summary>
        private void SumReport_OnClick(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(Sum.Text, out OrderSum) || OrderSum <= 0)
                MessageBox.Show("Введите положительное число (запятая как разделитель)");
            else
                DialogResult = true;
        }
    }
}