using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        public class GetCustomerResult
        {
            public IEnumerable<Customer> Customers { get; set; }
            public int TotalCount { get; set; }
        }
        public void DisplayCustomers()
        {
            var tuple = GetCustomers(pageIndex:1);

            Console.WriteLine("Total customers: " + tuple.TotalCount);
            foreach (var c in tuple.Customers)
                Console.WriteLine(c);
        }

        public GetCustomerResult GetCustomers(int pageIndex)
        {
            var totalCount = 100;
            return new GetCustomerResult {TotalCount = totalCount, Customers = new List<Customer>()};
        }
    }
}
