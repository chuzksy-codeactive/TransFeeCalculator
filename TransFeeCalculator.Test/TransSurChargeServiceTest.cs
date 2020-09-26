using Moq;
using NUnit.Framework;
using TransFeeCalculator.Application.Interfaces;
using TransFeeCalculator.Application.Models;

namespace TransFeeCalculator.Test
{
    public class TransSurChargeServiceTest
    {
        private Mock<ITransSurChargeService> transSurchargeService;

        [SetUp]
        public void Setup()
        {
            transSurchargeService = new Mock<ITransSurChargeService>();
        }

        [Test]
        public void TestDebitTransaction_5000()
        {
            //Arrange
            var dto = new AmountDTO { Amount = 5000 };
            var customerDebit = new CustomerDebitDTO
            {
                Amount = 5000,
                TransferAmount = 4990,
                Charge = 10,
                DebitAmount = 5000
            };

            //Act
            transSurchargeService.Setup(t => t.DebitTransaction(dto)).Returns(customerDebit);
            ITransSurChargeService moq = transSurchargeService.Object;
            var result = moq.DebitTransaction(dto);

            //Assert
            Assert.AreEqual(customerDebit.Amount, result.Amount);
            Assert.AreEqual(customerDebit.TransferAmount, result.TransferAmount);
            Assert.AreEqual(customerDebit.Charge, result.Charge);
            Assert.AreEqual(customerDebit.DebitAmount, result.DebitAmount);
        }

        [Test]
        public void TestDebitTransaction_45000()
        {
            //Arrange
            var customerDebit = new CustomerDebitDTO
            {
                Amount = 45000,
                TransferAmount = 44975,
                Charge = 25,
                DebitAmount = 45000
            };
            var dto = new AmountDTO { Amount = 45000 };

            //Act
            transSurchargeService.Setup(t => t.DebitTransaction(dto)).Returns(customerDebit);
            ITransSurChargeService moq = transSurchargeService.Object;
            var result = moq.DebitTransaction(dto);

            //Assert
            Assert.AreEqual(customerDebit.Amount, result.Amount);
            Assert.AreEqual(customerDebit.TransferAmount, result.TransferAmount);
            Assert.AreEqual(customerDebit.Charge, result.Charge);
            Assert.AreEqual(customerDebit.DebitAmount, result.DebitAmount);
        }

        [Test]
        public void TestDebitTransaction_50030()
        {
            //Arrange
            var dto = new AmountDTO { Amount = 50030 };
            var customerDebit = new CustomerDebitDTO
            {
                Amount = 50030,
                TransferAmount = 49980,
                Charge = 50,
                DebitAmount = 50030
            };

            //Act
            transSurchargeService.Setup(t => t.DebitTransaction(dto)).Returns(customerDebit);
            ITransSurChargeService moq = transSurchargeService.Object;
            var result = moq.DebitTransaction(dto);

            //Assert
            Assert.AreEqual(customerDebit.Amount, result.Amount);
            Assert.AreEqual(customerDebit.TransferAmount, result.TransferAmount);
            Assert.AreEqual(customerDebit.Charge, result.Charge);
            Assert.AreEqual(customerDebit.DebitAmount, result.DebitAmount);
        }
    }
}
