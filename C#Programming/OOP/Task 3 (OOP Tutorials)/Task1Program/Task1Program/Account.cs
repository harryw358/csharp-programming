public class Account {
    private int accountNumber;
    private string accountPassword;
    private double accountBalance;
	
	//A new bank account should be defined with a given account number, password and balance
    public Account (int number, string password, double balance) {
        accountNumber = number;
        accountPassword = password;
        accountBalance = balance;
	}

    public int getNumber() {
        //This method should return the account number of this account
        return accountNumber;
    }
    
    public bool checkPassword(string password) {
        //This method should check if a given password is equal to the password for this account
        if(accountPassword == password)
        {
            return true;
        }
        return false;
    }
       
    public double getBalance() {
        //This method should return the balance of this account
       
        return accountBalance;
    }
    
    public void setBalance(double newBalance) {
        //This method should change the balance of this account to a specified new value
        {

        }
    }
}