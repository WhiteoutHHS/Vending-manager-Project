namespace VendingManagerProject
{
    public class VendingMachine : AbstractVendingMachine
    {
        private Dictionary<string, DrinkRecipe> _drinkRecipes;
        private decimal _currentAmount;

        public VendingMachine()
        {
            _drinkRecipes = new Dictionary<string, DrinkRecipe>
        {
            { "кока-кола", new DrinkRecipe("кока-кола", 1.50m) },
            { "добрый кола", new DrinkRecipe("добрый кола", 1.50m) },
            { "черноголовка", new DrinkRecipe("черноголовка", 1.00m) }
        };
            _currentAmount = 0;
        }

        public override void InsertCoin(decimal amount)
        {
            _currentAmount += amount;
            Console.WriteLine($"Монет добавлено: {amount:C}. Всего: {_currentAmount:C}");
        }

        public override void SelectDrink(string drinkName)
        {
            if (_drinkRecipes.ContainsKey(drinkName))
            {
                var recipe = _drinkRecipes[drinkName];
                if (_currentAmount >= recipe.Price)
                {
                    DispenseDrink();
                    _currentAmount -= recipe.Price;
                }
                else
                {
                    Console.WriteLine("Недостаточно денег для оплаты");
                }
            }
            else
            {
                Console.WriteLine("Извините,напиток не доступен.");
            }
        }

        public override void DispenseDrink()
        {
            Console.WriteLine("Добавление молока");
        }

        public override void ShowAvailableDrinks()
        {
            Console.WriteLine("Доступные напитки");
            foreach (var recipe in _drinkRecipes.Values)
            {
                Console.WriteLine($"{recipe.Name}: {recipe.Price:C}");
            }
        }
    }

}
