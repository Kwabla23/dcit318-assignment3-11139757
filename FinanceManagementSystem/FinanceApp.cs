namespace Question1_Finance;

public class FinanceApp
{
    private readonly List<Transaction> _transactions = new();

    public void Run()
    {
        var account = new SavingsAccount("SA-001", 1000m);

        var t1 = new Transaction(1, DateTime.Today, 120m, "Groceries");
        var t2 = new Transaction(2, DateTime.Today, 250m, "Utilities");
        var t3 = new Transaction(3, DateTime.Today, 500m, "Entertainment");

        ITransactionProcessor p1 = new MobileMoneyProcessor();
        ITransactionProcessor p2 = new BankTransferProcessor();
        ITransactionProcessor p3 = new CryptoWalletProcessor();

        p1.Process(t1);
        p2.Process(t2);
        p3.Process(t3);

        account.ApplyTransaction(t1);
        account.ApplyTransaction(t2);
        account.ApplyTransaction(t3);

        _transactions.AddRange(new[] { t1, t2, t3 });

        Console.WriteLine("\nAll Transactions:");
        foreach (var tr in _transactions)
        {
            Console.WriteLine($" - #{tr.Id} {tr.Category}: {tr.Amount:C} on {tr.Date:d}");
        }
        Console.WriteLine($"Final Balance: {account.Balance:C}");
    }
}
