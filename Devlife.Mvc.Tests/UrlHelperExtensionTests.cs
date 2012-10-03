using Moq;
using NUnit.Framework;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Devlife.Mvc.Tests
{
    [TestFixture]
    public class UrlHelperExtensionTests
    {
        [Test]
        public void DummyTest()
        {
            var context = new Mock<HttpContextBase>();
            RequestContext requestContext = new RequestContext(context.Object, new RouteData());
            UrlHelper urlHelper = new UrlHelper(requestContext);

            string path = urlHelper.Content("~/test.png");

            Assert.IsNotNullOrEmpty(path);
        }
    }
}