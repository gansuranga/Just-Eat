using AutoMapper;

namespace JustEat.Objects
{
    public static class Extensions
    {
        public static TDestination Map<TDestination>(this IMappable source)
           where TDestination : IMappable
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
