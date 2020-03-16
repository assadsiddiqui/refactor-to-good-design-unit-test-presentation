using System;

namespace PaymentSystem
{
    public class Payment
    {
        public bool Charge(decimal amount, string paymentType, string profile, string paymentProfileId, 
            string ccNumber, string expDate, string cvv, out string errorMessage)
        {
            string response;
            errorMessage = string.Empty;
            // Do some validations

            if (paymentType == "CC")
            {
                var charged = PaymentGateway.ChargeCC(amount, ccNumber, expDate, cvv, out response);

                if (charged)
                {
                    SuccessfulAuthorizationProcess();
                    return true;
                }
                else
                {
                    UnSuccessfulAuthorizationProcess();
                    errorMessage = string.Format("Error occured: {0}", response);
                    return false;
                }
            }
            else if (paymentType == "SavedCC")
            {
                var charged = PaymentGateway.ChargeProfile(amount, profile, paymentProfileId, out response);

                if (charged)
                {
                    SuccessfulAuthorizationProcess();
                    return true;
                }
                else
                {
                    UnSuccessfulAuthorizationProcess();
                    errorMessage = string.Format("Error occured: {0}", response);
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Unknown Type");
            }
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
