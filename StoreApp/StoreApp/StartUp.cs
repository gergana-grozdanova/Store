using StoreApp.Products;
using StoreApp.Products.Perishable;
using System;

namespace StoreApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Food food = new Food("apples","BrandA",1.5m, new DateTime(2021,6,14));
            Beverage beverage = new Beverage("milk", "BrandM",0.99m,new DateTime(2022,2,2));
            Clothes clothes = new Clothes("T-shirt","BrandM",15.99m,"M","violet");
            Appliance appliance = new Appliance("laptop","BrandL",2345m,"ModelM",new DateTime(2021,3,3),1.125);

            Store store = new Store();
            store.AddProductToStore(food);
            store.AddProductToStore(clothes);
            store.AddProductToStore(beverage);
            store.AddProductToStore(appliance);

            Cart cart = new Cart(store);
            cart.AddProductToCart("milk", 3);
            cart.AddProductToCart("laptop", 2);

            Cashier cashier = new Cashier();
            cashier.PrintReceip(cart, DateTime.Now);
        }
    }
}
