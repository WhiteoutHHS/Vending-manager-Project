namespace VendingManagerProject
{
    public class VendingManager
    {
        private List<VendingMachine> _vendingMachines;

        public VendingManager()
        {
            _vendingMachines = new List<VendingMachine>();
        }

        public void AddVendingMachine(VendingMachine vendingMachine)
        {
            _vendingMachines.Add(vendingMachine);
        }

        public void ShowAllAvailableDrinks()
        {
            foreach (var machine in _vendingMachines)
            {
                machine.ShowAvailableDrinks();
            }
        }
    }

}
