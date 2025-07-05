# E-commerce Console Application

A C# console application demonstrating Object-Oriented Programming principles with an e-commerce system that handles different types of products, shopping carts, and checkout processes.


### Prerequisites

- **.NET 8.0 SDK** or later
- **Git** for cloning the repository
- **Visual Studio 2022** or **Visual Studio Code** (recommended)

### Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/mahmoud-abouelazm/Console-e-commerce.git
   cd Console-e-commerce
   ```

2. **Navigate to the project directory**
   ```bash
   cd "E-commerce App"
   ```

3. **Build and run the application**
   ```bash
   dotnet build
   dotnet run
   ```


##  Test Cases & Outputs

The application includes 5 comprehensive test cases demonstrating different scenarios:

### **Test Case 1: Successful Checkout with Shipping**
**Scenario**: Customer with sufficient balance purchases shippable and non-shippable items
```csharp
Mahmoud.cart.Add(biscuits, 10);
Mahmoud.cart.Add(mobile, 5);
Mahmoud.cart.Add(tV, 2);
Mahmoud.cart.Add(primeMembership, 10);
```

**Output**:
```
** Shipment notice **
** Products will be shipped to Cairo - Egypt **
Quantity/Product    Weight
10x Biscuits        150g      
5x Mobile           1kg       
2x TV               20kg      
Total package weight 21.15kg  

** Checkout receipt **        
Quantity/Product    Sub total 
10x Biscuits        100       
5x Mobile           50000     
2x TV               10000     
10x PrimeMembership 1000      
------------------------------
Subtotal            61100
Shipping            20
Amount              61120
Current balance     38880
Thank you for choosing us
------------------------------
```

### **Test Case 2: Successful Checkout without Shipping**
**Scenario**: Customer purchases only digital/non-shippable items
```csharp
Mohammed.cart.Add(giftCard, 10);
Mohammed.cart.Add(primeMembership, 10);
```

**Output**:
```
The wanted item is expired
** Checkout receipt **
Quantity/Product    Sub total
10x PrimeMembership 1000
------------------------------
Subtotal            1000
Shipping            0
Amount              1000
Current balance     0
Thank you for choosing us
------------------------------
```

### **Test Case 3: Quantity Limit Exceeded**
**Scenario**: Customer tries to purchase more items than available in stock
```csharp
Mohammed.cart.Add(mobile, 50);
```

**Output**:
```
The wanted quantity of Mobile not available
Sorry Mohmmed Hossam, Your cart is empty
--------------------
```

### **Test Case 4: Insufficient Balance**
**Scenario**: Customer doesn't have enough balance for the purchase
```csharp
Ali.cart.Add(mobile, 1);
```

**Output**:
```
Sorry Ali Gamal, Your balance is less than Cart total
--------------------
```

### **Test Case 5: Expired Product**
**Scenario**: Customer tries to purchase an expired product
```csharp
Ali.cart.Add(cheese, 2);
```

**Output**:
```
The wanted item is expired
Sorry Ali Gamal, Your cart is empty
--------------------
```
