using System;
using Secure.Core.Models;
using Secure.Core.Prettifier;

namespace Secure.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Setup the prettifier Chain of Responsibility (CoR)
            var prettifier = new NumberPrettifier()
                .SetSuccessor(new MillionsPrettifier()
                .SetSuccessor(new BillionsPrettifier()
                .SetSuccessor(new TrillionsPrettifier()
                .SetSuccessor(new QuadrillionsPrettifier())))); // This one just throws an exception that the number is too large.

            // The instructions said to use Integer, 
            // However int.MaxValue = 2,147,483,647,
            // And therefore is outside the bounds of the,
            // Prettification input capabilities. 
            // I took the liberty of using double instead of int.
            var numbersToPrettify = new []
                {
                    new NumberForPrettificationModel {ExpectedResult = "1 M", NumberToPrettify = 1000000},
                    new NumberForPrettificationModel {ExpectedResult = "2.5 M", NumberToPrettify = 2500000.34},                    
                    new NumberForPrettificationModel {ExpectedResult = "532", NumberToPrettify = 532},
                    new NumberForPrettificationModel {ExpectedResult = "1.1 B", NumberToPrettify = 1123456789},
                    // trillion was missing from example spec
                    new NumberForPrettificationModel {ExpectedResult = "8.9 T", NumberToPrettify = 8900000000000.3}
                };

            // loop the array and prettify each number within
            foreach (var number in numbersToPrettify)
            {
                var input = number.NumberToPrettify.ToString();
                var expected = number.ExpectedResult;
                var prettified = prettifier.GetResult(number.NumberToPrettify);
                var success = prettified == expected ? "passed" : "failed";

                Console.WriteLine("input: " + input);

                // adding a pass/fail declaration to prove that we're getting the expected result.
                Console.WriteLine("output: " + prettified + " \t" + success);
                
                Console.WriteLine("");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
