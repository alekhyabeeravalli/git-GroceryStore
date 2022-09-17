using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.User
{
    public interface IGroceryItems
    {
        List<GroceryItemModel> GetGroceryItems();
        GroceryItemModel AddGrocery(GroceryItemModel groceryItemModel);
        GroceryItemModel UpdateGrocery(GroceryItemModel groceryItemModel);
        GroceryItemModel DeleteGrocery(int Id);
    }
}
