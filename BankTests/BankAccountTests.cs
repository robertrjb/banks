using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTests
{
    //esse atributo � necess�rio em qualuqer classe que tenha teste de unidade
    //para executar no Gerenciador de Teste
    [TestClass]
    public class BankAccountTests
    {
        //para reconhecer no Gerenciador de teste precisa ter o TestMethod
        [TestMethod]
        public void Debit_WithValidAmount_UpdateBalance()
        {
            // Prepara��o
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Robert", beginningBalance);
            //Processo
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "D�bito n�o ocorreu corretamente");
        }

        [TestMethod]
        
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
          
            // Prepara��o
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Robert", beginningBalance);

            // Processo e Verifica��o
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
                
            }
            //para que o teste passe sem falha
            Assert.Fail("The expected exception wasn't thrown.");
        }

        [TestMethod]
        
        public void Credit_ComValidacaoDeSaldo_AtualizacaoDeSaldo()
        {
            //prepara��o
            double begginningBalance = 20.0;
            double creditAmount = 15.15;
            double expected = 35.15;
            BankAccount account = new BankAccount("Robert", begginningBalance);

            //processo
            account.Credit(creditAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Cr�dito n�o ocorreu");

        }

        [TestMethod]
        public void Credit_QuandoDepositoMenorOuIugalAZero_AtualizandoSaldo()
        {
            //prepara��o
            double beginningBalance = 20.0;
            double creditAmount = -10;
            BankAccount account = new BankAccount("Robert", beginningBalance);

            //ACT and ASSERT
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }
    }
}
