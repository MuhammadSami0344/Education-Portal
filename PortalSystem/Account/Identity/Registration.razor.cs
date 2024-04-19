using Microsoft.AspNetCore.Components;
using PortalSystem.Services;
using PortalSystem.View_Models;

namespace PortalSystem.Account.Identity
{
    public partial class Registration
    {
        [Inject]
        IUsersAccountServices UsersAccountServices { get; set; }
        public UsersRegistrationVm ModelVm = new UsersRegistrationVm();

        // User Record is Saving DB
        public async void SaveRecord()
        {
          var userId = await UsersAccountServices.AddUser(ModelVm);
            if (userId > 0)
            {
                NavigationManager.NavigateTo("/Account/Identity/ConfirmationMessage");
            }
        }
    }
}
