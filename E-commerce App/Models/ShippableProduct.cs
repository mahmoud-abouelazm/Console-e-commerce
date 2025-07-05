using System;
using E_commerce_App.Interface;

namespace E_commerce_App.Models;

public class ShippableProduct : Product, IShippable
{

    public ShippableProduct(string name, double price, int quantity, double weight) : base(name, price, quantity)
    {
        weightInGrams = weight;
    }

    public double weightInGrams { get; set; }

    public string GetName() => name;

    public override bool IsValid(out string message, int buyQuantity)
    {
        message = null;
        if (quantity < buyQuantity)
        {
            message = $"The wanted quantity of {name} not available";
            return false;
        }
        return true;
    }
}
