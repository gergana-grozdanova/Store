using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp
{
    class Cashier
    {
        public Cashier()
        {

        }

        public void PrintReceip(Cart cart,DateTime purchaseDate)
        {
            Console.WriteLine($"Date: {purchaseDate}");
            Console.WriteLine("---Products---");
            Console.WriteLine(cart);
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine($"SUBTOTAL: ${cart.GetSubtotal()}");
            Console.WriteLine($"DISCOUNT: -${cart.GetDiscountSum()}");
            Console.WriteLine($"TOTAL: {cart.GetSubtotal()-cart.GetDiscountSum()}");
        }
    }
}
