﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ReptileAPI.Authentication;
using ReptileAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReptileAPI.Data
{
    public interface IDbInitializer
    {
        void Initialize();
    }

    public class DbInitializer : IDbInitializer
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(IConfiguration configuration, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            string superadminEmail = _configuration.GetValue<string>("SuperUser:Email");
            string superadminUsername = _configuration.GetValue<string>("SuperUser:Username");
            string superadminPassword = _configuration.GetValue<string>("SuperUser:Password");
            string superadminDefaultRole = _configuration.GetValue<string>("SuperUser:Role");
#nullable enable
            ApplicationUser? user = _userManager.FindByEmailAsync(superadminEmail).Result;
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = superadminUsername,
                    Email = superadminEmail,
                    EmailConfirmed = true
                };
                _ = _userManager.CreateAsync(user, superadminPassword).Result;
            }

            IdentityRole? role = _roleManager.FindByNameAsync(superadminDefaultRole).Result;
#nullable disable

            if (role == null)
            {
                role = new IdentityRole
                {
                    Name = superadminDefaultRole
                };
                _ = _roleManager.CreateAsync(role).Result;
            }

            if (!_userManager.GetRolesAsync(user).Result.Contains(superadminDefaultRole))
            {
                _ = _userManager.AddToRoleAsync(user, superadminDefaultRole).Result;
            }
        }
    }
}
