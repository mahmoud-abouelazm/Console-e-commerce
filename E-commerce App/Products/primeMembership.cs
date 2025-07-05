using System;
using E_commerce_App.Models;

namespace E_commerce_App.Products;

public class PrimeMembership : Product
{
    public PrimeMembership(double price, int quantity) : base(nameof(PrimeMembership), price, quantity)
    {
        
    }
}
