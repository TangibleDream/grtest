namespace GRTechTest.steps
{
    internal class ShoppingCartPage
    {
        public string getCartItemCount(string itemsCount)
        {
            return $".//span[contains(text(), \"{itemsCount} items\")]";
        }
        public string getItem(string item)
        {
            return $".//span[contains(text(),\"{item}\")]";
        }
        public string btnDeleteItem(string item)
        {
            return $".//span[contains(text(),\"{item}\")]/../../../../..//span//input[@value=\"Delete\"]";
        }
    }
}