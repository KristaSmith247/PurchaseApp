/* PurchaseApp.cs
 * Author: Krista Smith
 * Date: 9.30.23
 * Description: The PurchaseApp.cs will test a Purchase object by
 * computing the total due for purchases, sales tax and shipping charges.
 */

using static System.Console;

namespace PurchaseApp
{
    public class Purchases
    {
        static void Main(string[] args)
        {
            char anotherItem = 'N'; // sentinel value initialized to N
            string inValue;     // value to parse input
            decimal itemPrice = 0;  // input price from user

            Purchase receipt = new Purchase(itemPrice);
            receipt.DisplayInstructions();
            Clear();

            do
            {
                GetItemPrice(out itemPrice); // get purchase amount from user

                receipt.NumberItemsPurchased += 1; // increment number of items
                receipt.PurchaseAmount += itemPrice; // sum purchase prices

                WriteLine("Would you like to enter another item? (Y/N)");
                inValue = ReadLine();
                anotherItem = Convert.ToChar(inValue);
            }
            while ((anotherItem == 'Y') || (anotherItem == 'y'));
            // Once user has entered all values:
            // calculate shipping on total purchase
            receipt.Shipping = receipt.CalculateShipping(receipt.NumberItemsPurchased);
            
            // calculate sales tax on total
            receipt.SalesTax = receipt.CalculateSalesTax(receipt.PurchaseAmount);
            
            // calculate grand total
            receipt.TotalSalePrice = receipt.CalculateTotalPayment(receipt.PurchaseAmount, receipt.Shipping, receipt.SalesTax);
            
            // display receipt
            WriteLine(receipt);

        }

        private static decimal GetItemPrice(out decimal itemPrice)
        {   // ask user for item price
            string input;
            WriteLine("Please enter the price of the item: ");
            input = ReadLine();
            while (decimal.TryParse(input, out itemPrice) == false || itemPrice <= 0)
            {
                // check to make sure user entered a valid input
                WriteLine("You entered an incorrect value. Please enter a non-negative number: ");
                input = ReadLine();
            }
            return itemPrice;
        }
    }
}

//int numberOfItems = 0;  // number of items in purchase
//decimal totalPrice = 0; // total due with sales tax and shipping
// decimal totalTax = 0; // sales tax on purchase


// before changes: to string is the only function in purchase.cs

// things that worked but are probably unneeded: 

// increment item count:
// numberOfItems += 1;
// receipt.NumberItemsPurchased = AddItem(numberOfItems); // add 1 to number of items

//private static int AddItem(int number)
//{
//    // add one for each time the function is called
//    return number++;
//}


//private static decimal CalculateShipping(int number)
//{
//    int numItems = number;
//    decimal shipping;

//    if (numItems < 3)
//    {
//        shipping = 3.50M;
//    }
//    else if (numItems < 7)
//    {
//        shipping = 5.00M;
//    }
//    else if (numItems < 11)
//    {
//        shipping = 7.00M;
//    }
//    else if (numItems < 15)
//    {
//        shipping = 9.00M;
//    }
//    else { shipping = 10.00M; }

//    return shipping;
//}

//public static decimal CalculateSalesTax(decimal totalAmount)
//{

//    return totalAmount * 0.075M;
//}

//receipt.Shipping = receipt.CalculateShipping(receipt.NumberItemsPurchased); // increase shipping price based on number of items

//receipt.TotalSalePrice += itemPrice; // sum grand total
//totalPrice += receipt.TotalSalePrice; // sum grand total
//totalTax = CalculateSalesTax(itemPrice); // calculate sales tax per item
//receipt.SalesTax += totalTax; // sum total tax for entire purchase
//receipt.TotalSalePrice += receipt.PurchaseAmount + receipt.SalesTax;
//WriteLine(receipt);