using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PortalSystem.Data;
using PortalSystem.Models;
using PortalSystem.View_Models;

namespace PortalSystem.Services
{
    public class UsersAccountServices : IUsersAccountServices
    {
        private PortalSystemDb _context;
        public UsersAccountServices(PortalSystemDb context)
        {
            _context = context;
        }

        public async Task<int> AddUser(UsersRegistrationVm ModelVm)
        {
            try
            {
                var userRegister = new Users();
                userRegister.FirstName = ModelVm.FirstName;
                userRegister.LastName = ModelVm.LastName;
                userRegister.Email = ModelVm.Email;
                userRegister.Password = ModelVm.Password;
                _context.TblUsers.Add(userRegister);
               await _context.SaveChangesAsync();
                if (userRegister.Id > 0)
                {
                    var userRole = new Roles();
                    userRole.RoleId = 2;
                    userRole.UserId = userRegister.Id;
                    _context.TblRoles.Add(userRole);
                    await _context.SaveChangesAsync();
                }
                return userRegister.Id;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        // User Login Function

        public async Task<LoginUserVm> UserLogin(LoginUserVm ModelVm)
        {
            try
            {
                return await (from u in _context.TblUsers
                        where u.Email == ModelVm.EmailAddress && u.Password == ModelVm.Password
                        select new LoginUserVm()
                        {
                            UserId = u.Id,
                            EmailAddress = u.Email,
                            Password = u.Password,
                            UserName = u.FirstName + " " + u.LastName,
                            UserRole = (from r in _context.TblRoles
                                        where r.UserId == u.Id
                                        join rn in _context.TblRolesNames on r.RoleId equals rn.Id 
                                        select rn.RoleName).FirstOrDefault(),
                        }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
