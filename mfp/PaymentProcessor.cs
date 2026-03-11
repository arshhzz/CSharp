using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mfp
{
    abstract class Payment
    {
        public float Amount { get; set; }
        public string Currency { get; set; }

        protected Payment (float amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public abstract void ProcessPayment();
    }
    interface IRefundable
    {
        void Refund(float amount);
    }

    interface IAuditing
    {
        void Audit(float Amount);
    }

    class CreditCard : Payment, IRefundable, IAuditing
    {
        public int CardNumber { get; set; }

        public CreditCard(float amount, string currency, int cardNumber) : base(amount, currency)
        {
            CardNumber = cardNumber;
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"We are processing the payment of {Amount}");
        }

        public void Audit(float Amount)
        {
            Console.WriteLine($"Transaction of {Amount} logged for CreditCard");
        }
        public void Refund(float Amount)
        {
            Console.WriteLine($"Processing refund of {Amount} to CardNumber: {CardNumber}");
        }
    }
    class PayPalPayments: Payment, IRefundable, IAuditing
    {
        public string Email { get; set; }

        public PayPalPayments(float Amount, string currency, string email) : base(Amount, currency)
        {
            Email = email;
        }
        public void Audit(float Amount)
        {
            Console.WriteLine($"Transaction of {Amount} logged for PayPal");
        }
        public override void ProcessPayment()
        {
            Console.WriteLine($"We are processing the paypal payment of {Amount}");
        }
        public void Refund(float Amount)
        {
            Console.WriteLine($"Processing refund of {Amount} for : {Email}");
        }
    }
    class CryptoPayments : Payment, IAuditing
    {
        public string WalletAddress { get; set; }

        public CryptoPayments(float Amount, string currency, string walletAddress) : base(Amount, currency)
        {
            WalletAddress = walletAddress;
        }
        public void Audit(float Amount)
        {
            Console.WriteLine($"Transaction of {Amount} logged for CryptoPayments");
        }
        public override void ProcessPayment()
        {
            Console.WriteLine($"We are processing the crypto payment of {Amount}");
        }
    }
    internal class PaymentProcessor
    {
        public PaymentProcessor() {
            List<Payment> paymentType = new List<Payment>();
            CreditCard c1 = new CreditCard(1000, "Dollars", 12123);
            PayPalPayments p1 = new PayPalPayments(2100, "Yen", "p1@gmail.com");
            CryptoPayments cp1 = new CryptoPayments(3200, "Rupees", "axios@2332");

            paymentType.Add(c1);
            paymentType.Add(cp1);
            paymentType.Add(p1);

            foreach(var p in paymentType)
            {
                Console.WriteLine();
                p.ProcessPayment();
                if(p is IAuditing audit)
                {
                    audit.Audit(p.Amount);
                }
                if(p is IRefundable refundable)
                {
                    refundable.Refund(p.Amount);
                }
                else
                {
                    Console.WriteLine($"{p.GetType().Name} doesn't supports Refunds");
                }
            }
        }

    }
}
