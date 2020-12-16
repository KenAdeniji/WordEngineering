using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkbook_ClassLibrary
{
    public class Checkbook
    {
        public decimal AddTransaction
        (
            string transactionType,
            decimal amount
        )
        {
            String exceptionMessage = null;
            switch (transactionType)
            {
                case Check:
                    if (amount > AccountBalance)
                    {
                        exceptionMessage = String.Format
                        (
                            "Insufficient Funds | Transaction Type: {0} | Account Balance: {1} | Amount: {2}",
                            transactionType,
                            AccountBalance,
                            amount
                        );
                        AccountBalance -= 10;

                        ++NumberOfServiceCharges;
                        AmountOfServiceCharges += 10;

                        throw new System.ApplicationException(exceptionMessage);
                    }
                    else
                    {
                        AccountBalance -= amount;

                        ++NumberOfChecks;
                        AmountOfChecks += amount;
                    }
                    break;

                case Deposit:
                    AccountBalance += amount;

                    ++NumberOfDeposits;
                    AmountOfDeposits += amount;
                    break;

                case Interest:
                    AccountBalance += amount;

                    ++NumberOfInterest;
                    AmountOfInterest += amount;
                    break;

                case ServiceCharge:
                    AccountBalance -= amount;

                    ++NumberOfServiceCharges;
                    AmountOfServiceCharges += amount;
         
                    break;
            }
            return AccountBalance;
        }

        public Checkbook()
        {
            AccountBalance = 0;

            AmountOfChecks = 0;
            NumberOfChecks = 0;

            AmountOfDeposits = 0;
            NumberOfDeposits = 0;

            AmountOfInterest = 0;
            NumberOfInterest = 0;

            AmountOfServiceCharges = 0;
            NumberOfServiceCharges = 0;
        }

        public decimal AccountBalance { get; set; }

        public decimal AmountOfChecks { get; set; }
        public int NumberOfChecks { get; set; }

        public decimal AmountOfDeposits { get; set; }
        public int NumberOfDeposits { get; set; }

        public decimal AmountOfInterest { get; set; }
        public int NumberOfInterest { get; set; }

        public decimal AmountOfServiceCharges { get; set; }
        public int NumberOfServiceCharges { get; set; }

        public const string Check = "Check";
        public const string Deposit = "Deposit";
        public const string Interest = "Interest";
        public const string ServiceCharge = "Service Charge";
    }
}
