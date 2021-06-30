using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Buyers_and_orders
{
    [Serializable]
    public class Customer
    {
        /// <summary>
        ///     Constructor that fills in customer information fields and compute a password hash.
        /// </summary>
        public Customer(string fullName, string address, string phoneNumber, string eMail, string password)
        {
            FullName = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
            EMail = eMail;
            Cart = new Cart {Customer = this};
            Orders = new List<Order>();
            Hash = ComputeSha256Hash(EMail + password);
        }

        /// <summary>
        ///     Constructor for deserialization.
        /// </summary>
        public Customer()
        {
        }

        // Customer full name.
        public string FullName { get; set; }

        // Customer address.
        public string Address { get; set; }

        // Customer phone number.
        public string PhoneNumber { get; set; }

        // Customer E-Mail.
        public string EMail { get; set; }

        // Hashed customer password.
        public string Hash { get; set; }

        // Customer's order list.
        public List<Order> Orders { get; set; }

        // Sum of paid orders.
        [XmlIgnore] public double OrdersSum => Math.Round(Orders.Where(x => x.IsPaid()).Sum(x => x.Value), 2);

        // Customer cart.
        public Cart Cart { get; set; }

        /// <summary>
        ///     Calculate hash from password and salt as customer login.
        /// </summary>
        public static string ComputeSha256Hash(string rawData)
        {
            using var sha256Hash = SHA256.Create();
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            var builder = new StringBuilder();
            foreach (var t in bytes)
                builder.Append(t.ToString("x2"));
            return builder.ToString();
        }
    }
}