namespace Question1_Finance;

public interface ITransactionProcessor
{
    void Process(Transaction transaction);
}

public class BankTransferProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[BankTransfer] Processing {transaction.Amount:C} for '{transaction.Category}' on {transaction.Date:d}.");
    }
}

public class MobileMoneyProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[MobileMoney] Processing {transaction.Amount:C} for '{transaction.Category}' on {transaction.Date:d}.");
    }
}

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[CryptoWallet] Processing {transaction.Amount:C} for '{transaction.Category}' on {transaction.Date:d}.");
    }
}
