using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

//http://docs.castleproject.org/(X(1)S(20s4gpm5kbspac5511qulyag))/Windsor.Windsor-tutorial-part-four-putting-it-all-together.ashx

namespace Lifebyte.Web.Models.Services
{
    public class DependencyResolverService : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public DependencyResolverService(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)kernel.Resolve(controllerType);
        }
    }

}
