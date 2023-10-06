/* Purchase.cs
 * Author: Krista Smith
 * Date: 9/30/23
 * Description: The class will create a Purchase object and provide a string
 * override to print an object.
 */

namespace PurchaseApp
{
    internal class Purchase
    {
        // accessors and mutators
        public decimal PurchaseAmount { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Shipping { get; set; }
        public decimal TotalSalePrice { get; set; }
        public int NumberItemsPurchased { get; set; }

        // constructors

        public Purchase(decimal price)
        {
            PurchaseAmount = price;
        }

        // functions
        public void DisplayInstructions()
        {
            //  display program instructions
            Console.WriteLine("This application computes the total due for purchases.");
            Console.WriteLine("You may enter any number of purchase amounts.");
            Console.WriteLine("When you have finished, the total due will be displayed with sales tax and shipping charges included.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public decimal CalculateShipping(int numItems)
        {
            // calculate shipping based on number of items in purchase list
            decimal shipping;
            if (numItems < 3)
            {
                shipping = 3.50M;
            }
            else if (numItems < 7)
            {
                shipping = 5.00M;
            }
            else if (numItems < 11)
            {
                shipping = 7.00M;
            }
            else if (numItems < 15)
            {
                shipping = 9.00M;
            }
            else { shipping = 10.00M; }

            return shipping;
        }

        public decimal CalculateSalesTax(decimal totalAmount)
        {
            // calculate sales tax by multiplying total by 7.75%
            return totalAmount * 0.0775M;
        }

        public decimal CalculateTotalPayment(decimal itemPayment, decimal shipPrice, decimal taxes)
        {
            // calculate grand total by adding purchases, shipping, and sales tax
            return itemPayment + shipPrice + taxes;
        }

        public override string ToString()
        { 
            // print the object receipt
            return "-----------------------------------" + "\n\tSales Receipt" +
                "\nTotal Purchases: " + PurchaseAmount.ToString("c").PadLeft(16) +
                "\nSales Tax: " + SalesTax.ToString("c").PadLeft(22) +
                "\nNumber of Items Purchased: " + NumberItemsPurchased.ToString().PadLeft(6)
                + "\nShipping Charge: " + Shipping.ToString("c").PadLeft(16) +
                "\n-----------------------------------" +
                "\nGrand Total: " + TotalSalePrice.ToString("C").PadLeft(20);
        }
    }
}
