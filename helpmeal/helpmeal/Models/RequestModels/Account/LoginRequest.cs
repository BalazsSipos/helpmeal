using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpmeal.Models.RequestModels.Account
{
    public class LoginRequest
    {
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
