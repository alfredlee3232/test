using System;

namespace BankApplication
{
    public class Bank
    {
        private decimal balance;

        public Bank()
        {
            balance = 0;
        }

        // Method to deposit money into the bank account
        public void Deposit()
        {
            decimal amount = PromptForAmount("Enter the amount to deposit or enter 0 to cancel: ");
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Successfully deposited ${amount:F2}. Your new balance is ${balance:F2}.");
            }
            else
            {
                Console.WriteLine("Deposit canceled.");
            }
        }

        // Method to withdraw money from the bank account
        public void Withdraw()
        {
            decimal amount = PromptForAmount("Enter the amount to withdraw or enter 0 to cancel: ");
            if (amount > 0)
            {
                if (amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine($"Successfully withdrew ${amount:F2}. Your new balance is ${balance:F2}.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Withdrawal canceled.");
            }
        }

        // Method to view the current bank balance
        public void ViewBalance()
        {
            Console.WriteLine($"Current balance: ${balance:F2}");
        }

        // Method to prompt for an amount with error handling and cancellation option
        private decimal PromptForAmount(string message)
        {
            int attemptCount = 0;
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    if (amount >= 0)
                    {
                        return amount;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a non-negative amount.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric amount.");
                }

                attemptCount++;
                if (attemptCount >= 3)  // Allow 3 attempts before offering an exit option
                {
                    Console.WriteLine("Multiple invalid inputs. Enter '0' to cancel or any key to try again.");
                    if (Console.ReadLine() == "0")
                    {
                        return 0;  // Assume 0 as a cancellation signal
                    }
                    attemptCount = 0;  // Reset the attempt counter after a decision
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Bank myBank = new Bank();
            bool continueRunning = true;

            Console.WriteLine("Welcome to ABC Bank");

            while (continueRunning)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1: View Balance");
                Console.WriteLine("2: Deposit");
                Console.WriteLine("3: Withdraw");
                Console.WriteLine("4: Quit");
                Console.Write("Enter your choice: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        myBank.ViewBalance();
                        break;
                    case "2":
                        myBank.Deposit();
                        break;
                    case "3":
                        myBank.Withdraw();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using ABC Bank. Goodbye!");
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}

