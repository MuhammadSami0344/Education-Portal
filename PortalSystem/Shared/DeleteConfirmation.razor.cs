using Microsoft.AspNetCore.Components;

namespace PortalSystem.Shared
{
    public partial class DeleteConfirmation
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string Message { get; set; }
        [Parameter]
        public EventCallback<bool> DeleteRecord { get; set; }

        public async Task DeleteConfirmationRecord(bool value)
        {
           await DeleteRecord.InvokeAsync(value);
        }


    }
}
