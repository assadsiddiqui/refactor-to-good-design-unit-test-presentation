using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class PaymentTest
    {
        private Payment payment;
        [TestInitialize]
        public void Initialize()
        {
            payment = new Payment();
        }

        [TestMethod]
        public void Payment_Should_Return_False_If_Failed()
        {
            var success = payment.Charge((decimal)25.00, "CC", null, null, 
                "4567897485478974", "0520", "900", out string errorMessage);
            success.Should().BeFalse();
        }

        [TestMethod]
        public void Payment_Should_Give_Error_Message_On_Failure()
        {
            var success = payment.Charge((decimal)25.00, "CC", null, null, 
                "4567897485478974", "0520", "900", out string errorMessage);
            success.Should().BeFalse();
            errorMessage.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Payment_Should_Return_True_If_Passed()
        {
            var success = payment.Charge((decimal)25.00, "CC", null, null, 
                "4567897485478974", "0520", "456", out string errorMessage);
            success.Should().BeTrue();
        }

        [ExcludeFromCodeCoverage]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Unknown Type")]
        public void Payment_Should_Throw_Exception_On_Unhandled_Payment_Type()
        {
            var success = payment.Charge((decimal)25.00, "PO", null, null, "4567897485478974", "0520", "456", out string errorMessage);
        }
    }
}
