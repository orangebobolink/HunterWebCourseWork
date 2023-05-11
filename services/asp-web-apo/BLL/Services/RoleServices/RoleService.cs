using AutoMapper;
using DAL.Repositories.RoleRepository;

namespace BLL.Services.RoleServices
{
    internal class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetAll()
        {
            var roles = await _roleRepository.GetAllAsync();

            return roles.Select(role => role.Name);
        }
    }
}
