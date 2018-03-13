// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeControllerFixture.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the HomeControllerFixture type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.CodingTest.Tests.Controllers
{
    using JustEat.CodingTest.Controllers;
    
    using JustEat.CodingTest.Tests.TestHelper;

    using NUnit.Framework;

    /// <summary>
    /// The home controller fixture.
    /// </summary>
    [TestFixture]
    public class HomeControllerFixture : JustEatControllerTestBase<HomeController>
    {
        //[Test]
        //public void SearchRestaurant_Complete_StatusMessageFlag_On()
        //{

        //}

        //[Test]
        //public void SearchRestaurant_Complete_StatusMessageFlag_Off()
        //{

        //}

        /// <summary>
        /// The before set up.
        /// </summary>
        public override void MockSetup()
        {
        }
    }
}
