using helpmeal.Models.Identity;
using helpmeal.Models.RequestModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;

namespace helpmeal.Services.User
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(AppUser user);
        Task<LoginRequest> CreateLoginRequest(string returnUrl);
        Task Logout();
        Task<AppUser> FindUserByNameOrEmailAsync(string emailAddr);
        Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        AuthenticationProperties ConfigureExternalAuthenticaticationProperties(string provider, string redirectUrl);
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey);
        Task<string> ExternalLoginCallbackAsync(string returnUrl, string remoteError);
        Task<SignInResult> RegisterExternalUserAsync(string emailAddr, ExternalLoginInfo userInfo);
        //Task<UserSetting> GetUserSettingByUserAsync(ClaimsPrincipal user);
    }
}
