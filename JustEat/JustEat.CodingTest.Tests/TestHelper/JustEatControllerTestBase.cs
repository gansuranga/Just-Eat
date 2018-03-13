// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JustEatControllerTestBase.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the JustEatControllerTestBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.CodingTest.Tests.TestHelper
{
    using System.Reflection;
    using System.Web.Mvc;
    
    using AutoMoq;

    using Bootstrap.AutoMapper;
    using Bootstrap.Extensions.StartupTasks;
    using Bootstrap.Unity;

    using JustEat.Library.Tests.Infrastructure;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The just eat controller test base.
    /// </summary>
    /// <typeparam name="T">
    /// the service type.
    /// </typeparam>
    public class JustEatControllerTestBase<T> : TestController<T>
        where T : Controller
    {
        /// <summary>
        /// Initial Bootstrapper Start.
        /// </summary>
        protected override void BootstrapperStart()
        {
            Bootstrap.Bootstrapper.IncludingOnly.Assembly(Assembly.GetExecutingAssembly())
                .With.Unity().UsingAutoRegistration().And.AutoMapper().And.StartupTasks().Start();
            this.AutoMoqer = new AutoMoqer((IUnityContainer)Bootstrap.Bootstrapper.Container);
        }
    }
}
