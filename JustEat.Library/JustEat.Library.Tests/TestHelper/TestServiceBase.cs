// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestServiceBase.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the TestServiceBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Library.Tests.TestHelper
{
    using NUnit.Framework;

    /// <summary>
    /// The test service base.
    /// </summary>
    /// <typeparam name="T">
    /// the service type.
    /// </typeparam>
    public abstract class TestServiceBase<T> : UnitTestFixtureBase
    {
        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        protected T Service { get; set; }

        /// <summary>
        /// The before set up.
        /// </summary>
        public virtual void BeforeSetUp()
        {
        }

        /// <summary>
        /// The mock set up.
        /// </summary>
        public virtual void MockSetUp()
        {

        }

        /// <summary>
        /// The after set up.
        /// </summary>
        public virtual void AfterSetUp()
        {
        }

        /// <summary>
        /// Create service.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        protected abstract T CreateService();

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        protected virtual void Setup()
        {
            this.BeforeSetUp();
            this.MockSetUp();
            this.Service = this.CreateService();
            this.AfterSetUp();
        }
    }

}
