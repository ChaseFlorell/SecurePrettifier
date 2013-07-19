using System.Text;

namespace Secure.Core.Prettifier
{
    public class MillionsPrettifier : PrettificationHandler
    {

        public override bool ShouldHandleRequest(double numberToPrettify)
        {
            return numberToPrettify >= Number.Million && numberToPrettify < Number.Billion;
        }

        public override string HandleRequest(double numberToPrettify)
        {
            var shortenedNumber = (numberToPrettify / Number.Million);

            return new StringBuilder()
                .Append(string.Format("{0:0.#}", shortenedNumber))
                .Append(" M").ToString();
        }
    }
}
