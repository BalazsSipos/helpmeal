﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Services.UserSettings
{
    public interface IUserSettings
    {
        Task<byte> GetNumberOfWeeksInCycleAsync(string email);
    }
}