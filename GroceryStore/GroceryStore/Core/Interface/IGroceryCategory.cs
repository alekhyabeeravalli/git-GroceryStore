using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.User
{
   public interface IGroceryCategory
    {
        List<GroceryCategoryModel> GetGroceryCategory();
        GroceryCategoryModel AddGroceryCategory(GroceryCategoryModel groceryCategoryModel);
        GroceryCategoryModel UpdateGroceryCategory(GroceryCategoryModel groceryCategoryModel);
        GroceryCategoryModel DeleteGroceryCategory(int Id);
    }
}
