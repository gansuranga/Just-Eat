// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RestaurantViewModel.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the RestaurantViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.CodingTest.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The restaurant view model.
    /// </summary>
    public class RestaurantViewModel : JustEat.Objects.IMappable
    {
        /// <summary>
        /// Gets or sets the restaurants.
        /// </summary>
        public List<Restaurant> Restaurants { get; set; }

        /// <summary>
        /// Gets or sets the out code.
        /// </summary>
        [Required]
        public string OutCode { get; set; }
    }

    /// <summary>
    /// The restaurant object.
    /// </summary>
    public class Restaurant : JustEat.Objects.IMappable
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the cuisine types.
        /// </summary>
        public List<CuisineType> CuisineTypes { get; set; }
    }

    /// <summary>
    /// The cuisine type.
    /// </summary>
    public class CuisineType : JustEat.Objects.IMappable
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the SEO name.
        /// </summary>
        public string SeoName { get; set; }
    }
}