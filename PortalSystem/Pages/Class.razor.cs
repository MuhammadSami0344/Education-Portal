using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalSystem.Services;
using PortalSystem.Shared;
using PortalSystem.View_Models;

namespace PortalSystem.Pages
{
    public partial class Class
    {
        [Inject]
        IClassServices ClassServices { get; set; }
        public List<SelectListItem> timmingList = new List<SelectListItem>();

        public ClassVm ModelVm = new ClassVm();
        public List<ClassVm> recordList = new List<ClassVm>();
        protected async override Task OnInitializedAsync()
        {
            LoadTimeList();
            await LoadRecords();
        }
        public async Task SaveRecord()
        {
            if (ModelVm.Id > 0)
            {
                await ClassServices.UpdateClass(ModelVm);
            }
            else
            {
                await ClassServices.AddClass(ModelVm);
            }
            ModelVm = new();
           await LoadRecords();
        }

        public async Task LoadRecords()
        {
            recordList = await ClassServices.GetAll();
        }

        public void LoadTimeList()
        {

            timmingList.Add(new SelectListItem("Morning", "Morning"));
            timmingList.Add(new SelectListItem("Evening", "Evening"));
        }

        #region Edit Record

        public async Task EditRecord(int ClassId)
        {
            ModelVm = await ClassServices.EditClass(ClassId);
        }

        public void Cancel()
        {
            ModelVm = new();
        }

        #endregion

        #region Delete Record

        public bool IsDeleteConfirmation { get; set; }
        public int ClassId { get; set; }
        public async void DeleteRecord(int classId)
        {
            IsDeleteConfirmation = true;
            ClassId = classId;
           
        }
        public async Task DeleteConfirmation(bool value)
        {
            if (value)
            {
                await ClassServices.DeleteClass(ClassId);
                await LoadRecords();
            }
            IsDeleteConfirmation = false;
        }
        #endregion
    }
}
