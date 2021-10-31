using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.Products
{
    class Clothes : IProduct
    {
        private string[] SIZES = new string[] { "XS", "S", "M", "L", "XL"};
        
        private string name;
        private string brand;
        private decimal price;
        private string color;
        private string size;

        public Clothes(string name,string brand,decimal price,string size,string color)
        {
            this.Size = size;
            this.Name = name;
            this.Brand = brand;
            this.Color = color;
            this.Price = price;
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value==""||value==" ")
                {
                    throw new ArgumentException("Invalid clothes name!");
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
                    throw new ArgumentException("Invalid clothes brand!");
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
                if (value <0)
                {
                    throw new ArgumentException("Invalid clothes price!");
                }
                this.price = value;
            }
        }
        public string Size 
        { 
            get
            {
                return this.size;
            }
            set
            {
                if (!SIZES.Contains(value))
                {
                    throw new ArgumentException("Invalid clothes size!");
                }
                this.size = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (value == "" || value == " ")
                {
                    throw new ArgumentException("Invalid clothes color!");
                }
                this.color = value;
            }
        }
    }
}
