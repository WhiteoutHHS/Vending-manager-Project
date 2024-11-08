namespace VendingManagerProject
{
    public class DrinkRecipe
    {
        public string Name { get; }
        public decimal Price { get; }

        public DrinkRecipe(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

}
