using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    interface IPerishable:IProduct
    {
        public DateTime ExpirationDate { get; set; }
    }
}
