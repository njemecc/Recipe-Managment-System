﻿using RMS.Application.Common.Exceptions;
using RMS.Application.Common.Interfaces;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.Identity;

public class UserService(ApplicationUserManager userManager): IUserService
{
    public async Task CreateUserAsync(string emailAddress, string firstName,string lastName,string password,List<string> roles)
    {
        var alreadyExist = await userManager.FindByEmailAsync(emailAddress);
        
        if (alreadyExist != null)
            return;

        var user = new ApplicationUser(firstName, lastName, emailAddress, password);

        try
        {
            var result = await userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new AuthException("Could not create a new user",
                    new { Errors = result.Errors.ToList() });
            }

            var rolesResult = await userManager.AddToRolesAsync(user,
                roles.Select(nr => nr.ToUpper()));

            if (!rolesResult.Succeeded)
            {
                await userManager.DeleteAsync(user);

                throw new AuthException("Could not add roles to user",
                    new { Errors = rolesResult.Errors.ToList() });
            }
        }
        catch (Exception e)
        {
            await userManager.DeleteAsync(user);

            throw new AuthException("Could not create a new user",
                e);
        }
    }
    
    public Task<ApplicationUser?> GetUserAsync(string id) => userManager.FindByIdAsync(id);
    public Task<ApplicationUser?> GetUserByEmailAsync(string id) => userManager.FindByEmailAsync(id);
    public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName) => userManager.IsInRoleAsync(user,
        roleName);
}