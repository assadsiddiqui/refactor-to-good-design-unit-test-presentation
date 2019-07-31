using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class CreditCard : IPaymentSystem
    {
        private readonly string expDate;
        private readonly string ccNumber;
        private readonly string cvv;

        public CreditCard(string expDate, string ccNumber, string cvv)
        {
            this.expDate = expDate;
            this.ccNumber = ccNumber;
            this.cvv = cvv;
        }

        public PaymentResult Charge(decimal amount)
        {
            var isSuccess = PaymentGateway.ChargeCC(amount, ccNumber, expDate, cvv, out string errorMessage);

            return new PaymentResult { IsSuccessful = isSuccess, ErrorMessage = errorMessage };
        }
    }
}
