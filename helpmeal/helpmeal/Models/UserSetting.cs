using helpmeal.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace helpmeal.Models
{
    public class UserSetting
    {
        public long UserSettingId { get; set; }
        public AppUser User { get; set; }
        public byte numberOfWeeksInCycle { get; set; }
    }
}
