using System.Web;
using System.Web.Routing;
using Moq;

namespace Lifebyte.Web.Tests.TestHelpers
{
    public static class RouteTestHelper
    {
        /// <summary>
        /// Test routes by making a mock HTTP Context and passing a path.
        /// </summary>
        /// <see cref="http://www.deanhume.com/Home/BlogPost/test-your-mvc-routes-with-moq/28"/>
        /// <param name="appRelativeCurrentExecutionFilePath"></param>
        /// <returns></returns>
        public static RouteData GetRouteData(string appRelativeCurrentExecutionFilePath)
        {
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);
            var httpContenxtMock = new Mock<HttpContextBase>();

            httpContenxtMock.Setup(h => h.Request.AppRelativeCurrentExecutionFilePath)
                .Returns(appRelativeCurrentExecutionFilePath);

            return routes.GetRouteData(httpContenxtMock.Object);
        }
    }
}