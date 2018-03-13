// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTestControllerFixtureBase.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Base class for all unit tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Library.Tests.Infrastructure
{
    using System;
    using System.Collections.Specialized;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Bootstrap.AutoMapper;
    using Bootstrap.Extensions.StartupTasks;
    using Bootstrap.Unity;

    using global::JustEat.Common.Infrastructure;

    using Microsoft.Practices.Unity;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// Base class for all unit tests.
    /// </summary>
    public abstract class UnitTestControllerFixtureBase
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        public IUnityContainer Container { get; set; }


        #region Environment variables for controller    

        /// <summary>
        /// Gets or sets the fake user.
        /// </summary>
        public Mock<IPrincipal> FakeUser { get; set; }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        public Mock<HttpServerUtilityBase> Server { get; set; }

        /// <summary>
        /// Gets or sets the HttpContext that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The HTTPContext</value>
        public Mock<HttpContextBase> HttpContext { get; protected internal set; }

        /// <summary>
        /// Gets or sets the HttpPostedFiles that controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The HttpFileCollection Files</value>
        public HttpFileCollectionBase Files { get; protected internal set; }

        /// <summary>
        /// Gets or sets the Form data that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The NameValueCollection Form</value>
        public NameValueCollection Form { get; protected internal set; }

        /// <summary>
        /// Gets or sets the QueryString that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The NameValueCollection QueryString</value>
        public NameValueCollection QueryString { get; protected internal set; }

        /// <summary>
        /// Gets or sets the AcceptTypes property of Request that built controllers will have set internally when created with InitializeController
        /// </summary>
        public string[] AcceptTypes { get; set; }

        /// <summary>
        /// Gets or sets the Session that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The IHttpSessionState Session</value>
        public HttpSessionStateBase Session { get; protected internal set; }

        /// <summary>
        /// Gets or sets the TempDataDictionary that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The TempDataDictionary</value>
        public TempDataDictionary TempDataDictionary { get; protected internal set; }

        /// <summary>
        /// Gets or sets the RouteData that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The RouteData</value>
        public RouteData RouteData { get; set; }

        /// <summary>
        /// Gets or sets the AppRelativeCurrentExecutionFilePath that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The RouteData</value>
        public string AppRelativeCurrentExecutionFilePath { get; set; }

        /// <summary>
        /// Gets or sets the AppRelativeCurrentExecutionFilePath string that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The ApplicationPath string</value>
        public string ApplicationPath { get; set; }

        /// <summary>
        /// Gets or sets the PathInfo string that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The PathInfo string</value>
        public string PathInfo { get; set; }

        /// <summary>
        /// Gets or sets the RawUrl string that built controllers will have set internally when created with InitializeController
        /// </summary>
        /// <value>The RawUrl string</value>
        public string RawUrl { get; set; }

        /// <summary>
        /// Gets or sets the routes.
        /// </summary>
        protected RouteCollection Routes { get; set; }

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        protected Mock<HttpRequestBase> Request { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        protected Mock<HttpResponseBase> Response { get; set; }

        /// <summary>
        /// Gets or sets the auto moqer.
        /// </summary>
        protected AutoMoq.AutoMoqer AutoMoqer { get; set; }

        #endregion


        /// <summary>
        /// Performs functions prior to executing any of the tests in the fixture.
        /// </summary>
        [TestFixtureSetUp]
        protected virtual void TestFixtureSetUp()
        {
            this.BootstrapperStart();
            this.Container = (IUnityContainer)Bootstrap.Bootstrapper.Container;
            this.Container.AddExtension(new AutoMockingContainerExtension());
        }

        /// <summary>
        /// The bootstrapper start.
        /// </summary>
        protected virtual void BootstrapperStart()
        {
            // TODO:Setup mock caching/log/IoC etc..
            Bootstrap.Bootstrapper.With.Unity().UsingAutoRegistration().And.AutoMapper().And.StartupTasks().Start();
        }

        /// <summary>
        /// Performs functions once after all tests are completed.
        /// </summary>
        [TestFixtureTearDown]
        protected virtual void TestFixtureTearDown()
        {
            this.BaseTearDown();
        }


        /// <summary>
        /// Base tear down function.
        /// </summary>
        protected virtual void BaseTearDown()
        {
        }

        /// <summary>
        /// The base setup.
        /// </summary>
        [SetUp]
        protected virtual void BaseSetup()
        {
            this.InitializeCulture();
        }

        /// <summary>
        /// Initialize culture.
        /// </summary>
        private void InitializeCulture()
        {
            if (TimeZoneInfo.Local.StandardName == "Australian Central Standard Time")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-AU");
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    System.Threading.Thread.CurrentThread.CurrentCulture;
            }
        }

        protected virtual void CustomizedMvcSetup()
        {
        }
    }
}
