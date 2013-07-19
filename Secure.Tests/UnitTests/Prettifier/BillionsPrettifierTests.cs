using NUnit.Framework;
using Secure.Core.Prettifier;

namespace Secure.Tests.UnitTests.Prettifier
{
    [TestFixture]
    public class BillionsPrettifierTests
    {

        // instantiate the _handler to be used for prettifying Billion numbers
        private readonly IPrettificationHandler _handler;
        public BillionsPrettifierTests() 
        {
            _handler = new BillionsPrettifier();
        }

        [Test]
        public void OneBillionShouldBeHandledByThisPrettifier()
        {
            // setup
            // 1,000,000,000
            const double numberToPrettify = 1000000000;

            // the test
            bool shouldBeHandledByThisPrettifier = _handler.ShouldHandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(true, shouldBeHandledByThisPrettifier);
        }

        [Test]
        public void OneMillionShouldNotBeHandledByThisPrettifier()
        {
            // setup
            // 1,000,000
            const double numberToPrettify = 1000000;

            // the test
            bool shouldBeHandledByThisPrettifier = _handler.ShouldHandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(false, shouldBeHandledByThisPrettifier);
        }

        [Test]
        public void BillionResultWillMatchExpectedResult()
        {
            // setup
            // 2,502,350,000.34
            const double numberToPrettify = 2502350000.34;
            const string expectedResult = "2.5 B";

            // the test
            string result = _handler.HandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(expectedResult, result);
        }
    }
}
