using Microsoft.AspNetCore.Components;
using PortalSystem.Services;
using PortalSystem.View_Models;

namespace PortalSystem.Pages
{
    public partial class Index
    {
        [Inject]
        IClassServices ClassServices { get; set; }
        [Inject]
        IEnrolledServices EnrolledServices { get; set; }

        public List<ClassVm> classRecordList = new List<ClassVm>();
        public EnrollVm enrollVm = new EnrollVm();
        protected override async Task OnInitializedAsync()
        {
           await LoadRecord();
        }

        public async Task LoadRecord()
        {
            classRecordList = await ClassServices.GetAll();
        }

        // User Enrolling in Class
        public bool IsEnrollMessage { get; set; }
        public async Task EnrollInClass(int ClassId)
        {
            enrollVm.ClassId = ClassId;
           var IsRecordAdded = await EnrolledServices.EnrollInClass(enrollVm);
            if (IsRecordAdded)
            {
                IsEnrollMessage = true;
                
            }
        }
        public async Task HideVisibility()
        {
            IsEnrollMessage = false;
            await LoadRecord();
        }

        // This Functionality is only for Admin
        #region View Enrolled Users In Class

        public bool IsViewEnrolledList { get; set; }
        public int ClassId { get; set; }
        public void ShowEnrollerUser(int classId)
        {
            ClassId = classId;
            IsViewEnrolledList = true;
        }
        public void HideEnrollerUser()
        {
            IsViewEnrolledList = false;
        }

        #endregion
    }
}
