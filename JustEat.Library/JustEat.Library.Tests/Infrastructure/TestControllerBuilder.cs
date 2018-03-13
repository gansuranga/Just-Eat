// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestControllerBuilder.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Build the controller with proper context setup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Library.Tests.Infrastructure
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AutoMoq;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// Build the controller with proper context setup.
    /// </summary>
    public class TestControllerBuilder
    {
        /// <summary>
        /// The initialize controller.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="httpContext">
        /// The http context.
        /// </param>
        /// <param name="routeData">
        /// The route data.
        /// </param>
        /// <param name="tempData">
        /// The temp data.
        /// </param>
        public void InitializeController(Controller controller, HttpContextBase httpContext, RouteData routeData, TempDataDictionary tempData)
        {
            var controllerContext = new ControllerContext(httpContext, routeData, controller);
            controller.ControllerContext = controllerContext;
            controller.TempData = tempData;
            controller.Url = new UrlHelper(controllerContext.RequestContext);
        }

        /// <summary>
        /// The create controller.
        /// </summary>
        /// <param name="constructorArgs">
        /// The constructor args.
        /// </param>
        /// <typeparam name="T">
        /// The controller type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T CreateController<T>(params object[] constructorArgs) where T : Controller
        {
            var controller = (Controller)Activator.CreateInstance(typeof(T), constructorArgs);
            return controller as T;
        }

        /// <summary>
        /// The create controller.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <typeparam name="T">
        /// The controller type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T CreateController<T>(IUnityContainer container) where T : Controller
        {
            var controller = container.Resolve<T>();
            return controller as T;
        }

        /// <summary>
        /// The create controller.
        /// </summary>
        /// <param name="autoMoqer">
        /// The auto moqer.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T CreateController<T>(AutoMoqer autoMoqer) where T : Controller
        {
            var controller = autoMoqer.Resolve<T>();
            return controller as T;
        }
    }
}
