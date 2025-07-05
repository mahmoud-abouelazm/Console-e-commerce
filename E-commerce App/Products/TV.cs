using System;
using E_commerce_App.Models;

namespace E_commerce_App.Products;

public class TV : ShippableProduct
{
    public TV( double price, int quantity, double weight) : base(nameof(TV), price, quantity, weight)
    {
    }
}
