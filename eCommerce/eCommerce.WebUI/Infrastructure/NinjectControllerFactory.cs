using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using eCommerce.Model.Abstract;
using eCommerce.Model;
using eCommerce.Model.Concrete;


namespace eCommerce.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            //_ninjectKernel.Load(Assembly.GetExecutingAssembly());
            AddBinding();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
           _ninjectKernel.Bind<IFoodRepository>().To<EFFoodRepository>();
        }
    }
}