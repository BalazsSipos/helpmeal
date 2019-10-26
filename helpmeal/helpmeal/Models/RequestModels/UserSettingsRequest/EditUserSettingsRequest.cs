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

        public List<byte> DaysOfShopping { get; set; }
    }
}
