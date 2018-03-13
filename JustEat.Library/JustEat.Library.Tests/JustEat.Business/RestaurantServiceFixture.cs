// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestaurantServiceFixture.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the RestaurantServiceFixture type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Library.Tests.JustEat.Business
{
    using global::JustEat.Business;
    using global::JustEat.Library.Tests.TestHelper;
    using global::JustEat.Objects;

    using NUnit.Framework;


    /// <summary>
    /// The restaurant service fixture.
    /// </summary>
    public class RestaurantServiceFixture : BusinessServiceFixtureBase<RestaurantService>
    {
        /// <summary>
        /// The test service working.
        /// </summary>
        [Test]
        public void TestServiceWorking()
        {
            // Act
            var restaurantResult = this.Service.GetSearchResult("SE19");

            // Assert
            Assert.IsNotEmpty(restaurantResult.Restaurants);
        }
    }
}
