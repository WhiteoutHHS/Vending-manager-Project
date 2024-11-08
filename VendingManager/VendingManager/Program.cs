using VendingManagerProject;

class Program
{
    static void Main(string[] args)
    {
        var vendingManager = new VendingManager();

        var vendingMachine1 = new VendingMachine();
        vendingManager.AddVendingMachine(vendingMachine1);

        vendingMachine1.ShowAvailableDrinks();
        vendingMachine1.InsertCoin(2.00m);
        vendingMachine1.SelectDrink("кока-кола");

    }
}
