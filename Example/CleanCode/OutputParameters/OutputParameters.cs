using CleanCode.Comments;
using System;
using System.Collections.Generic;
using CleanCode.OutputParameters;

namespace CleanCode.OutputParameters
{
    public class GetCustomersResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
public class OutputParameters
{
    public void DisplayCustomers()
    {
        //const int pageIndex = 1;
        //var result = GetCustomers(pageIndex);

        var result = GetCustomers(pageIndex: 1);


        Console.WriteLine("Total customers: " + result.TotalCount);
        foreach (var c in result.Customers)
            Console.WriteLine(c);
    }

    public GetCustomersResult GetCustomers(int pageIndex)
    {
        var totalCount = 100;
        return new GetCustomersResult()
        {
            TotalCount = totalCount,
            Customers = new List<Customer>()
        };
    }
}
