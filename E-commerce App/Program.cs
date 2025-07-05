using E_commerce_App.Interface;
using E_commerce_App.Models;
using E_commerce_App.Products;

namespace Ecommerce
{
    public static class App
    {
        public static int Main()
        {
            // The expired product is removed from cart and the customer can buy the rest of the items
            Customer Mahmoud = new("Mahmoud Reda", "Cairo - Egypt", 100000);
            Customer Mohammed = new("Mohmmed Hossam", "Alex - Egypt", 1000);
            Customer Ali = new("Ali Gamal", "Tanta - Egypt", 1000);

            Biscuits biscuits = new(10, 100, 15, DateTime.Now.AddMonths(12));
            Cheese cheese = new(50, 50, 100, DateTime.Now.AddMonths(-12));
            GiftCard giftCard = new(100, 100,DateTime.Now.AddMonths(12));
            Mobile mobile = new(10000, 20 , 200);
            PrimeMembership primeMembership = new(100, 100);
            TV tV = new(5000, 20 , 10000);

            // First test ( success - with shipping )
            Mahmoud.cart.Add(biscuits, 10);
            Mahmoud.cart.Add(mobile, 5);
            Mahmoud.cart.Add(tV, 2);
            Mahmoud.cart.Add(primeMembership, 10);
            Checkout(Mahmoud);

            // Second test ( success - without shipping )
            Mohammed.cart.Add(giftCard, 1);
            Mohammed.cart.Add(primeMembership, 1);
            Checkout(Mohammed);

            // Third test (fail - quantity limit + empty cart)
            Mohammed.cart.Add(mobile, 50);
            Checkout(Mohammed);

            //Forth test (fail - balance insufficient)
            Ali.cart.Add(mobile, 1);
            Checkout(Ali);

            // Fifth test ( fail - expired product -cheese- + empty cart)
            Ali.cart.Add(cheese, 2);
            Checkout(Ali);
            return 0;
        }





        public static void Checkout(Customer customer)
        {
            Cart cart = customer.cart;
            customer.cart = new(); // the cart should be erased after checkout 
            bool containShippableItems = cart.shippables.Count() > 0;
            double total = cart.products.Sum(c => c.Value * c.Key.price);
            if (cart.products.Count() == 0)
            {
                System.Console.WriteLine($"Sorry {customer.name}, Your cart is empty");
                System.Console.WriteLine("".PadLeft(20, '-'));
                return;
            }
            if (total > customer.balance)
            {
                System.Console.WriteLine($"Sorry {customer.name}, Your balance is less than Cart total");
                System.Console.WriteLine("".PadLeft(20, '-'));
                return;
            }
            foreach (var product in cart.products)
            {
                product.Key.quantity -= product.Value;
            }

            if (containShippableItems)
            {
                ShippingService(cart.shippables, customer.address);
            }

            CheckoutReceipt(cart.products, containShippableItems ? 20 : 0, customer);
            System.Console.WriteLine($"".PadRight(30, '-'));
            System.Console.WriteLine("");
            
        }
        public static void ShippingService(Dictionary<IShippable, int> shippables , string address)
        {
            System.Console.WriteLine("** Shipment notice **");
            System.Console.WriteLine($"** Products will be shipped to {address} **");
            double totalWeight = 0;
            System.Console.Write($"Quantity/Product".PadRight(20, ' '));
            System.Console.WriteLine("Weight");
            foreach (var item in shippables)
            {
                double itemWaight =  item.Key.GetWeight(item.Value);
                totalWeight += itemWaight;
                System.Console.Write($"{item.Value}x {item.Key.GetName()}".PadRight(20, ' '));
                System.Console.WriteLine(convertWeightUnit(itemWaight));
            }
            System.Console.WriteLine($"Total package weight {convertWeightUnit(totalWeight)}");
            System.Console.WriteLine("");
        }
        public static string convertWeightUnit(double weight)
        {
            return weight < 1000 ? $"{weight}g" : $"{weight / 1000d}kg";
        }

        public static void CheckoutReceipt(Dictionary<Product, int> products, double Shipment , Customer customer)
        {
            System.Console.WriteLine("** Checkout receipt **");
            double totalCost = 0;
            System.Console.Write($"Quantity/Product".PadRight(20, ' '));
            System.Console.WriteLine("Sub total");
            foreach (var item in products)
            {
                double itemSubTotal = item.Value * item.Key.price;
                totalCost += itemSubTotal;
                System.Console.Write($"{item.Value}x {item.Key.name}".PadRight(20, ' '));
                System.Console.WriteLine(itemSubTotal);
            }
            System.Console.WriteLine($"".PadRight(30, '-'));

            System.Console.WriteLine($"Subtotal".PadRight(20, ' ')+$"{totalCost}");

            System.Console.WriteLine($"Shipping".PadRight(20, ' ')+$"{Shipment}");

            System.Console.WriteLine($"Amount".PadRight(20, ' ')+$"{Shipment + totalCost}");

            customer.balance -= Shipment + totalCost;

            System.Console.WriteLine($"Current balance".PadRight(20, ' ')+$"{customer.balance}");
            System.Console.WriteLine($"Thank you for choosing us");
        }
    }
}