using BLL.DTOs.UserDTOs;
using DAL.Entities.UserEntities;
using AutoMapper;

namespace BLL.Resolvers
{
    internal class UserRoleResolver : IValueResolver<User, UserDTO, List<string>>
    {
        public List<string> Resolve(User source, UserDTO destination, List<string> destMember, ResolutionContext context)
            => source.Roles.Select(o => o.Name).ToList();
    }
}
