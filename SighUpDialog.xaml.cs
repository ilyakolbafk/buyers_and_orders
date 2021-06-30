using System.Collections.Generic;
using System.Windows;

namespace Buyers_and_orders
{
    /// <summary>
    ///     Interaction logic for SighUpDialog.xaml
    /// </summary>
    public partial class SighUpDialog : Window
    {
        public SighUpDialog(List<string> eMails)
        {
            EMails = eMails;
            InitializeComponent();
        }

        // Customer first name.
        public string FirstName { get; set; }

        // Customer last name.
        public string LastName { get; set; }

        // Customer middle name.
        public string MiddleName { get; set; }

        // Customer phone number.
        public string PhoneNumber { get; set; }

        // Customer address.
        public string Address { get; set; }

        // Customer E-Mail.
        public string EMail { get; set; }

        // Customer password.
        public string Password { get; set; }

        // List of registered customers.
        public List<string> EMails { get; set; }


        /// <summary>
        ///     Check fields to create a new customer.
        /// </summary>
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            // Cancel user creation if any of the fields is filled in incorrectly or empty.
            if (CustFirstName.Text.Length == 0 || CustMiddleName.Text.Length == 0 || CustLastName.Text.Length == 0 ||
                !IsPhoneNumberCorrect() || CustAddress.Text.Length == 0 || !IsEMailCorrect()
                || CustPassword.Password.Length < 8 || EMails.Contains(EMail))
            {
                var message = "Некоторые поля незаполнены или заполнены неверно.";
                // Add hints depending on the error in filling in the fields.
                if (!IsPhoneNumberCorrect())
                    message += "\nПример номера телефона: \"+7(903)-756-33-34\" или \"89037563334\" ";
                if (!IsEMailCorrect())
                    message += "\nПример E-Mail'а: \"name@gmail.com\"";
                if (EMails.Contains(EMail))
                    message += "\nТакой Email уже зарегистрирован.";
                if (CustPassword.Password.Length < 8)
                    message += "\nПароль должен содержать как минимум 8 символов";
                MessageBox.Show(message);
            }
            else
            {
                FirstName = CustFirstName.Text;
                MiddleName = CustMiddleName.Text;
                LastName = CustLastName.Text;
                Address = CustAddress.Text;
                Password = CustPassword.Password;
                DialogResult = true;
            }
        }

        // Check if the phone number is filled in correctly.
        private bool IsPhoneNumberCorrect()
        {
            var phoneNumber = CustPhoneNumber.Text;
            if (phoneNumber.Length == 0) return false;
            if (!long.TryParse(phoneNumber.Replace("-", "").Replace("(", "")
                .Replace(")", "").Replace("+", "").Replace(" ", ""), out _))
                return false;
            PhoneNumber = phoneNumber;
            return true;
        }

        // Check if the e-mail is filled in correctly.
        private bool IsEMailCorrect()
        {
            var email = CustEMAil.Text;
            if (email.Length < 5 || !email.Contains("@") || !email.Contains(".") || email.IndexOf('@') == 0
                || email.LastIndexOf('.') - 1 <= email.IndexOf('@') || email.LastIndexOf('.') == email.Length - 1)
                return false;
            EMail = email;
            return true;
        }
    }
}