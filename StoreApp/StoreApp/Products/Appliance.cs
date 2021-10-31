using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Products
{
    class Appliance : IProduct
    {
        private string name;
        private string brand;
        private decimal price;
        private string model;
        private double weight;

        public Appliance(string name,string brand,decimal price,string moodel,DateTime pd, double weight)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Model = model;
            this.Weight = weight;
            this.ProductionDate = pd;
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
                    throw new ArgumentException("Invalid applience name!");
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
                    throw new ArgumentException("Invalid applience brand!");
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
                    throw new ArgumentException("Invalid applience price!");
                }
                this.price = value;
            }
        }
        public string  Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value ==""||value==" ")
                {
                    throw new ArgumentException("Invalid applience model!");
                }
                this.model = value;
            }
        }
        public DateTime ProductionDate { get; set; }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid applience weight!");
                }
                this.weight = value;
            }
        }
    }
}
