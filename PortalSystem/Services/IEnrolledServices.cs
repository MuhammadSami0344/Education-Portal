using PortalSystem.View_Models;

namespace PortalSystem.Services
{
    public interface IEnrolledServices
    {
        public Task<bool> EnrollInClass(EnrollVm modelVm);

    }
}
