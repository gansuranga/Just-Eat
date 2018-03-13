using System.Runtime.Serialization;

namespace JustEat.Objects
{
    public class RestaurantResult : IMappable
    {
        [DataMember(Name = "Restaurants")]
        public Restaurant[] Restaurants { get; set; }
    }
}
