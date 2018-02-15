namespace GRTechTest.steps
{
    internal class SubTotalPage
    {
        public string btnCart = ".//a[@id=\"hlb-view-cart-announce\"]";
        public string getCartItemCount(string itemsCount)
        {
            return $".//span[contains(text(), \"{itemsCount} items\")]";
        }
    }
}