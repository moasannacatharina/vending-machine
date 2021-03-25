namespace vending_machine
{
    public class VendingItem
    {
        public string ProductName { get; set; }
        public int Price;
        public string Id;

        public VendingItem(string Id, string productName, int price)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Id = Id;
        }
    }
}