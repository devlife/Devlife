using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Devlife.Mvc.Tests
{
    [TestClass]
    public class ObjectExtensionsTest
    {
        [TestMethod]
        public void ToDictionary_returns_non_null_if_object_is_null()
        {
            var result = ObjectExtensions.ToDictionary(null);
            Assert.IsNotNull(result);
        }

        [TestMethod]
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
