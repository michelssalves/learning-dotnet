using System;
using System.IO;
using System.Text.Json;
using Bank;

static class Program
{
    static void Main()
    {
       //JsonSerializer
        ILogger fileLogger = new FileLogger("log.txt");
        ILogger consoleLogger = new ConsoleLogger();

        BankAccount account = new BankAccount("João", 100, consoleLogger);
        account.Deposit(50);

        account = new BankAccount("Maria", 200, fileLogger);
        account.Deposit(-10);


        "teste".WriteLine(ConsoleColor.Yellow);
    }

}
static class Extensions
{
    public static void WriteLine(this string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
namespace Bank
{
    public class FileLogger : ILogger
    {
        private readonly string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Log(string message)
        {
            File.AppendAllText(filePath,$"{message}{Environment.NewLine}");
        }
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    public interface ILogger
    {
        void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class BankAccount 
    {
        private string name;
        private readonly ILogger logger;

        public decimal Balance { get; private set; }

        public BankAccount(string name, decimal balance, ILogger logger)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
            throw new ArgumentException("Nome invalido.", nameof(name));  
            }
            if(balance < 0 )
            {
                throw new Exception("Saldo não pode ser negativo");
            }
            this.name  = name;
            Balance = balance;
            this.logger = logger;
        }

        public void Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                logger.Log($"Não é possivel depositar {amount} na conta de {name}");
                return;
            }
            Balance += amount;
            logger.Log($"Depositado {amount} na conta de {name}. Novo saldo: {Balance}");
        }
    }
}