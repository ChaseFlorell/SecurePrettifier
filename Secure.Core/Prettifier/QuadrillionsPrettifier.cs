using System;

namespace Secure.Core.Prettifier
{
    public class QuadrillionsPrettifier : PrettificationHandler
    {

        public override bool ShouldHandleRequest(double numberToPrettify)
        {
            // 1000000          = million
            // 1000000000       = billion
            // 1000000000000    = trillion
            // 1000000000000000 = quadrillion
            return numberToPrettify >= 1000000000000000D;
        }

        public override string HandleRequest(double numberToPrettify)
        {
            throw new ArgumentOutOfRangeException("One Quadrillion is too large of a number: '" + numberToPrettify.ToString() + "'");
        }

    }
}
