using AutoMapper;

namespace BLL.Interfaces
{
    public interface IValueResolver<TSource, TDestination, TDestMember>
    {
        public TDestMember Resolve(TSource source, TDestination destination, TDestMember destMember, ResolutionContext context);
    }

}
