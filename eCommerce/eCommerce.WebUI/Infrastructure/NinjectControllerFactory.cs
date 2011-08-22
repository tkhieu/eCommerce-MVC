using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using eCommerce.Model.Abstract;
using eCommerce.Model.Entities;

namespace eCommerce.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBinding();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            Mock<IFoodRepository> mock = new Mock<IFoodRepository>();
            mock.Setup(m => m.Foods).Returns(new List<Food>
                                                 {
                                                     new Food() {Name = "Kem Ly", Category = "Vị Cay"},
                                                     new Food(){Name = "Kem Cốc",Category = "Vị Ngọt"}
                                                 }.AsQueryable);
            _ninjectKernel.Bind<IFoodRepository>().ToConstant(mock.Object);
        }


    }
}