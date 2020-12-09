using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    class LockHelper
    {
        decimal balance;

        public void Withdraw(decimal amount)
        {
            lock (this)
            {
                if (amount > balance)
                {
                    throw new Exception("Insufficient funds");
                }
                balance -= amount;
            }
        }
    }
}
