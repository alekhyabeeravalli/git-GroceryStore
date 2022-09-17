using GroceryStore.Core.User;
using GroceryStore.DataAccess;
using GroceryStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GroceryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GroceryStoreDbContext _context;
        private readonly IUser user;

        public string Role { get; private set; }

        public UserController( GroceryStoreDbContext context, IUser user)
        {
           _context = context;
            this.user = user;
        }
        [HttpPost]
        [Route("Registration")]

        public async Task<ActionResult<ResponseModel>> SignUp([FromBody] UserModel usermodel)
        {
            try
            {
                var response = await user.SignUp(usermodel);
                return response;
            }
            catch(Exception ex)
            {
                ResponseModel response = new ResponseModel();
                response.Message = ex.Message;
                return response;
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginmodel)
        {
            try
            {
                var user = await _context.users.Where(i => i.UserName == loginmodel.UserName
                            && i.Password == loginmodel.Password).Include(i => i.Role).FirstOrDefaultAsync();

                if(user == null)
                {
                    throw new Exception("Invalid Credentials");
                }
                var claims = new List<Claim>
                {
                    new Claim(type: ClaimTypes.Name, value:user?.UserName),
                    new Claim(type: ClaimTypes.Role, value:user?.Role?.RoleName)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return Ok("Login Successfull");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
