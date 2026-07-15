using System.Collections.Generic;

public class Bank {
	private List<Account> accounts;
	private static int latestAccount;

    Bank() { /*A new bank is defined with a list of bank accounts and a value that keeps track of the account number of the 
			 most recently added account*/
        this.accounts = new List<Account>();
        Bank.latestAccount = -1; 
    }
    
    public int login() {
        /*This method should ask the user to give their account number and password, returning the account number if they match, 
        or returning -1 if not/you can access a list element (account) using an index e.g.accounts[accountNo].setBalance*/
        System.Console.Write("Enter your account number: ");
        int accountNumberEntry = int.Parse(System.Console.ReadLine());
        System.Console.Write("Enter your password: ");
        string passwordEntry = System.Console.ReadLine();
    }

    public void deposit(int number) {
        /*This method should ask the user how much money they want to deposit into their account, and correctly update the 
        balance of their account*/
        System.Console.Write("How much money do you want to deposit into your account? ");
        number = int.Parse(System.Console.ReadLine());
        double currentBalance = accounts[latestAccount].getBalance();
        accounts[latestAccount].setBalance(currentBalance + number);
    }
    
    public void withdraw(int number) {
        /*This method should ask the user how much money they want to withdraw from their account, and correctly update 
        the balance of their account*/
        System.Console.Write("How much money do you want to withdraw from your account? ");
        number = int.Parse(System.Console.ReadLine());
        double currentBalance = accounts[latestAccount].getBalance();
        accounts[latestAccount].setBalance(currentBalance - number);
    }
    
    public void checkBalance(int number) {
        //This method should display a message telling the user how much money is in their account
        double currentBalance = accounts[latestAccount].getBalance();
        System.Console.WriteLine("Your current balance is: " + currentBalance);
    }
    
    public void addAccount() {
        /*This method should create a new account with an account number 1 larger than the account number or the last account 
        created, a password given by the user, and a balance of 0. The account should be added to the bank's list of accounts*/
        
        System.Console.WriteLine("Create a new password for your account: ");
        string givenPassword = System.Console.ReadLine();
        int newAccountNumber = accounts[latestAccount].getNumber() + 1;
        Account newAccount = new Account(newAccountNumber, givenPassword, 0);
        accounts.Add(newAccount);
    }
}