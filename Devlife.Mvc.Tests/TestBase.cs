using Moq;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace Devlife.Mvc.Tests
{
    public class TestBase
    {
        public static HtmlHelper CreateHtmlHelper(ViewDataDictionary vd = null, string appPath = "/")
        {
            vd = vd ?? new ViewDataDictionary();

            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.ApplicationPath).Returns(appPath);
            context.Setup(c => c.Response.ApplyAppPathModifier(It.IsAny<string>())).Returns(appPath);

            var controllerContext = new ControllerContext(context.Object, new RouteData(), new Mock<ControllerBase>().Object);

            var mockViewContext = new ViewContext(controllerContext,
                                                  new Mock<IView>().Object,
                                                  vd, new TempDataDictionary(),
                                                  new HtmlTextWriter(new StreamWriter(new MemoryStream())));

            var mockViewDataContainer = new Mock<IViewDataContainer>();
            mockViewDataContainer.Setup(v => v.ViewData).Returns(vd);

            return new HtmlHelper(mockViewContext, mockViewDataContainer.Object);
        }

        public static UrlHelper CreateUrlHelper()
        {
            var routes = new RouteCollection();

            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            request.SetupGet(x => x.ApplicationPath).Returns("/");
            request.SetupGet(x => x.Url).Returns(new Uri("http://localhost/a", UriKind.Absolute));
            request.SetupGet(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection());

            var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
            response.Setup(x => x.ApplyAppPathModifier("/post1")).Returns("http://localhost/post1");

            var context = new Mock<HttpContextBase>(MockBehavior.Strict);
            context.SetupGet(x => x.Request).Returns(request.Object);
            context.SetupGet(x => x.Response).Returns(response.Object);

            return new UrlHelper(new RequestContext(context.Object, new RouteData()), routes);
        }
    }
}