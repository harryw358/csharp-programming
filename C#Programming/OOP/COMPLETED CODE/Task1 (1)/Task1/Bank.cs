using System;
using System.Collections.Generic;

public class Bank {
    List<Account> ListOfAccounts;
	private static int latestAccount;

    public Bank() {
        this.ListOfAccounts = new List<Account>();
        Bank.latestAccount = -1; 
    }
    
	//1 Mark for returning the account number if the given account number matches the given password
	//1 Mark for returning -1 if the account number isn't found or the given password is not correct
    public int login() {
    	Console.WriteLine("Please enter your account number:");
        String accountNoString = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Please enter the password for the account number " + accountNoString + ":");
        String password = Console.ReadLine();
        Console.WriteLine();
        try {
            int accountNo = Convert.ToInt32(accountNoString);
            for (int i = 0; i <= latestAccount; i++) {
            	Account account = null;
				if (Bank.latestAccount >= 0)
            		account = this.ListOfAccounts[i];
                	if (account.getNumber() == accountNo && account.checkPassword(password))
                		return account.getNumber();
            }
        }
        catch {
        }
        Console.WriteLine("Incorrect account number or password entered. Try again.\n");
        return -1;
    }
    
	//1 Mark for updating the given account's balance if a valid amount is given
	//1 Mark for displaying an error message if an invalid amount is given
    public void deposit(int number) {
    	double amount;
        try {
        	Console.Write("Enter the amount of money you would like to deposit:\n£");
            amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }
        catch {
        	Console.WriteLine("Invalid value given");
            amount = 0;
        }
        this.ListOfAccounts[number].setBalance(this.accounts[number].getBalance() + amount);
    }
    
	//1 Mark for updating the given account's balance if a valid amount is given
	//1 Mark for displaying an error message if an invalid amount is given
	//1 Mark for displaying a message if a higher amount is requested than the account balance contains
    public void withdraw(int number) {
    	double amount;
        try {
        	Console.Write("Enter the amount of money you would like to withdraw:\n£");
            amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
        }
        catch {
            Console.WriteLine("Invalid value given");
            amount = 0;  
        }
        if (amount <= this.accounts[number].getBalance())
            this.ListOfAccounts[number].setBalance(this.accounts[number].getBalance() - amount);
        else
            Console.WriteLine("Your account has insufficient funds to complete this transaction.");
        	Console.WriteLine();
    }
    
	//1 Mark for displaying the account's current balance
    public void checkBalance(int number) {
        Console.WriteLine("Your account currently contains:\n£" + this.accounts[number].getBalance() + "\n");
        Console.WriteLine();
    }
    
	//1 Mark for adding a new account (with accountNumber equal to the value of latestAccount) to the accounts list
	//1 Mark for updating the value of latestAccount
    public void addAccount() {
        Bank.latestAccount++;
        int newNumber = Bank.latestAccount;
        Console.WriteLine("Please enter a password for your new account: ");
        String newPassword = Console.ReadLine();
        Console.WriteLine();
        int newBalance = 0;
        Account account = new Account(newNumber, newPassword, newBalance);
        this.ListOfAccounts.Add(account);
        Console.WriteLine("Your new account has account number " + account.getNumber());
        Console.WriteLine();
    }
}