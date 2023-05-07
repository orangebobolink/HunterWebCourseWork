using BLL.DTOs.UserDTOs;
using DAL.Entities.UserEntities;
using AutoMapper;

namespace BLL.Resolvers
{
    internal class UserRoleResolver<T> : IValueResolver<User, T, List<string>>
    {
        public List<string> Resolve(User source, T destination, List<string> destMember, ResolutionContext context)
            => source.Roles.Select(o => o.Name).ToList();
    }
}
