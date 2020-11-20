using System;

namespace Bank
{
    /// <summary>
    /// Classe que envolve métodos de debit e credit
    /// </summary>
    public class BankAccount
       
    {   //atributos da classe
        private readonly string m_customerName;
        private double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "Debit Amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit Amount is less than zero";

        //construtores da classe
        public BankAccount() { } //BankAccount ba = new BankAccount();
        public BankAccount(string customerName, double balance)

        
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        //propriedades - Encapsulamento
        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }
        //metodos da classe
       /// <summary>
       /// Valor Débitado
       /// </summary>
       /// <param name="amount">Quantidade</param>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }
        /// <summary>
        /// Valor créditado
        /// </summary>
        /// <param name="amount">Quantidade</param>
        public void Credit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }
        public static void Main()
        {
            BankAccount ba = new BankAccount("Robert", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance id ${0}", ba.Balance);
        }
    }
}
