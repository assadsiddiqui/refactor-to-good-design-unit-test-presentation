using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PaymentSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class PaymentTest
    {
        private IPaymentSystem paymentSystem;
        private Payment payment;

        [TestInitialize]
        public void Init()
        {
            paymentSystem = Substitute.For<IPaymentSystem>();
            payment = new Payment(paymentSystem);
        }

        [TestMethod]
        public void Payment_Should_Return_True_If_Passed()
        {
            paymentSystem.Charge(Arg.Any<decimal>())
                .Returns(new PaymentResult { IsSuccessful = true });
            var success = payment.Charge((decimal)25.00, out string errorMessage);
            success.Should().BeTrue();
        }

        [TestMethod]
        public void Payment_Should_Return_False_If_Failed()
        {
            paymentSystem.Charge(Arg.Any<decimal>())
                .Returns(new PaymentResult { IsSuccessful = false, ErrorMessage = "Payment Declined" });
            var success = payment.Charge((decimal)25.00, out string errorMessage);
            success.Should().BeFalse();
        }

        [TestMethod]
        public void Payment_Should_Give_Error_Message_On_Failure()
        {
            paymentSystem.Charge(Arg.Any<decimal>())
                .Returns(new PaymentResult { IsSuccessful = false, ErrorMessage = "Payment Declined" });
            var success = payment.Charge((decimal)25.00, out string errorMessage);
            success.Should().BeFalse();

            errorMessage.Should().Be("Error occurred: Payment Declined");
        }

        [TestMethod]
        public void Should_Return_True_On_Charge_CC_Sucessfully()
        {
            var cc = new CreditCard("4561234567894", "0520", "504");
            var charged = cc.Charge((decimal)99999.99);

            charged.IsSuccessful.Should().BeTrue();
        }

        [TestMethod]
        public void Should_Return_False_On_Charge_CC_Unsucessfully()
        {
            var cc = new CreditCard("4561234567894", "0520", null);
            var result = cc.Charge((decimal)99999.99);

            result.IsSuccessful.Should().BeFalse();
            result.ErrorMessage.Should().Be("Charge declined");
        }

        [TestMethod]
        public void Integration_Payment_with_CC_Should_Return_True()
        {
            var cc = new CreditCard("4561234567894", "0520", "504");
            var pay = new Payment(cc);
            var success = pay.Charge((decimal)25.00, out string errorMessage);
            success.Should().BeTrue();
        }


        [TestMethod]
        public void Integration_Payment_with_Profile_Should_Return_True()
        {
            var cc = new ProfilePaymentcs("4561234567894", "Illsi8823748");
            var pay = new Payment(cc);
            var success = pay.Charge((decimal)25.00, out string errorMessage);
            success.Should().BeTrue();
        }
    }
}
