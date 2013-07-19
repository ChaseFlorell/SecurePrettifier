namespace Secure.Core.Prettifier
{
    public abstract class PrettificationHandler : IPrettificationHandler
    {

        protected PrettificationHandler Successor;

        // abstract methods are only used in the concrete implementation
        public abstract string HandleRequest(double numberToPrettify);
        public abstract bool ShouldHandleRequest(double numberToPrettify);

        // Set the successor to the Chain of Responsibility (CoR)
        public PrettificationHandler SetSuccessor(PrettificationHandler successor)
        {
            Successor = successor;
            return this;
        }


        // Send back the prettified string
        public string GetResult(double numberToPrettify)
        {
            // if the prettifier should handle the request, 
            // execute the 'PrettifyNumber` method and return the result, 
            // otherwise re-run this method on the successor in the Chain.
            return ShouldHandleRequest(numberToPrettify) ? HandleRequest(numberToPrettify) : Successor.GetResult(numberToPrettify);
        }

        public class Number
        {
            // I originally wanted to use enum, but `int` doesn't go high enough.
            public static double Million {get      { return 1000000; }}
            public static double Billion {get      { return 1000000000; }}
            public static double Trillion { get    { return 1000000000000; }}
            public static double Quadrillion { get { return 1000000000000000; } }
        }
    }
}
