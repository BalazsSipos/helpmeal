using helpmeal.Models.Identity;
using helpmeal.Models.RequestModels.UserSettingsRequest;
using helpmeal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace helpmeal.Services.UserSettings
{
    public interface IUserSettingsService
    {
        Task<EditUserSettingsViewModel> BuildUserSettingsViewModel(ClaimsPrincipal user);
        Task<byte> GetNumberOfWeeksInCycleAsync(ClaimsPrincipal user);
        List<byte> GetDaysOfShoppingAsync(AppUser user);
        Task<UserSettingsService> SetUserSettingsAsync(string email, List<bool> DaysOfShopping, byte NumberOfWeeksInCycle);
        Task EditSettingsAsync(ClaimsPrincipal User, EditUserSettingsRequest editUserSettingsRequest);
    }
}
