using System;
using E_commerce_App.Models;

namespace E_commerce_App.Products;

public class GiftCard : ExpirableProduct
{
    public GiftCard(double price, int quantity) : base(nameof(GiftCard), price, quantity)
    {

    }
}
