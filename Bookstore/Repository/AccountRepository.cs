using Bookstore.Models;
using Bookstore.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        public AccountRepository(UserManager<ApplicationUser> userManger,
            SignInManager<ApplicationUser> signInManager,
            IUserService userService,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _userManger = userManger;
            _signInManger = signInManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
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
            if(result.Succeeded)
            {
                var token = await _userManger.GenerateEmailConfirmationTokenAsync(user);
                if(!string.IsNullOrEmpty(token))
                {
                    await SendEmailConfirmation(user, token);
                }
            }
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

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePassword)
        {
            var userId = _userService.GetUserId();
            var user = await _userManger.FindByIdAsync(userId);
            return await _userManger.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
        }
        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
            return await _userManger.ConfirmEmailAsync(await _userManger.FindByIdAsync(uid), token);
        }

        private async Task SendEmailConfirmation(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("AppDomain").Value;
            string confirmationLink = _configuration.GetSection("EmailConfirmation").Value;
            UserEmailOptions userEmailOptions = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{Username}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };
            await _emailService.SendEmailConfirmation(userEmailOptions);
        }
    }
}
