using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    public class ProfilePaymentcs : IPaymentSystem
    {
        private string profile;
        private string proId;

        public ProfilePaymentcs(string profile, string proId)
        {
            this.profile = profile;
            this.proId = proId;
        }

        public PaymentResult Charge(decimal amount)
        {
            var res = PaymentGateway.ChargeProfile(amount, profile, proId, out string error);

            return new PaymentResult { IsSuccessful = res, ErrorMessage = error };
        }
    }
}
