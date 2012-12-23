using DevLife.Extensions;
using NUnit.Framework;

namespace Devlife.Tests.Extensions.StringExtensions
{
    [TestFixture]
    [Category(TestCategories.StringExtensions)]
    public class EllipsedTests
    {
        [Test]
        public void Ellipsed_returns_original_string_if_value_is_less_than_limit()
        {
            const string value = "this should be less than 50";
            string result = value.Ellipsed();

            Assert.AreEqual(value, result);
        }

        [Test]
        public void Ellipsed_returns_original_string_if_value_equals_limit()
        {
            const string value = "some string value";
            string result = value.Ellipsed(value.Length);

            Assert.AreEqual(value, result);
        }

        [Test]
        public void Ellipsed_returns_ellipsed_string_if_value_is_greater_than_limit()
        {
            const string value = "some string value";
            string result = value.Ellipsed(10);

            const string expected = "some strin...";

            Assert.AreEqual(expected, result);
        } 
    }
}