using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Buyers_and_orders
{
    /// <summary>
    ///     Interaction logic for SignInDialog.xaml
    /// </summary>
    public partial class SignInDialog : Window
    {
        public SignInDialog(List<(string, string)> userList)
        {
            UserList = userList;
            InitializeComponent();
        }

        // List of customer e-mails and their hashed passwords.
        public List<(string, string)> UserList { get; set; }

        // Login for authorization.
        public string EMail { get; set; }

        /// <summary>
        ///     Checks the correctness of the login and password and enters the program.
        /// </summary>
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            // Seller login check.
            if (CustEMAil.Text == "admin" && CustPassword.Password == "admin")
            {
                EMail = CustEMAil.Text;
                DialogResult = true;
            }
            else
            {
                // Login check.
                if (UserList.All(x => x.Item1 != CustEMAil.Text))
                {
                    MessageBox.Show("Введен некорректный E-Mail.");
                }
                // Password check.
                else if (Customer.ComputeSha256Hash(CustEMAil.Text + CustPassword.Password) !=
                         UserList.First(x => x.Item1 == CustEMAil.Text).Item2)
                {
                    MessageBox.Show("Введен некорректный пароль.");
                }
                else
                {
                    EMail = CustEMAil.Text;
                    DialogResult = true;
                }
            }
        }
    }
}