public class VendingMachine
{
    public string Name { get; set; }
    public Dictionary<string, (decimal Price, int Quantity)> Products { get; set; }
    public bool NeedsRepair { get; set; }
    public decimal TotalSales { get; private set; }

    public VendingMachine(string name)
    {
        Name = name;
        Products = new Dictionary<string, (decimal Price, int Quantity)>();
        NeedsRepair = false;
        TotalSales = 0m;
    }

    public void AddProduct(string productName, decimal price, int quantity)
    {
        Products[productName] = (price, quantity);
    }

    public void RemoveProduct(string productName)
    {
        if (Products.ContainsKey(productName))
        {
            Products.Remove(productName);
        }
    }

    public bool PurchaseProduct(string productName)
    {
        if (Products.ContainsKey(productName) && Products[productName].Quantity > 0)
        {
            var product = Products[productName];
            Products[productName] = (product.Price, product.Quantity - 1);
            TotalSales += product.Price;
            return true;
        }
        else
            return false;
    }

    public void Repair()
    {
        NeedsRepair = false;
    }
}

public class VendingManager
{
    private List<VendingMachine> vendingMachines;

    public VendingManager()
    {
        vendingMachines = new List<VendingMachine>();
    }

    public void AddVendingMachine(VendingMachine machine)
    {
        vendingMachines.Add(machine);
    }

    public void RemoveVendingMachine(string name)
    {
        vendingMachines.RemoveAll(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public decimal GetTotalSales()
    {
        return vendingMachines.Sum(m => m.TotalSales);
    }

    public bool PurchaseFromMachine(string machineName, string productName)
    {
        var machine = vendingMachines.FirstOrDefault(m => m.Name.Equals(machineName, StringComparison.OrdinalIgnoreCase));
        return machine != null && machine.PurchaseProduct(productName);
    }

    public List<string> RepairAllMachines()
    {
        List<string> repairedMachines = new List<string>();

        foreach (var machine in vendingMachines)
        {
            if (machine.NeedsRepair)
            {
                machine.Repair();
                repairedMachines.Add(machine.Name);
            }
        }

        return repairedMachines;
    }
}
class Program
{
    static void Main()
    {
        VendingManager manager = new VendingManager();

        VendingMachine machine1 = new VendingMachine("Snack Machine");
        machine1.AddProduct("Chips", 1.5m, 10);
        machine1.AddProduct("Soda", 1.0m, 5);

        VendingMachine machine2 = new VendingMachine("Drink Machine");
        machine2.AddProduct("Water", 0.5m, 20);

        manager.AddVendingMachine(machine1);
        manager.AddVendingMachine(machine2);

        manager.PurchaseFromMachine("Snack Machine", "Chips");

        Console.WriteLine("Всего продаж" + manager.GetTotalSales());

        machine1.NeedsRepair = true;
        var repairedMachines = manager.RepairAllMachines();

        Console.WriteLine("Отрмонтированные автоматы:" + string.Join(", ", repairedMachines));

        manager.RemoveVendingMachine("Автомат с напитками");

        Console.WriteLine("Всего продаж после удаления: " + manager.GetTotalSales());
    }
}
