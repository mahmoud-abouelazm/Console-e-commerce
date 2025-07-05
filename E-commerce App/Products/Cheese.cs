using System;
using E_commerce_App.Interface;
using E_commerce_App.Models;

namespace E_commerce_App.Products;

public class Cheese : ShippableExpirableProduct
{
    public Cheese(double price, int quantity, double weightInGrams, DateTime expiryDate) : base(nameof(Cheese), price, quantity, weightInGrams, expiryDate)
    {
        
    }
}
