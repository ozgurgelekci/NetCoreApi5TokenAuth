﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace NetCoreApi5TokenAuth.Service.Services
{
    public static class SignService
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
