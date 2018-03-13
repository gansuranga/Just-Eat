using System.Runtime.Serialization;

namespace JustEat.Objects
{
    [DataContract]
    public class Restaurant : IMappable
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "RatingAverage")]
        public string RatingAverage { get; set; }

        [DataMember(Name = "CuisineTypes")]
        public CuisineType[] CuisineTypes { get; set; }
    }
}
