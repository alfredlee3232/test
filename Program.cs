using System;

public class Bank
{
    private string _username = "Joe.Doe";
    private string _password = "Password123";

    public void StartBanking()
    {
        int attempt = 0;
        bool isAuthenticated = false;

        while (attempt < 3 && !isAuthenticated)
        {
            Console.WriteLine("Welcome to ABC Bank");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Signup");
            Console.WriteLine("3: Quit");
            Console.Write("Select Option: ");
            
            string option = Console.ReadLine();
            
            switch(option)
            {
                case "1":
                    isAuthenticated = Login();
                    if(isAuthenticated)
                    {
                        // If authenticated, navigate to the main screen.
                        NavigateToMainScreen();
                    }
                    else
                    {
                        Console.WriteLine("Invalid email or password");
                        attempt++;
                    }
                    break;
                case "2":
                    // Signup method would go here
                    break;
                case "3":
                    return; // Quit application
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        if (attempt == 3)
        {
            Console.WriteLine("Maximum login attempts exceeded.");
        }
    }

    private bool Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        return username == _username && password == _password;
    }

    private void NavigateToMainScreen()
    {
        // Code to navigate to the main screen after login would go here
        Console.WriteLine("Navigating to the main screen...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        bank.StartBanking();
    }
}

