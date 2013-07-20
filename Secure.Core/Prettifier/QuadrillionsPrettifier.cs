using System;

namespace Secure.Core.Prettifier
{
    public class QuadrillionsPrettifier : PrettificationHandler
    {

        public override bool ShouldHandleRequest(double numberToPrettify)
        {
            return numberToPrettify >= Number.Quadrillion;
        }

        public override string HandleRequest(double numberToPrettify)
        {
            throw new ArgumentOutOfRangeException("One Quadrillion is too large of a number: '" + numberToPrettify.ToString() + "'");
        }

    }
}
