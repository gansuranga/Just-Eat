// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessServiceFixtureBase.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the BusinessServiceFixtureBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Library.Tests.TestHelper
{
    /// <summary>
    /// The business service fixture base.
    /// </summary>
    /// <typeparam name="T">
    /// The service type.
    /// </typeparam>
    public abstract class BusinessServiceFixtureBase<T> : TestServiceBase<T>
    {
        /// <summary>
        /// The create service.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        protected override T CreateService()
        {
            return this.AutoMoqer.Resolve<T>();
        }
    }
}
