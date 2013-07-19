using NUnit.Framework;
using Secure.Core.Prettifier;

namespace Secure.Tests.UnitTests.Prettifier
{
    [TestFixture]
    public class TrillionsPrettifierTests
    {
        // instantiate the _handler to be used for prettifying Trillion numbers
        private readonly IPrettificationHandler _handler;
        public TrillionsPrettifierTests() 
        {
            _handler = new TrillionsPrettifier();
        }

        [Test]
        public void OneTrillionShouldBeHandledByThisPrettifier()
        {
            // setup
            // 1,000,000,000,000
            const double numberToPrettify = 1000000000000;

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
        public void TrillionResultWillMatchExpectedResult()
        {
            // setup
            // 3,100,502,350,000.34
            const double numberToPrettify = 3100502350000.34;
            const string expectedResult = "3.1 T";

            // the test
            string result = _handler.HandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void BigTrillionNumberWillMatchExpectedResult()
        {
            // setup
            // 999,900,000,000,000
            const double numberToPrettify = 999900000000000;
            const string expectedResult = "999.9 T";

            // the test
            string result = _handler.HandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(expectedResult, result);

        }
    }
}
