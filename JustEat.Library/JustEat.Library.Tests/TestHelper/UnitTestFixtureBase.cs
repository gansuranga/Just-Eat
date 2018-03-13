namespace JustEat.Library.Tests.TestHelper
{
    using AutoMoq;

    using Bootstrap.AutoMapper;
    using Bootstrap.Extensions.StartupTasks;
    using Bootstrap.Unity;

    using global::JustEat.Common.Infrastructure;

    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    public class UnitTestFixtureBase
    {

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// Gets or sets the auto moqer.
        /// </summary>
        protected AutoMoqer AutoMoqer { get; set; }

        /// <summary>
        /// Performs functions prior to executing any of the tests in the fixture.
        /// </summary>
        [TestFixtureSetUp]
        protected void TestFixtureSetUp()
        {
            this.BootstrapperStart();
            this.Container = (IUnityContainer)Bootstrap.Bootstrapper.Container;
            this.Container.AddExtension(new AutoMockingContainerExtension());
            this.AutoMoqer = new AutoMoqer(this.Container);
        }

        /// <summary>
        /// The bootstrapper start.
        /// </summary>
        protected virtual void BootstrapperStart()
        {
            Bootstrap.Bootstrapper.With.Unity().UsingAutoRegistration().And.AutoMapper().And.StartupTasks().Start();
        }

        /// <summary>
        /// Performs functions once after all tests are completed.
        /// </summary>
        [TestFixtureTearDown]
        protected void TestFixtureTearDown()
        {
            this.BaseTearDown();
        }


        /// <summary>
        /// Base tear down function.
        /// </summary>
        protected virtual void BaseTearDown()
        {
        }
    }
}
