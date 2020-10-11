using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManger;
        public AccountRepository(UserManager<ApplicationUser> userManger,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManger = userManger;
            _signInManger = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result = await _userManger.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            //This method is used for Login which takes Username, Password,cookie ,Loackout as parameter
            var result = await _signInManger.PasswordSignInAsync(signInModel.Email, 
                signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManger.SignOutAsync();
        }
    }
}
