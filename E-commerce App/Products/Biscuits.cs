using System;
using E_commerce_App.Models;

namespace E_commerce_App.Products;

public class Biscuits : ShippableExpirableProduct
{
    public Biscuits( double price, int quantity, double weightInGrams, DateTime expiryDate) : base(nameof(Biscuits), price, quantity, weightInGrams, expiryDate)
    {
    }
}
