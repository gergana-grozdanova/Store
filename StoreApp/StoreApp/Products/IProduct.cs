using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    interface IProduct
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}
