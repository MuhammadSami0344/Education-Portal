using Microsoft.AspNetCore.Components;
using PortalSystem.Services;
using PortalSystem.View_Models;

namespace PortalSystem.Components
{
    public partial class EnrolledUserList
    {
        [Inject]
        IClassServices ClassServices { get; set; }
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public int ClassId { get; set; }
        [Parameter]
        public EventCallback<bool> HideVisibilty { get; set; }

        public List<ClassVm> classRecord = new List<ClassVm>();
        public async Task HideComponent()
        {
            await HideVisibilty.InvokeAsync();
        }

        protected override async Task OnInitializedAsync()
        {
           await LoadEnrolledUsers();
        }

        // Load data of enrolled users in specific class
        public async Task LoadEnrolledUsers()
        {
            classRecord = await ClassServices.GetEnrolledUsers(ClassId);
        }
    }
}
