using System;

namespace PaymentSystem
{
    public class Payment
    {
        private IPaymentSystem paymentSystem;

        public Payment(IPaymentSystem paymentSystem)
        {
            this.paymentSystem = paymentSystem;
        }

        public bool Charge(decimal amount, out string errorMessage)
        {
            errorMessage = string.Empty;
            // Do some validations

            var result = paymentSystem.Charge(amount);
            if (result.IsSuccessful)
            {
                SuccessfulAuthorizationProcess();
            }
            else
            {
                UnSuccessfulAuthorizationProcess();
                errorMessage = $"Error occurred: {result.ErrorMessage}";
            }

            return result.IsSuccessful;    
        }

        public void SuccessfulAuthorizationProcess()
        {
            // do some code.
        }

        public void UnSuccessfulAuthorizationProcess()
        {
            // do something different
        }

    }


}
