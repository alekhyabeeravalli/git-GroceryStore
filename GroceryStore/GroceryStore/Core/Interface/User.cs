using GroceryStore.DataAccess;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.User
{
    public class User : IUser
    {
        private readonly GroceryStoreDbContext _context;
        public User(GroceryStoreDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel> login(LoginModel loginmodel)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> SignUp(UserModel usermodel)
        {
            try
            {
                var res = _context.users.Add(usermodel);
                await _context.SaveChangesAsync();
                if(res != null)
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Message = "Registration Successfull";
                    return responseModel;
                }
                else
                {
                    throw new Exception("Registration Failed");
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
