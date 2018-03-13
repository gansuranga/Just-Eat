// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperProfile.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   Defines the AutoMapperProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.CodingTest.App_Start
{
    using AutoMapper;

    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            this.MapRestaurantViewModel();
            this.MapRestaurant();
            this.MapCuisineType();
        }

        private void MapRestaurantViewModel()
        {
            this.CreateMap<JustEat.Objects.RestaurantResult, ViewModels.RestaurantViewModel>()
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));

            this.CreateMap<JustEat.Objects.RestaurantResult, ViewModels.RestaurantViewModel>()
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));
        }
        
        private void MapRestaurant()
        {
            this.CreateMap<JustEat.Objects.Restaurant, ViewModels.Restaurant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.RatingAverage))
                .ForMember(dest => dest.CuisineTypes, opt => opt.MapFrom((src => src.CuisineTypes)));

            this.CreateMap<ViewModels.Restaurant, JustEat.Objects.Restaurant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RatingAverage, opt => opt.MapFrom(src => src.Rating))
                .ForMember(dest => dest.CuisineTypes, opt => opt.MapFrom((src => src.CuisineTypes)));
        }

        private void MapCuisineType()
        {
            this.CreateMap<JustEat.Objects.CuisineType, ViewModels.CuisineType>();
            this.CreateMap<ViewModels.CuisineType, JustEat.Objects.CuisineType>();
        }
    }
}