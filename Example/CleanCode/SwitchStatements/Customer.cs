
using System;

namespace CleanCode.SwitchStatements
{
    public abstract class Customer
    {
        public abstract MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage);
    }

    public enum CustomerType
    {
        PayAsYouGo = 1,
        Unlimited
    }
}
