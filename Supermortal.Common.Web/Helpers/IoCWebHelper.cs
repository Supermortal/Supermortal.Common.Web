using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Supermortal.Common.PCL.Helpers;

namespace Supermortal.Common.Web.Helpers
{
    public class IoCWebHelper
    {

        private static IDependencyResolver _dependencyResolver;
        public static IDependencyResolver DependencyResolver => _dependencyResolver ?? (_dependencyResolver = GetDependencyResolver());

        private static IDependencyResolver GetDependencyResolver()
        {
            if (IoCHelper.Instance == null)
                return null;

            return new IoCHelperDependencyResolver();
        }
    }

    public class IoCHelperDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return IoCHelper.Instance.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return IoCHelper.Instance.GetServices(serviceType);
        }
    }
}
