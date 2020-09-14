using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaleApi.Common;
using SaleApi.Log;
using SaleApi.Models;

namespace SaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        public UserProfileController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor; ;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            //Logger.LogError();
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName,
                user.PhoneNumber
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        public string GetForCustomer()
        {
            return "Web method for Customer";
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        [Route("ForAdminOrCustomer")]
        public string GetForAdminOrCustomer()
        {
            return "Web method for Customer";
        }
    }
}
