using NUnit.Framework;
using UnitTest;

namespace UnitTestDemo.Tests
{
    [TestFixture]
    public class BankAccountTest
    {
        [Test]
        public void TestNewBankAccount()
        {
            //AAA - 3 parts of the test method

            //Arrange - prepare the needed objects, variables for tests
           //Act - Execute the test 
           //Assert - Check what the the act has done 

           var bankAccount = new BankAccount(100m);

           //Провери.Че(обекта(баланса на банковата сметка)).EqualsTo(100), "Message" 
           Assert.That(bankAccount.Balance, Is.EqualTo(100m), "Creating new bank account");
        }
    }
}