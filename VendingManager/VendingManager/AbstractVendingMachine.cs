namespace VendingManagerProject
{
    public abstract class AbstractVendingMachine
    {
        public abstract void InsertCoin(decimal amount);
        public abstract void SelectDrink(string drinkName);
        public abstract void DispenseDrink();
        public abstract void ShowAvailableDrinks();
    }

}
