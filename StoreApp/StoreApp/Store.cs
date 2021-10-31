using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    class Store
    {
        public Store()
        {
            this.Products = new List<IProduct>();
        }
        public List<IProduct> Products { get; set; }

        public void AddProductToStore(IProduct product)
        {
            this.Products.Add(product);
        }
    }
}
