using System;
using E_commerce_App.Interface;

namespace E_commerce_App.Models;

public abstract class ExpirableProduct : Product, IExpirable
{
    

    public ExpirableProduct(string name, double price, int quantity, DateTime expiryDate) : base(name, price, quantity)
    {
        this.expiryDate = expiryDate;
    }

    public DateTime expiryDate { get; set; }

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
