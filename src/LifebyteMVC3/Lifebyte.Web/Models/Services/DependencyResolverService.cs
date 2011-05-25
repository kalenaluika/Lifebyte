using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Interfaces;

//http://docs.castleproject.org/(X(1)S(20s4gpm5kbspac5511qulyag))/Windsor.Windsor-tutorial-part-four-putting-it-all-together.ashx

namespace Lifebyte.Web.Models.Services
{
    public class DependencyResolverService
    {
        private readonly IWindsorContainer container;

        public DependencyResolverService(IWindsorContainer container)
        {
            this.container = container;
        }

        public ControllerFactory BuildControllerFactory(IKernel kernel)
        {
            return new ControllerFactory(kernel);
        }

        internal void RegisterDependencies()
        {
            container.Register(AllTypes.FromThisAssembly()
                                   .BasedOn<IController>()
                                   .If(Component.IsInSameNamespaceAs<HomeController>())
                                   .If(t => t.Name.EndsWith("Controller"))
                                   .Configure(c => c.LifeStyle.Transient))
                .Register(Component.For<IFormsAuthenticationService>()
                              .ImplementedBy(typeof (FormsAuthenticationService))
                              .LifeStyle.Transient)
                .Register(Component.For<IDataService>()
                              .ImplementedBy(typeof (DataService))
                              .LifeStyle.Transient);
        }
    }

    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public ControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext,
                                                             Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404,
                                        string.Format("The controller for path '{0}' could not be found.",
                                                      requestContext.HttpContext.Request.Path));
            }

            return (IController) kernel.Resolve(controllerType);
        }
    }
}