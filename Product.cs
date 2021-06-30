using System;

namespace Buyers_and_orders
{
    [Serializable]
    public class Product
    {
        // Name of product.
        public string Name { get; set; }

        // Code of product.
        public string Code { get; set; }

        // Price of product.
        public double Price { get; set; }

        // Number of product.
        public int Number { get; set; }

        /// <summary>
        ///     Check the equality of the name, code and price of the products.
        /// </summary>
        public bool Equal(Product product)
        {
            return Name == product.Name && Code == product.Code && Price == product.Price;
        }
    }
}