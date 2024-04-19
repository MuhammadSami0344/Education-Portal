using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using PortalSystem.Models;
using PortalSystem.Services;
using PortalSystem.View_Models;
using System.Data;
using System.Net.Http;
using System.Security.Claims;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using static System.Net.WebRequestMethods;

namespace PortalSystem.Account.Identity
{
    public partial class Login
    {
        [Parameter]
        public string Message { get; set; }

        public LoginUserVm ModelVm = new LoginUserVm();
        public string? LoginErrorMessage { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Message))
            {
                if (Message == "0")
                {
                    LoginErrorMessage = "Invalid Email or Password";
                }
                else
                {
                    LoginErrorMessage = Message;
                }
            }
        }
      
    }
    }

