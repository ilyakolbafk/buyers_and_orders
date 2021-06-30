using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Buyers_and_orders
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List of all codes of products.
        public static List<string> Codes = new List<string>();

        // Random to generate products.
        private readonly Random _rnd = new Random();

        // All Russian nouns.
        private readonly List<string> _russianWords;

        // Authorized client.
        private Customer _currentCustomer;

        // List of active orders.
        public List<Order> ActiveOrdersList = new List<Order>();

        // List of registered customers.
        public ObservableCollection<Customer> Customers = new ObservableCollection<Customer>();

        // Is the display mode enabled for active orders only?
        public bool IsActiveOrders;

        // List of all orders.
        public List<Order> Orders = new List<Order>();

        // List of products in the store.
        public static ObservableCollection<Product> Products = new ObservableCollection<Product>();

        /// <summary>
        ///     Deserializes products and customers and creates a new product list if the old one is missing.
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                XmlDeserialize();
                if (!File.Exists("russian.txt") && Products.Count == 0)
                {
                    MessageBox.Show("Удаление файла с русскими существительными при отсутсвии списка товаров" +
                                    " ведет к невозможности использовать программу, восстановите файл \"russian.txt\" и " +
                                    "запустите программу еще раз.");
                    Close();
                    return;
                }

                if (!File.Exists("products.xml"))
                {
                    MessageBox.Show("Добро пожаловать в программу \"Покупатели и Заказы\".\nВ данной программе" +
                                    " выполнен весь основной и дополнительный функционал.\nПочти все использование программы " +
                                    "сводится к вызову контекстного меню правой кнопкой мыши и нажатию на активные кнопки.\n" +
                                    "Товары генерируются автоматически (1000 товаров).\nДля того чтобы создать новый набор " +
                                    "товаров и вызвать это сообщение еще раз необходимо удалить файл \"products.xml\" " +
                                    "из папки с exe-шником. Иначе добавить, редактировать или удалять товары невозможно.\n" +
                                    "Аккаунт продавца единственный. Логин: \"admin\", Пароль: \"admin\".");
                }
                _russianWords = File.ReadAllLines("russian.txt", Encoding.UTF8).ToList();
                // Create 1000 products.
                if (Products.Count == 0)
                    for (var i = 0; i < 1000; i++)
                        Products.Add(RandomProduct());
            }
            catch (Exception e)
            {
                Products = new ObservableCollection<Product>();
                MessageBox.Show(e.Message);
            }

            CustomerProductGrid.ItemsSource = Products;
        }

        /// <summary>
        ///     Return a random Russian noun.
        /// </summary>
        private string RandomName() => _russianWords[_rnd.Next(0, _russianWords.Count)];

        /// <summary>
        ///     Create a random product.
        /// </summary>
        private Product RandomProduct()
        {
            var name = RandomName();
            var code = RandomName();
            // Checking the uniqueness of the code.
            while (Codes.Contains(code))
                code = RandomName();
            Codes.Add(code);
            var price = Math.Round(_rnd.NextDouble() * _rnd.NextDouble() * _rnd.NextDouble() * _rnd.NextDouble() *
                Math.Sqrt(_rnd.Next(0, int.MaxValue)) + 0.01, 2);
            var number = (int) Math.Round(_rnd.NextDouble() * 1.2345 *
                                          Math.Sqrt(_rnd.Next(0, (int) Math.Round(Math.Sqrt(int.MaxValue)))));
            return new Product {Name = name, Code = code, Price = price, Number = number};
        }

        /// <summary>
        ///     Open the authorization window and enter the program.
        /// </summary>
        private void SignInButton_OnClick(object sender, RoutedEventArgs e)
        {
            var signInDialog = new SignInDialog(Customers.Select(x => (x.EMail, x.Hash)).ToList());
            signInDialog.ShowDialog();
            if (signInDialog.DialogResult != true) return;
            // Seller login check.
            if (signInDialog.EMail == "admin")
            {
                SellerMode();
            }
            else
            {
                _currentCustomer = Customers.First(x => x.EMail == signInDialog.EMail);
                CustomerMode();
            }
        }

        /// <summary>
        ///     Open the registration window and enter the program.
        /// </summary>
        private void SighUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            var signUpDialog = new SighUpDialog(Customers.Select(x => x.EMail).ToList());
            signUpDialog.ShowDialog();
            if (signUpDialog.DialogResult != true) return;
            // Create new customer.
            _currentCustomer = new Customer(
                $"{signUpDialog.LastName} {signUpDialog.FirstName} {signUpDialog.MiddleName}",
                signUpDialog.Address, signUpDialog.PhoneNumber, signUpDialog.EMail, signUpDialog.Password);
            Customers.Add(_currentCustomer);
            CustomerMode();
        }

        /// <summary>
        ///     Makes active controls for the seller.
        /// </summary>
        private void SellerMode()
        {
            SignInButton.Visibility = Visibility.Hidden;
            SighUpButton.Visibility = Visibility.Hidden;
            ExitButton.Visibility = Visibility.Visible;
            CustomerOrderGrid.Visibility = Visibility.Visible;
            Orders = Customers.SelectMany(x => x.Orders).ToList();
            CustomerOrderGrid.ItemsSource = Orders;
            ActiveOrders.Visibility = Visibility.Visible;
            IsActiveOrders = false;
            CustomerList.Visibility = Visibility.Visible;
            Report.Visibility = Visibility.Visible;
        }

        /// <summary>
        ///     Makes active controls for the customer.
        /// </summary>
        private void CustomerMode()
        {
            SignInButton.Visibility = Visibility.Hidden;
            SighUpButton.Visibility = Visibility.Hidden;
            ExitButton.Visibility = Visibility.Visible;
            Cart.Visibility = Visibility.Visible;
            OrderList.Visibility = Visibility.Visible;
            CustomerProductGrid.Visibility = Visibility.Visible;
            CustomerProductGrid.ItemsSource = Products;
        }

        /// <summary>
        ///     Deactivate controls when logging out.
        /// </summary>
        private void ExitButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentCustomer = null;
            SignInButton.Visibility = Visibility.Visible;
            SighUpButton.Visibility = Visibility.Visible;
            ExitButton.Visibility = Visibility.Hidden;
            Cart.Visibility = Visibility.Hidden;
            OrderList.Visibility = Visibility.Hidden;
            CustomerProductGrid.Visibility = Visibility.Hidden;
            CustomerOrderGrid.Visibility = Visibility.Hidden;
            ActiveOrders.Visibility = Visibility.Hidden;
            AllOrders.Visibility = Visibility.Hidden;
            CustomerList.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///     Open shopping cart.
        /// </summary>
        private void Cart_OnClick(object sender, RoutedEventArgs e)
        {
            var cartDialog = new CartDialog(_currentCustomer.Cart);
            cartDialog.ShowDialog();
            if (cartDialog.DialogResult != true)
            {
                CustomerProductGrid.Items.Refresh();
                return;
            }
            if (cartDialog.Cart.Products.Count > 0)
            {
                _currentCustomer.Orders.Add(new Order(cartDialog.Cart));
                _currentCustomer.Cart = new Cart {Customer = _currentCustomer};
                MessageBox.Show($"Заказ под номером {_currentCustomer.Orders[^1].Number} успешно создан.");
            }
            else
            {
                MessageBox.Show("Корзина пустая, заказ не создан.");
            }
            CustomerProductGrid.Items.Refresh();
        }

        /// <summary>
        ///     Open a window with customer orders.
        /// </summary>
        private void OrderList_OnClick(object sender, RoutedEventArgs e)
        {
            new OrdersDialog(_currentCustomer.Orders, true).ShowDialog();
        }

        /// <summary>
        ///     Allow adding to cart only if there is a selected row in the datagrid.
        /// </summary>
        private void CustomerProductGrid_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            AddProductToCart.IsEnabled = CustomerProductGrid.SelectedItem != null;
        }

        /// <summary>
        ///     Add product to cart.
        /// </summary>
        private void AddProductToCart_OnClick(object sender, RoutedEventArgs e)
        {
            var rowIndex = CustomerProductGrid.SelectedIndex;
            var product = Products[rowIndex];
            if (product.Number == 0)
                MessageBox.Show("Товар нельзя добавить в корзину. Товар закончился.");
            else
            {
                product.Number--;
                _currentCustomer.Cart.Add(product);
                CustomerProductGrid.Items.Refresh();
            }
            
        }

        /// <summary>
        ///     Serializes products and customers.
        /// </summary>
        private void XmlSerialize(string path1 = "products.xml", string path2 = "customers.xml")
        {
            try
            {
                var formatter = new XmlSerializer(typeof(ObservableCollection<Product>));
                using var fs1 = File.Create(path1);
                // Serializing products.
                formatter.Serialize(fs1, Products);
                formatter = new XmlSerializer(typeof(ObservableCollection<Customer>));
                using var fs2 = File.Create(path2);
                // Serializing customers.
                formatter.Serialize(fs2, Customers);
                // Serializing next order number.
                File.WriteAllText("order_id.txt", Order.Id.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        ///     Deserializes products and customers.
        /// </summary>
        private void XmlDeserialize(string path1 = "products.xml", string path2 = "customers.xml")
        {
            try
            {
                var formatter = new XmlSerializer(typeof(ObservableCollection<Product>));
                if (!File.Exists(path1)) return;
                using var fs = new FileStream(path1, FileMode.OpenOrCreate);
                // Deserializing products.
                Products = (ObservableCollection<Product>) formatter.Deserialize(fs);
                var idStr = File.ReadAllText("order_id.txt");
                // Deserializing next order number.
                Order.Id = int.TryParse(idStr, out var id) ? id : 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            try
            {
                var formatter = new XmlSerializer(typeof(ObservableCollection<Customer>));
                if (!File.Exists(path2)) return;
                using var fs = new FileStream(path2, FileMode.OpenOrCreate);
                // Deserializing customers.
                Customers = (ObservableCollection<Customer>) formatter.Deserialize(fs);
                // Appoints cart and order owners.
                foreach (var customer in Customers)
                {
                    customer.Cart.Customer = customer;
                    customer.Orders.ForEach(x => x.Customer = customer);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        ///     Serialize data on program exit.
        /// </summary>
        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            foreach (var customer in Customers) 
                customer.Cart.RemoveAll();
            XmlSerialize();
        }

        /// <summary>
        ///     Determination of a possible action with the selected order depending on its status.
        /// </summary>
        private void CustomerOrderGrid_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            ProcessOrder.IsEnabled = false;
            ShipOrder.IsEnabled = false;
            ExecuteOrder.IsEnabled = false;
            if (CustomerOrderGrid.SelectedItem == null) return;

            var order = IsActiveOrders
                ? ActiveOrdersList[CustomerOrderGrid.SelectedIndex]
                : Orders[CustomerOrderGrid.SelectedIndex];
            if (!order.IsProcessed())
            {
                ProcessOrder.IsEnabled = true;
                return;
            }

            if (!order.IsShipped() && order.IsPaid())
            {
                ShipOrder.IsEnabled = true;
                return;
            }

            if (!order.IsExecuted() && order.IsPaid())
                ExecuteOrder.IsEnabled = true;
        }

        /// <summary>
        ///     Adds the status processed to the status of the order.
        /// </summary>
        private void ProcessOrder_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsActiveOrders)
                ActiveOrdersList[CustomerOrderGrid.SelectedIndex].Process();
            else
                Orders[CustomerOrderGrid.SelectedIndex].Process();
            CustomerOrderGrid.Items.Refresh();
        }

        /// <summary>
        ///     Adds the status shipped to the status of the order.
        /// </summary>
        private void ShipOrder_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsActiveOrders)
                ActiveOrdersList[CustomerOrderGrid.SelectedIndex].Ship();
            else
                Orders[CustomerOrderGrid.SelectedIndex].Ship();
            CustomerOrderGrid.Items.Refresh();
        }

        /// <summary>
        ///     Adds the status executed to the status of the order.
        /// </summary>
        private void ExecuteOrder_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsActiveOrders)
                ActiveOrdersList[CustomerOrderGrid.SelectedIndex].Execute();
            else
                Orders[CustomerOrderGrid.SelectedIndex].Execute();
            CustomerOrderGrid.Items.Refresh();
        }

        /// <summary>
        ///     Change the contents of the datagrid of all orders to active orders.
        /// </summary>
        private void ActiveOrders_OnClick(object sender, RoutedEventArgs e)
        {
            ActiveOrders.Visibility = Visibility.Hidden;
            AllOrders.Visibility = Visibility.Visible;
            IsActiveOrders = true;
            ActiveOrdersList = Customers.SelectMany(x => x.Orders).Where(x => !x.IsExecuted()).ToList();
            CustomerOrderGrid.ItemsSource = ActiveOrdersList;
            CustomerOrderGrid.Items.Refresh();
        }

        /// <summary>
        ///     Change the contents of the datagrid of active orders to all orders.
        /// </summary>
        private void AllOrders_OnClick(object sender, RoutedEventArgs e)
        {
            ActiveOrders.Visibility = Visibility.Visible;
            AllOrders.Visibility = Visibility.Hidden;
            IsActiveOrders = false;
            CustomerOrderGrid.ItemsSource = Orders;
            CustomerOrderGrid.Items.Refresh();
        }

        /// <summary>
        ///     Open a window with datagrid of list of customers.
        /// </summary>
        private void CustomerList_OnClick(object sender, RoutedEventArgs e)
        {
            var customerListDialog = new CustomerListDialog(Customers);
            customerListDialog.ShowDialog();
        }

        /// <summary>
        ///     Opens the report dialog box and, depending on the seller's actions, opens an optional report window.
        /// </summary>
        private void Report_OnClick(object sender, RoutedEventArgs e)
        {
            var reportDialog = new ReportDialog(Products);
            reportDialog.ShowDialog();
            if (reportDialog.DialogResult != true) return;
            if (reportDialog.SelectedProduct is null)
                // Create a report of customers: who paid orders for an sum greater or equal to the one selected by the seller.
                new CustomerReportDialog
                {
                    CustomerGrid =
                    {
                        ItemsSource = Customers
                            .Where(x => x.OrdersSum >= reportDialog.OrderSum)
                            .OrderByDescending(x => x.OrdersSum).ToList()
                    },
                    OrderTimeColumn = {Visibility = Visibility.Hidden}
                }.ShowDialog();
            else
                // Create a report of customers who bought a defective product.
                new CustomerReportDialog
                {
                    CustomerGrid =
                    {
                        ItemsSource = Customers.Where(x => x.Orders
                                .Any(x => x.Products.Any(x => x.Equal(reportDialog.SelectedProduct))))
                            .Select(x => new
                            {
                                x.FullName, x.EMail, x.PhoneNumber, x.Address,
                                x.Orders.First(x => x.Products.Any(x => x.Equal(reportDialog.SelectedProduct)))
                                    .OrderTime
                            }).ToList()
                    },
                    OrdersSumColumn = {Visibility = Visibility.Hidden}
                }.ShowDialog();
        }
    }
}