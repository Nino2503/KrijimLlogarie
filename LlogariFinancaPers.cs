using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        FinanceManager financeManager = new FinanceManager();
        financeManager.Start();
    }
}
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public class Income
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
public class Expense
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
public class FinanceManager
{
    private User user;
    private List<Income> incomes;
    private List<Expense> expenses; 
    public FinanceManager()
    {
        incomes = new List<Income>();
        expenses = new List<Expense>();
    }
    public void Start()
    {
        Console.WriteLine("Krijoni llogarinë tuaj");
        Console.Write("Emri i përdoruesit: ");
        string username = Console.ReadLine();
        Console.Write("Fjalëkalimi: ");
        string password = Console.ReadLine();
        user = new User { Username = username, Password = password };
        Console.WriteLine("Llogaria u krijua me sukses!");
        while (true)
        {
            Console.WriteLine("\nMenaxhimi  i financave personale");
            Console.WriteLine("1. Shto të ardhura");
            Console.WriteLine("2. Shto shpenzime");
            Console.WriteLine("3. Shiko bilancin");
            Console.WriteLine("4. Dil");
            Console.Write("Zgjidh një opsion: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddIncome();
                    break;
                case "2":
                    AddExpense();
                    break;
                case "3":
                    ShowBalance();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Zgjidhni një opsion të vlefshëm.");
                    break;
            }
        }
    }
    private void AddIncome()
    {
        Console.WriteLine("Shkruani shumën e të ardhurave: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Jepni përshkrimin: ");
        string description = Console.ReadLine();
        incomes.Add(new Income { Amount = amount, Description = description });
        Console.WriteLine("Të ardhurat u shtuan me sukses!");
    }
    private void AddExpense()
    {
        Console.WriteLine("Shkruani shumën e shpenzimeve: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Jepni përshkrimin: ");
        string description = Console.ReadLine();
        expenses.Add(new Expense { Amount = amount, Description = description });
        Console.WriteLine("Shpenzimet u shtuan me sukses!");
    }
    private void ShowBalance()
    {
        decimal totalIncome = 0;
        decimal totalExpense = 0;
        foreach (var income in incomes)
        {
            totalIncome += income.Amount;
        }
        foreach (var expense in expenses)
        {
            totalExpense += expense.Amount;
        }
        decimal balance = totalIncome - totalExpense;
        Console.WriteLine($"Totali i të ardhurave: {totalIncome}");
        Console.WriteLine($"Totali i shpenzimeve: {totalExpense}");
        Console.WriteLine($"Bilanci: {balance}");
    }
}
