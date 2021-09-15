﻿using backend.Managers;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IAccountService
    {
        Task<ActionResult> SignUp(bool isValid, SignUpUser modelUser);
        Task<ActionResult> SignIn(bool isValid, SignInUser modelUser);
        Task<ActionResult> Logout();
        Task<UserProfile> GetUserCredentilas(ClaimsPrincipal user);
        AppUser GetUser(string id);
        bool UserIsAuthorized();
        Task<ActionResult> ConfirmEmail(string token, string email);
        Task<ActionResult> UpdateUser(ClaimsPrincipal claimsPrincipal, UserProfile userProfile);
    }
}
