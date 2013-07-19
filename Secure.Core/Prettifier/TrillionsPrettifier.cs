using System.Text;

namespace Secure.Core.Prettifier
{
    public class TrillionsPrettifier : PrettificationHandler
    {

        public override bool ShouldHandleRequest(double numberToPrettify)
        {
            return numberToPrettify >= Number.Trillion && numberToPrettify < Number.Quadrillion;
        }

        public override string HandleRequest(double numberToPrettify)
        {
            var shortenedNumber = (numberToPrettify/Number.Trillion);

            return new StringBuilder()
                .Append(string.Format("{0:0.#}", shortenedNumber))
                .Append(" T").ToString();
        }

    }
}
