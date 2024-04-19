using PortalSystem.View_Models;

namespace PortalSystem.Services
{
    public interface IUsersAccountServices
    {
        public Task<int> AddUser(UsersRegistrationVm ModelVm);
        public Task<LoginUserVm> UserLogin(LoginUserVm ModelVm);
    }
}
