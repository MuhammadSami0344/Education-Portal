using Microsoft.AspNetCore.Components;

namespace PortalSystem.Shared
{
    public partial class CongratulationMessage
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string Message { get; set; }
        [Parameter]
        public EventCallback HideVisibility { get; set; }

        public async Task HideComponent()
        {
            await HideVisibility.InvokeAsync();
        }
    }
}
