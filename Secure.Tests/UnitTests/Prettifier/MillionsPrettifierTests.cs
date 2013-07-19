using NUnit.Framework;
using Secure.Core.Prettifier;

namespace Secure.Tests.UnitTests.Prettifier
{
    [TestFixture]
    public class MillionsPrettifierTests
    {

        // instantiate the _handler to be used for prettifying Million numbers
        private readonly IPrettificationHandler _handler;
        public MillionsPrettifierTests()
        {
          _handler = new MillionsPrettifier();  
        }


        [Test]
        public void OneMillionShouldBeHandledByThisPrettifier()
        {
            // setup
            // 1,000,000
            const double numberToPrettify = 1000000;

            // the test
            bool shouldBeHandledByThisPrettifier = _handler.ShouldHandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(true, shouldBeHandledByThisPrettifier);
        }


        [Test]
        public void OneBillionShouldNotBeHandledByThisPrettifier()
        {
            // setup
            // 1,000,000,000
            const double numberToPrettify = 1000000000;

            // the test
            bool shouldBeHandledByThisPrettifier = _handler.ShouldHandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(false, shouldBeHandledByThisPrettifier);
        }


        [Test]
        public void MillionNumberWillMatchExpectedResult()
        {
            // setup
            const double numberToPrettify = 2500000.34;
            const string expectedResult = "2.5 M";

            // the test
            string result = _handler.HandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(expectedResult, result);
        }
    }
}
