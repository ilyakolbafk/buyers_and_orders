using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Buyers_and_orders
{
    [Serializable]
    public class Order
    {
        // Next order number.
        public static int Id = 1;

        /// <summary>
        ///     Constructor of an order by products in the cart.
        /// </summary>
        public Order(Cart basket)
        {
            Products = basket.Products;
            Number = Id++;
            OrderTime = DateTime.Now;
            Customer = basket.Customer;
            Value = basket.Value;
            Status = Status.Default;
        }

        /// <summary>
        ///     Constructor for deserialization.
        /// </summary>
        public Order()
        {
        }

        // List of products in order.
        public List<Product> Products { get; set; }

        // Order number.
        public int Number { get; set; }

        // Order cost.
        public double Value { get; set; }

        // Date and time of order.
        public DateTime OrderTime { get; set; }

        // Customer who made an order.
        [XmlIgnore] public Customer Customer { get; set; }

        // Order status
        public Status Status { get; set; }

        // Order status in text representation.
        public string StatusStr
        {
            get
            {
                var res = "";
                if ((int) Status % 2 == 1) res += "Обработан ";
                if ((int) Status % 4 == 3) res += "+ Оплачен ";
                if ((int) Status % 8 == 7) res += " + Отгружен ";
                if ((int) Status == 15) res += " + Исполнен";
                return res;
            }
        }

        // Show if the order has been paid.
        public bool IsPaid()
        {
            return Status >= Status.Paid;
        }

        // Show if the order has been processed.
        public bool IsProcessed()
        {
            return Status >= Status.Processed;
        }

        // Show if the order has been shipped.
        public bool IsShipped()
        {
            return Status >= Status.Shipped;
        }

        // Show if the order has been executed.
        public bool IsExecuted()
        {
            return Status >= Status.Executed;
        }

        /// <summary>
        ///     Add paid to order status.
        /// </summary>
        public void Pay()
        {
            Status ^= Status.Paid;
        }

        /// <summary>
        ///     Add processed to order status.
        /// </summary>
        public void Process()
        {
            Status ^= Status.Processed;
        }

        /// <summary>
        ///     Add shipped to order status.
        /// </summary>
        public void Ship()
        {
            Status ^= Status.Shipped;
        }

        /// <summary>
        ///     Add executed to order status.
        /// </summary>
        public void Execute()
        {
            Status ^= Status.Executed;
        }
    }
}