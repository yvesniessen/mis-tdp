using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace MIS_TDP.TestField
{
    public class BusinessObject
    {

    }

    // Define the Business Object "Product" with two public properties
//    of simple datatypes.
    public class Product
    {
        private string m_name;
        private int m_price;

        public Product(string name, int price)
        {
            m_name = name;
            m_price = price;
        }

        public string Name
        {
            get
            {
                return m_name;
            }
        }

        public int Price
        {
            get
            {
                return m_price;
            }
        }
    }

    // Define Business Object "Merchant" that provides a 
//    GetProducts method that returns a collection of 
//    Product objects.

    public class Merchant
    {
        private List<Product> m_products;

        public Merchant()
        {
            m_products = new List<Product>();
            m_products.Add(new Product("Pen", 25));
            m_products.Add(new Product("Pencil", 30));
            m_products.Add(new Product("Notebook", 15));
        }

        public List<Product> GetProducts()
        {
            return m_products;
        }
    }
}
