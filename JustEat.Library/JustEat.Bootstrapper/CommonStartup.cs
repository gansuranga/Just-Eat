// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonStartup.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the CommonStartup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Bootstrapper
{
    using System;
    using System.Web.Mvc;

    using Bootstrap.Extensions.StartupTasks;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// The common startup.
    /// </summary>
    public class CommonStartup : IStartupTask
    {
        /// <summary>
        /// The run.
        /// </summary>
        public void Run()
        {
            var container = (IUnityContainer)Bootstrap.Bootstrapper.Container;

            // Mvc Controller resolver.
            DependencyResolver.SetResolver(new Unity.Mvc4.UnityDependencyResolver(container));
        }

        /// <summary>
        /// The reset.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// No implemented.
        /// </exception>
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
