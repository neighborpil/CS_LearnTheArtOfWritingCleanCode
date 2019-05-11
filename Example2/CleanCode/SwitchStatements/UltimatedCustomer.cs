using System;

namespace CleanCode.SwitchStatements
{
    public class UltimatedCustomer : Customer
    {
        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement();
            statement.TotalCost = 54.90f;

            return statement;
        }
    }
}