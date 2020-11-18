using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Robert", beginningBalance);
            //act
            account.Debit(debitAmount);

            //assert
            double actual = account.Balance;
            Assert.AreEqual(expected, account, "Débito não ocorreu corretamente");
        }
    }
}
