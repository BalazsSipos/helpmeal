﻿using helpmeal.Models.RequestModels.UserSettingsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Services.UserSettings
{
    public interface IUserSettingsService
    {
        Task<byte> GetNumberOfWeeksInCycleAsync(string email);
        Task<List<byte>> GetDaysOfShoppingAsync(string email);
        Task<UserSettingsService> SetUserSettingsAsync(string email, EditUserSettingsRequest userSettingsReq);
    }
}
