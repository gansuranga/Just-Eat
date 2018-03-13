// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestControllerBase.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the TestControllerBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Library.Tests.Infrastructure
{
    using System.Web.Mvc;

    using NUnit.Framework;

    public abstract class TestControllerBase<T> : UnitTestControllerFixtureBase
    {
        /// <summary>
        /// The error key.
        /// </summary>
        protected string errorKey = "error";

        /// <summary>
        /// The error value.
        /// </summary>
        protected string errorValue = "errorValue";

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        public T Controller { get; set; }

        // Delegate to create a Controller instance.

        /// <summary>
        /// The create controller.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public abstract T CreateController();

        /// <summary>
        /// The before set up.
        /// </summary>
        public virtual void BeforeSetUp()
        {
        }

        public virtual void MockSetup()
        {
        }

        /// <summary>
        /// The after set up.
        /// </summary>
        public virtual void AfterSetUp()
        {
        }

        /// <summary>
        /// The add model error.
        /// </summary>
        protected virtual void AddModelError()
        {
        }

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        protected virtual void Setup()
        {
            this.BeforeSetUp();
            this.MockSetup();
            this.Controller = this.CreateController();
            this.AfterSetUp();
        }
    }

    public abstract class TestController<T> : TestControllerBase<T> where T : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestController{T}"/> class. 
        /// Initialize the controller builder.
        /// </summary>
        protected TestController()
        {
            this.ControllerBuilder = new TestControllerBuilder();
        }


        /// <summary>
        /// Gets or sets the controller builder.
        /// </summary>
        public TestControllerBuilder ControllerBuilder { get; set; }

        /// <summary>
        /// The create controller.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public override T CreateController()
        {
            return this.ControllerBuilder.CreateController<T>(this.AutoMoqer);
        }

        /// <summary>
        /// Initialize controller.
        /// </summary>
        public override void AfterSetUp()
        {
            this.ControllerBuilder.InitializeController(this.Controller, this.HttpContext.Object, this.RouteData, this.TempDataDictionary);
        }

        /// <summary>
        /// The add model error.
        /// </summary>
        protected override void AddModelError()
        {
            Controller.ModelState.AddModelError(this.errorKey, this.errorValue);
        }
    }

}
