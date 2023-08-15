using EMS.Core.IRepo;
using EMS.Data.Helper;
using EMS.Data.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Repo
{
    public class AccountRepo : IAccountRepo
    {//managing user-related operations like creating, updating, and deleting users.
        private readonly UserManager<IdentityUser> _userManager;
        //managing user sign-in operations, like handling cookies and tokens for user authentication.
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountRepo(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<DataResult> LoginAsync(LoginVM model)
        {
            DataResult result = new DataResult();
            var user = await _userManager.FindByEmailAsync(model.Email);
            SignInResult signInResult = await signInManager.PasswordSignInAsync(user.UserName, model.Password, false, lockoutOnFailure: true);
            //Get the matched email user details
            if(signInResult.Succeeded)
            {
                result.IsSuccess = true;
                result.Message = "User Login Success";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Email Or Password InValid";
            }
            return result;
        }

        public Task<DataResult> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult> RegisterAsync(RegisterVM model)
        {
            DataResult result = new DataResult();
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };
            var response = await _userManager.CreateAsync(user, model.Password);
            if (response.Succeeded)
            {
                result.IsSuccess = true;
                result.Message = "User Created";
            }
            else{
                result.IsSuccess = false;
                result.Message = "Couldn't Register a New User";
            }
            return result;
        }
    }
}
