using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using SspClient.ServiceWorker;

namespace SspClient.Helpers
{
    public static class DIFactory
    {
        private static IKernel _kernel;

        public static T Resolve<T>()
        {
            if (_kernel == null)
            {
                CreateKernel();
            }
            return _kernel.Get<T>();
        }

        public static T Resolve<T>(string name)
        {
            if (_kernel == null)
            {
                CreateKernel();
            }
            return _kernel.Get<T>(name);
        }

        private static void CreateKernel()
        {
            var module = new Bindings();
            _kernel = new StandardKernel(module);
        }

        class Bindings : NinjectModule
        {
            public override void Load()
            {
                Bind<IServiceWorker>()
                    .To<ServiceWorker.ServiceWorker>()
                    .InSingletonScope()
                    .WithConstructorArgument("serviceAddress", ConfigurationManager.AppSettings["WcfAuroraServiceLink"]);
            }
        }
    }
}
