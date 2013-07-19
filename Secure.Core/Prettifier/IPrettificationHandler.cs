namespace Secure.Core.Prettifier
{
    public interface IPrettificationHandler
    {
        bool ShouldHandleRequest(double numberToPrettify);
        string HandleRequest(double numberToPrettify);
    }
}
