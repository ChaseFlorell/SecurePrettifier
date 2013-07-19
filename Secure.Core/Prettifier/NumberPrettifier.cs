namespace Secure.Core.Prettifier
{
    public class NumberPrettifier : PrettificationHandler
    {
        public override bool ShouldHandleRequest(double numberToPrettify)
        {
            return (numberToPrettify < Number.Million);
        }

        public override string HandleRequest(double numberToPrettify)
        {
            // return the input because the requirements dictate
            // that we NOT alter the input for numbers
            // LESS THAN one Million or GREATER THAN/EQUAL TO one Quadrillion
            return numberToPrettify.ToString();
        }

    }
}
