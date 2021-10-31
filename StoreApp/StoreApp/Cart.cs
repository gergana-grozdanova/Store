using StoreApp.Products;
using StoreApp.Products.Perishable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp
{
    class Cart
    {
        private string[] WORK_DAYS = {"Monday","Tuesday","Wednesday","Thursday","Friday" };
        private string[] WEEKEND = {"Saturday","Sunday" };
        public Cart(Store store)
        {
            this.Store = store;
            this.Products = new Dictionary<string, double>();
        }
        public Store Store { get; set; }
        public Dictionary<string,double> Products { get; set; }

        public void AddProductToCart(string productName,double quantity)
        {
            this.Products[productName] = quantity;
        }

        public decimal GetDiscountSum()
        {
            decimal discountSum = 0;
            foreach (var item in this.Products)
            {
                IProduct currProduct = Store.Products.FirstOrDefault(p => p.Name == item.Key);
                IsValidProduct(currProduct);

                double discount = 0;
                string productType = currProduct.GetType().Name.ToString();
                discount = GetDiscount(currProduct, discount, productType);

                if (discount > 0)
                {
                    discountSum+= ((decimal)item.Value * currProduct.Price)*(decimal)discount / 100m;    
                }
            }
            return discountSum;
        }

        public decimal GetSubtotal()
        {
            decimal subtotal = 0;
            foreach (var item in this.Products)
            {
                IProduct currProduct = Store.Products.FirstOrDefault(p => p.Name == item.Key);
                IsValidProduct(currProduct);

                subtotal += currProduct.Price*(decimal)item.Value;
            }
            return subtotal;
        }

        private static void IsValidProduct(IProduct currProduct)
        {
            if (currProduct == null)
            {
                throw new ArgumentException("There is no such a product in the store!");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Products)
            {
                IProduct currProduct = Store.Products.FirstOrDefault(p => p.Name == item.Key);
                IsValidProduct(currProduct);

                sb.AppendLine($"{currProduct.Name} {currProduct.Brand}");
                sb.AppendLine($"{item.Value} x {currProduct.Price} = {(decimal)item.Value * currProduct.Price}");
                double discount = 0;
                string productType = currProduct.GetType().Name.ToString();
                discount = GetDiscount(currProduct, discount, productType);

                if (discount > 0)
                {
                    sb.AppendLine($"#discount {discount}% {((decimal)item.Value * currProduct.Price) * (decimal)discount / 100m}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        private double GetDiscount(IProduct currProduct, double discount, string productType)
        {
            if (productType == "Beverage")
            {
                Beverage castedProduct = currProduct as Beverage;
                discount = PerishableDiscount(castedProduct);
            }
            else if (productType == "Food")
            {
                Food castedProduct = currProduct as Food;
                discount = PerishableDiscount(castedProduct);
            }
            else if (productType == "Clothes" && this.WORK_DAYS.Contains(DateTime.Now.DayOfWeek.ToString()))
            {
                discount = 10;
            }
            else if (productType == "Appliance" && this.WEEKEND.Contains(DateTime.Now.DayOfWeek.ToString()) && currProduct.Price > 999)
            {
                discount = 50;
            }

            return discount;
        }

        private static double PerishableDiscount( IPerishable castedProduct)
        {
            double discount = 0;
            double daysTillExpiration = (castedProduct.ExpirationDate - DateTime.Now).TotalDays;
            if (castedProduct.ExpirationDate == DateTime.Now)
            {
                discount = 50;
            }
            else if (daysTillExpiration <= 5 && daysTillExpiration > 1)
            {
                discount = 10;
            }

            return discount;
        }
    }
}






//for (int i = 0; i < this.Products.Count; i++)
//{
//    IProduct currProduct = this.Products[i];
//    sb.AppendLine(currProduct.GetType().Name.ToString());
//    if (currProduct.GetType().Name.ToString() == "Clothes")
//    {

//    }
//    else if (true)
//    {

//    }

//    sb.AppendLine($"{currProduct.Name} {currProduct.Brand}");
//     sb.AppendLine($"{product.Value} x {product.Key.Price} = {product.Value*product.Key.Price}");
//}

//Dictionary<IProduct, int> productsCount = new Dictionary<IProduct, int>();

//foreach (var product in Products)
//{
//    if (!productsCount.ContainsKey(product))
//    {
//        productsCount[product] = 0;
//    }
//    productsCount[product]++;
//}

//foreach (var product in productsCount)
//{
//    sb.AppendLine($"{product.Key.Name} {product.Key.Brand}");
//    sb.AppendLine($"{product.Value} x {product.Key.Price} = {product.Value*product.Key.Price}");


//    if (product.GetType().ToString() == "Clothes")
//    {
//        product = (Clothes)product;
//        (Clothes)product.Key.ExpirationDate;
//    }
//}