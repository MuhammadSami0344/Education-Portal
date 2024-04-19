using PortalSystem.View_Models;

namespace PortalSystem.Services
{
    public interface IClassServices
    {
        public Task AddClass(ClassVm modelVm);
        public Task<ClassVm> EditClass(int classId);
        public Task<List<ClassVm>> GetAll();
        public Task<List<ClassVm>> GetEnrolledUsers(int classId);
        public Task UpdateClass(ClassVm modelVm);
        public Task DeleteClass(int classId);
    }
}
