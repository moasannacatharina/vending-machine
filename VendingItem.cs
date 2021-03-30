namespace vending_machine
{
    public class VendingItem
    {
        public string ProductName { get; set; }
        public int Price;

        public VendingItem (string productName, int price)
        {
            this.ProductName = productName;
            this.Price = price;
        }
    }
}