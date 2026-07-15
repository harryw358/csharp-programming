public class Account {
	private int accountNumber;
	private string accountPassword;
	private double accountBalance;
	
	//1 Mark for completing constructor with suitable attribute names
    public Account (int number, string password, double balance) {
        this.accountNumber = number;
        this.accountPassword = password;
        this.accountBalance = balance;
	}

	//1 Mark for returning the accountNumber attribute
    public int getNumber() {
        return this.accountNumber;
    }
    
	//1 Mark for correctly returning either true; or false;
    public bool checkPassword(string password) {
        if (string.Equals(password, this.accountPassword))
            return true;
        else
            return false;
    }
    
	//1 Mark for returning the accountBalance (or equivalent) attribute    
    public double getBalance() {
        return this.accountBalance;
    }
    
	//1 Mark for setting the accountBalance (or equivalent) attribute to the value given for newBalance
    public void setBalance(double newBalance) {
        this.accountBalance = newBalance;
    }
}