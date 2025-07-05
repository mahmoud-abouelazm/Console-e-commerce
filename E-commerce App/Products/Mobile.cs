using System;
using E_commerce_App.Models;

namespace E_commerce_App.Products;

public class Mobile : ShippableProduct
{
    public Mobile( double price, int quantity, double weight) : base(nameof(Mobile), price, quantity, weight)
    {
    }
}
