using System;
namespace E_commerce_App.Models;

public abstract class Product
{
    public string name { get; set; }
    public double price { get; set; }
    public int quantity { get; set; }
    public Product(string name, double price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }
    public virtual bool IsValid(out string message, int buyQuantity)
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
