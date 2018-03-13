// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.CodingTest.Controllers
{
    using System.Web.Mvc;
    using JustEat.Business.Interfaces;
    using JustEat.CodingTest.ViewModels;
    using JustEat.Objects;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="restaurantService">
        /// The restaurant service.
        /// </param>
        public HomeController(IRestaurantService restaurantService)
        {
            this.RestaurantService = restaurantService;
        }

        /// <summary>
        /// Gets or sets the restaurant service.
        /// </summary>
        private IRestaurantService RestaurantService { get; set; }

        /// <summary>
        /// The search restaurant.
        /// </summary>
        /// <param name="outcode">
        /// The out code.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult SearchRestaurant(string outcode)
        {
            if (!string.IsNullOrWhiteSpace(outcode))
            {
                var restaurantResult = this.RestaurantService.GetSearchResult(outcode);
                var viewModel = restaurantResult.Map<RestaurantViewModel>();

                return this.View("index", viewModel);
            }
            return this.View("index");
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
             return this.View();
        }
    }
}