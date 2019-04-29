using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Htp.Validation.Client.Validators
{
    public class CustomCreditCardNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            var ccNumber = value as string;
            int sum = 0;
            int n;
            bool alternate = false;
            char[] nx = ccNumber.ToArray();
            for (int i = ccNumber.Length - 1; i >= 0; i--)
            {
                n = int.Parse(nx[i].ToString());

                if (alternate)
                {
                    n *= 2;

                    if (n > 9)
                    {
                        n = (n % 10) + 1;
                    }
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
    }
}
