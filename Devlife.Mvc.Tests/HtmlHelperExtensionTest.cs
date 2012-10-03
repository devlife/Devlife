using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Devlife.Mvc.Tests
{
    [TestClass]
    public class HtmlHelperExtensionTest : TestBase
    {
        [TestMethod]
        public void Script_returns_properly_formatted_script_tag()
        {
            const string expected = "<script type=\"text\\javascript\" src=\"/Scripts/jquery.js\" />";

            HtmlHelper helper = CreateHtmlHelper();

            MvcHtmlString result = helper.Script("jquery.js");

            string actual = result.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
