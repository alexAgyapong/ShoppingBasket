using NUnit.Framework;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Failing_unit_test()
        {
            var actual = 5;
            var expected = 15;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
