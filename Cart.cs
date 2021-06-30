using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Buyers_and_orders
{
    [Serializable]
    public class Cart
    {
        /// <summary>
        ///     Cart constructor.
        /// </summary>
        public Cart()
        {
            Products ??= new List<Product>();
        }

        // List of products in the cart.
        public List<Product> Products { get; set; }

        // Price of products in the cart.
        public double Value => Math.Round(Products.Sum(x => x.Price * x.Number), 2);

        // Cart owner.
        [XmlIgnore] public Customer Customer { get; set; }

        /// <summary>
        ///     Add product to the cart.
        /// </summary>
        public void Add(Product product)
        {
            Products ??= new List<Product>();
            // If there is a product in the cart, we increase its quantity by one, otherwise we add the product in a single copy.
            if (Products.Any(x => x.Equal(product)))
                Products.First(x => x.Equal(product)).Number++;
            else
                Products.Add(new Product {Code = product.Code, Name = product.Name, Price = product.Price, Number = 1});
        }

        /// <summary>
        ///     Remove product from the cart by index.
        /// </summary>
        public void Remove(int index)
        {
            var product = Products[index];
            Products.Remove(product);
            MainWindow.Products.First(x => x.Equal(product)).Number += product.Number;
        }

        /// <summary>
        ///     Remove all products from the cart.
        /// </summary>
        public void RemoveAll()
        {
            while (Products.Count != 0) Remove(0); 
        }
    }
}