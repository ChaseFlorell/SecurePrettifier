using NUnit.Framework;
using Secure.Core.Prettifier;
using System;

namespace Secure.Tests.UnitTests.Prettifier
{
    [TestFixture]
    public class QuadrillionsPrettifierTests
    {
        // instantiate the _handler to be used for prettifying Quadrillion numbers
        private readonly IPrettificationHandler _handler;
        public QuadrillionsPrettifierTests() 
        {
            _handler = new QuadrillionsPrettifier();
        }

        [Test]
        public void OneQuadrillionShouldBeHandledByThisPrettifier()
        {
            // setup
            // 1,000,000,000,000,000
            const double numberToPrettify = 1000000000000000;

            // the test
            var shouldBeHandledByThisPrettifier = _handler.ShouldHandleRequest(numberToPrettify);

            // the verification
            Assert.AreEqual(true, shouldBeHandledByThisPrettifier);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OneQuadrillionShouldThrowAnException()
        {
            // setup
            // 1,000,000,000,000,000
            const double numberToPrettify = 1000000000000000;

            // the test
            _handler.HandleRequest(numberToPrettify);
        }
    }
}
