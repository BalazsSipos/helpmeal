using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace helpmeal.Models.RequestModels.UserSettingsRequest
{
    public class EditUserSettingsRequest
    {
        public byte NumberOfWeeksInCycle { get; set; }

        public class DaysOfShopping { }
    }

    public class DaysOfShopping
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

    }
}
