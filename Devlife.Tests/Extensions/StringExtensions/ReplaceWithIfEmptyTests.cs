using DevLife.Extensions;
using NUnit.Framework;

namespace Devlife.Tests.Extensions.StringExtensions
{
    [TestFixture]
    [Category(TestCategories.StringExtensions)]
    public class ReplaceWithIfEmptyTests
    {
        [Test]
        public void ReplaceWithIfEmpty_returns_ifEmpty_if_value_is_null()
        {
            const string value = null;
            const string ifEmpty = "I am not empty";

            string result = value.ReplaceWithIfEmpty(ifEmpty);

            Assert.AreEqual(ifEmpty, result);
        }

        [Test]
        public void ReplaceWithIfEmpty_returns_ifEmpty_if_value_is_an_empty_string()
        {
            string value = string.Empty;
            const string ifEmpty = "I am not empty";

            string result = value.ReplaceWithIfEmpty(ifEmpty);

            Assert.AreEqual(ifEmpty, result);
        }

        [Test]
        public void ReplaceWithIfEmpty_returns_ifEmpty_if_value_is_white_space()
        {
            const string value = "      ";
            const string ifEmpty = "I am not empty";

            string result = value.ReplaceWithIfEmpty(ifEmpty);

            Assert.AreEqual(ifEmpty, result);
        }

        [Test]
        public void ReplaceWithIfEmpty_returns_value_if_value_is_not_an_empty_string()
        {
            const string value = "I am not empty";
            const string ifEmpty = "I am not empty, either";

            string result = value.ReplaceWithIfEmpty(ifEmpty);

            Assert.AreEqual(value, result);
        }
    }
}