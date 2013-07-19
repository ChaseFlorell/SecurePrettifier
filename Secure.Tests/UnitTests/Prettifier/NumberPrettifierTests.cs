using NUnit.Framework;
using Secure.Core.Prettifier;

namespace Secure.Tests.UnitTests.Prettifier
{
    [TestFixture]
    class NumberPrettifierTests
    {
        // instantiate the _handler to be used for prettifying Numbers less than one Million numbers
        private readonly IPrettificationHandler _handler;
        public NumberPrettifierTests() 
        {
            _handler = new NumberPrettifier();
        }


        [Test]
        public void NumberLessThanAMillionShouldBeHandledByNumberFormatter()
        {
            // setup
            const double numberToPrettify = 532;

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
        public void LessThanOneMillionInputNumberWillMatchOutputString()
        {
            // setup
            const double numberToPrettify = 250;
            const string expectedResult = "250";

            // the test
            string result = _handler.HandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(expectedResult, result);
        }
    }
}
