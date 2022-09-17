using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.User
{
    public interface IUser
    {
        Task<ResponseModel> SignUp(UserModel usermodel);
        Task<ResponseModel> login(LoginModel loginmodel);


    }
}
