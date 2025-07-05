using System;
using E_commerce_App.Interface;

namespace E_commerce_App.Models;

public class ShippableExpirableProduct : Product, IShippable, IExpirable
{
    public ShippableExpirableProduct(string name, double price, int quantity, double weightInGrams, DateTime expiryDate) : base(name, price, quantity)
    {
        this.weightInGrams = weightInGrams;
        this.expiryDate = expiryDate;
    }

    public double weightInGrams { get ; set; }
    public DateTime expiryDate { get; set; }

    public string GetName() => this.name;

    public override bool IsValid(out string message, int buyQuantity)
    {
        message = null;
        if (quantity < buyQuantity)
        {
            message = $"The wanted quantity of {name} not available";
            return false;
        }
        if (expiryDate < DateTime.Now)
        {
            message = "The wanted item is expired";
            return false;
        }
        return true;
    }
}
