// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityRegistration.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the UnityRegistration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Bootstrapper
{
    using Bootstrap.Unity;

    using JustEat.Business;
    using JustEat.Business.Interfaces;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The unity registration.
    /// </summary>
    public class UnityRegistration : IUnityRegistration
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void Register(IUnityContainer container)
        {
            RegisterBusinessTypes(container);
        }

        /// <summary>
        /// The register business types.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        private static void RegisterBusinessTypes(IUnityContainer container)
        {
            container.RegisterType<IRestaurantService, RestaurantService>();
        }
    }
}
