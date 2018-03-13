// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRestaurantService.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   The RestaurantService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Business.Interfaces
{
    using JustEat.Objects;

    /// <summary>
    /// The RestaurantService interface.
    /// </summary>
    public interface IRestaurantService
    {
        /// <summary>
        /// The get search result.
        /// </summary>
        /// <param name="outCode">
        /// The out code.
        /// </param>
        /// <returns>
        /// The <see cref="RestaurantResult"/>.
        /// </returns>
        RestaurantResult GetSearchResult(string outCode);
    }
}
