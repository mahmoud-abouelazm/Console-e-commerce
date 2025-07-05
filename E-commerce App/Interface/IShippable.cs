using System;
using E_commerce_App.Models;

namespace E_commerce_App.Interface;

public interface IShippable
{
    public double weightInGrams { get; set; }
    public string GetName();
    public double GetWeight(int quantity) => weightInGrams*quantity ;
}
