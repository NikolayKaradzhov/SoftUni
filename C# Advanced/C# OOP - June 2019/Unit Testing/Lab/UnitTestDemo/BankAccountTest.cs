using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using UnitTest;

namespace UnitTestDemo.Tests
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount bankAccount;
        
        //SetUp executes before every test
        [SetUp]
        public void CreateBankAccount()
        {
            bankAccount = new BankAccount(100m);
        }

        [TearDown]
        public void DestroyBankAccount()
        {
            bankAccount = null;
        }

        [Test]
        public void TestNewBankAccount()
        {
            //AAA - 3 parts of the test method

            //Arrange - Initializes objects and sets the value of the data that is passed to the test case
           //Act - Invokes the test case with the arranged parameters
           //Assert - Verify that the testcase behaves as expected

           //Провери.Че(обекта(баланса на банковата сметка)).EqualsTo(100), "Message" 
           Assert.That(bankAccount.Balance, Is.EqualTo(100m), "Creating new bank account");
        }

        [Test]
        public void TestNewBankAccountWithNegativeBalance()
        {
            //Catch a certain message "Value cannot be less than 0" refers to "Balance" property
            Assert.That(() => new BankAccount(-100), 
                Throws.ArgumentException.With.Message.EqualTo("Balance cannot be less than 0"));
            
        }

        [Test]
        public void TestDeposit()
        {
            CreateBankAccount();

            bankAccount.Deposit(100);

            Assert.That(bankAccount.Balance, Is.EqualTo(200), "Deposit money in bankAccount");
        }

        [Test]
        public void TestDepositWithNegativeSum()
        {
            Assert.That(() => bankAccount.Deposit(-50),
                Throws.ArgumentException.With.Message.EqualTo("Sum cannot be less than 0"));
        }

        [Test]
        public void TestWithdraw()
        {
            var balance = bankAccount.WithDraw(34);

            Assert.That(bankAccount.Balance, Is.EqualTo(balance));
        }

        [Test]
        public void WithdrawMoreMoney()
        {
            Assert.That(() => bankAccount.WithDraw(555),
                Throws.ArgumentException.With.Message.EqualTo("Balance cannot be less than 0"));
        }
    }
}