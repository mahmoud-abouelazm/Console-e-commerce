using System;
using System.Runtime.InteropServices;
using E_commerce_App.Interface;

namespace E_commerce_App.Models;

public class Cart
{
    public Dictionary<Product, int> products = new();
    // I used dictionary instead of list because user could add items several times 
    public Dictionary<IShippable, int> shippables = new();
    public void Add(dynamic item, int quantity)
    {

        if (ValidateItem(item , quantity, out string errorMessage))
        {
            if (item is IShippable)
            {
                shippables[item] = products[item];
                if (shippables[item] == 0) shippables.Remove(item);
            }
        }
        else
        {
            Console.WriteLine(errorMessage);
        }
    }
    public bool ValidateItem(Product item , int quantity, out string message)
    {
        products[item] = products.ContainsKey(item) ? products[item] + quantity : quantity;
        message = null;
        if (item.IsValid(out string Message, products[item]))
        {
            return true;
        }
        products[item] -= quantity; // remove it from cart
        if (products[item] == 0) products.Remove(item);
        message = Message;
        return false;
    }
}
