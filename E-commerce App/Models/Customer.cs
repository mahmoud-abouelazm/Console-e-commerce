using System;

namespace E_commerce_App.Models;

public class Customer
{
    public string name { get; set; }
    public string address { get; set; }
    public double balance { get; set; }
    public Cart cart = new();
    public Customer(string name, string address, double balance)
    {
        this.name = name;
        this.address = address;
        this.balance = balance;
    }
}
