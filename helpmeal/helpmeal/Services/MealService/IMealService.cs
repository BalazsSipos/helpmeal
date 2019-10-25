<<<<<<< HEAD
﻿using helpmeal.Models;
using helpmeal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
=======
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using helpmeal.Models;
>>>>>>> cdf824a95907fba4a85e73bad1fe6ea2f068aebc

namespace helpmeal.Services.MealService
{
    public interface IMealService
    {
<<<<<<< HEAD
        Task<List<Meal>> GetMealListByCycleDayAndUserDayAsync(byte cycleDay, ClaimsPrincipal user);
        Task<DailyMealViewModel> BuildDailyMealViewModel(byte cycleDay, ClaimsPrincipal user, Meal newMeal);
        Task AddMeal(byte cycleDay, ClaimsPrincipal user, Meal newMeal);
    }
}
=======
        Task<List<Meal>> FindMealsByUserAsync(ClaimsPrincipal user);
    }
}
>>>>>>> cdf824a95907fba4a85e73bad1fe6ea2f068aebc
