using System.Text;

namespace Secure.Core.Prettifier
{
    public class BillionsPrettifier : PrettificationHandler
    {

        public override bool ShouldHandleRequest(double numberToPrettify)
        {
            return numberToPrettify >= Number.Billion && numberToPrettify < Number.Trillion;
        }

        public override string HandleRequest(double numberToPrettify)
        {
            var shortenedNumber = (numberToPrettify / Number.Billion);

            return new StringBuilder()
                .Append(string.Format("{0:0.#}", shortenedNumber))
                .Append(" B").ToString();
        }
    }
}
