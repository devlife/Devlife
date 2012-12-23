using Devlife.Mvc.Extensions;
using NUnit.Framework;
using System.Web.Mvc;

namespace Devlife.Mvc.Tests
{
    [TestFixture]
    [Category(TestCategories.HtmlHelperExtensions)]
    public class HtmlHelperExtensionsTests : TestBase
    {
        [Test]
        public void Script_returns_properly_formatted_script_tag()
        {
            const string expected = "<script src=\"/Scripts/jquery.js\" type=\"text/javascript\"></script>";

            HtmlHelper helper = CreateHtmlHelper(appPath: "/Scripts/jquery.js");

            MvcHtmlString result = helper.Script("jquery.js");

            string actual = result.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}