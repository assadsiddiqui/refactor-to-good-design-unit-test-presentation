using System.Diagnostics.CodeAnalysis;

namespace PaymentSystem
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// This is an external class.
    /// </summary>
    public class PaymentGateway
    {

        public static bool ChargeCC(decimal amount, string ccNumber, string expDate, string cvv, out string response)
        {
            // do something
            if (string.IsNullOrEmpty(cvv) || cvv == "900" || amount >= 100000)
            {
                if (cvv == "900")
                    response = "invalid pin 900";
                else
                    response = "Charge declined";

                return false;
            }

            response = "Charge accepted";
            return true;
        }

        public static bool ChargeProfile(decimal amount, string profileId, string paymentProfileId, out string response)
        {
            // do something
            if (string.IsNullOrEmpty(profileId) || profileId == "999999")
            {
                response = "Charge declined";
                return false;
            }

            response = "Charge accepted";
            return true;

        }
        public static bool ChargePaypal(decimal amount, string email, string password, out string response)
        {
            if (email == "a@c.com" && password == "password22")
            {
                response = "Charge accepted";
                return true;
            }

            response = "Charge declined";
            return false;
        }
    }
}
