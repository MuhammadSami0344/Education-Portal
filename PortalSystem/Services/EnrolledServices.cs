using Microsoft.AspNetCore.Components.Authorization;
using PortalSystem.Data;
using PortalSystem.Models;
using PortalSystem.View_Models;
using System.Security.Claims;

namespace PortalSystem.Services
{
    public class EnrolledServices : IEnrolledServices
    {
        private readonly PortalSystemDb _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public EnrolledServices(PortalSystemDb context, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> EnrollInClass(EnrollVm modelVm)
        {
            try
            {
                var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authenticationState.User;
                var userId = user.FindFirst(ClaimTypes.Sid)?.Value;
                var enroll = new EnrolledUsers();
                enroll.UserId = Convert.ToInt32(userId);
                enroll.UserName = user.Identity.Name;
                enroll.ClassId = modelVm.ClassId;
                enroll.UserEnrolledDate = DateTime.Now;
                enroll.EnrollStatus = true;
                _context.TblEnrolledUsers.Add(enroll);
                _context.SaveChanges();
                if (enroll.Id > 0)
                {
                    var classRecord = _context.TblClasses.Find(modelVm.ClassId);
                    if (classRecord.TotalSets >= classRecord.RemainingSets && classRecord.RemainingSets > 0)
                    {
                        classRecord.RemainingSets -= 1;
                        _context.TblClasses.Update(classRecord);
                        _context.SaveChanges();
                    }
                    
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
