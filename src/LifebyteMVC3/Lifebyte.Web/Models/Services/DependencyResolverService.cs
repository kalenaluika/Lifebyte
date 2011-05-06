using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;

namespace Lifebyte.Web.Models.Services
{
    public class DependencyResolverService : IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public DependencyResolverService(IWindsorContainer container)
        {
            this.container = container;
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType)
                       ? container.ResolveAll(serviceType).Cast<object>()
                       : new object[] {};
        }

        #endregion
    }
}