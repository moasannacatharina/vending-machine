namespace vending_machine
{
    public class BankAccount
    { 
        private int _balance;
        
        public int Withdraw(int amount)
        {
            
            if (_balance >= amount)
            {
                _balance -= amount;
                return amount;
            }

            return 0;
        }

        public bool Deposit(int amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            _balance += amount;
            return true;
        }

        public int Balance()
        {
            return _balance;
        }
    }
}