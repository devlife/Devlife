using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Devlife.Mvc.Tests
{
    [TestFixture]
    [Category(TestCategories.ObjectExtensions)]
    public class ObjectExtensionsTests
    {
        [Test]
        public void ToDictionary_returns_non_null_if_object_is_null()
        {
            var result = ObjectExtensions.ToDictionary(null);
            Assert.IsNotNull(result);
        }

        [Test]
        public void ToDictionary_returns_propery_keys_and_values_if_object_is_not_null()
        {
            object id = 123;
            object name = "Customer Name";

            var obj = new
            {
                Id = id,
                Name = name
            };

            var result = obj.ToDictionary();

            Assert.AreEqual(id, result["Id"]);
            Assert.AreEqual(name, result["Name"]);
        }
    }
}