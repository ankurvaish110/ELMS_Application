using AuthJWT.Model;
using AuthJWT.Repository.Interface;
using AuthJWT.Repository.Services;
using LMSAPI.DAL;
using LMSAPI.Models;
using LMSAPI.Repository.Interface;
using LMSAPI.Repository.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace LMSAPI.Controllers
{
    [ApiController]
    [Route("api/v1/elms/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUser _userRepo;
        private readonly IAuthManager _authManager;
        #region Constructor
        public UserController(ILogger<UserController> logger, IUser userRepo, IAuthManager authManager)
        {
            _logger = logger;
            _userRepo = userRepo;
            _authManager = authManager;
        }
        #endregion

        /// <summary>
        /// User will Signup
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Success message</returns>
        [HttpPost]
        [AllowAnonymous]
        public string Signup(User user)
        {
            _logger.LogInformation("Inside Signup method");
            string result = string.Empty;
            try
            {
                user.Password = Helpers.Helper.GetHash(user.Password);
                if (_userRepo.Signup(user))
                    result= "User added successfully";
                else
                    result= "User registration failed";
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }
            return result;
        }

        /// <summary>
        /// User will signin
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>User entity</returns>
        [HttpPost]
        [AllowAnonymous]
        public string Signin(string userName, string password)
        {
            _logger.LogInformation("Inside Signin method");
            string result = string.Empty;
            try
            {
                var hashPassword = Helpers.Helper.GetHash(password);
                var user = _userRepo.UserLogin(userName, hashPassword);
                if (user == null)
                {
                    result= "Unauthorize";
                }
                else
                {
                    result = _authManager.Authenticate(user.Role,user.UserName);
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }
            return result;
        }
    }
}
