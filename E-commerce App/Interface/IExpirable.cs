using System;

namespace E_commerce_App.Interface;

public interface IExpirable
{
    public DateTime expiryDate { get; set; }
    public bool IsExpired() => expiryDate < DateTime.Now;
}
