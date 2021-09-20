﻿using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers.Interfaces
{
    public interface IAuthorizeAttribute
    {
        bool OnAuthorization();
        void Authorization(string email);
        void LogoutAuthorization();
    }
}