using RentalQuotation.Model;
using RentalQuotation.Repository;
using RentalQuotation.Repository.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RentalQuotationEnqiry
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IQuotationData, QuotationRepu>();
            container.RegisterType<ICostComponent, CostComponentRepu>();
            container.RegisterType<IMenuRepo, MenuRepo>();
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IRoleRepo, RoleRepo>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}