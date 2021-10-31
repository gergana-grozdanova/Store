using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Products.Perishable
{
    class Food : IPerishable
    {
        private string name;
        private string brand;
        private decimal price;

        public Food(string name, string brand, decimal price,DateTime dt)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.ExpirationDate = dt;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == "" || value == " ")
                {
                    throw new ArgumentException("Invalid food name!");
                }
                this.name = value;
            }
        }
        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                if (value == "" || value == " ")
                {
                    throw new ArgumentException("Invalid food brand!");
                }
                this.brand = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid food price!");
                }
                this.price = value;
            }
        }

        public DateTime ExpirationDate { get; set; }

    }
}
