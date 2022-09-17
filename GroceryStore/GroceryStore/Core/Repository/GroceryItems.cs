using GroceryStore.Core.User;
using GroceryStore.DataAccess;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.Repository
{
    public class GroceryItems : IGroceryItems
    {
        private readonly GroceryStoreDbContext _context;
        public GroceryItems(GroceryStoreDbContext _context)
        {
            this._context = _context;
        }
        public List<GroceryItemModel> GetGroceryItems()
        {
            try
            {
                var result = _context.groceryItemModel.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
      
        public GroceryItemModel AddGrocery(GroceryItemModel groceryItemsModel)
        {
            try
            {
                _context.groceryItemModel.AddAsync(groceryItemsModel);
                _context.SaveChangesAsync();
                return groceryItemsModel;
            }
            catch (Exception ex) { throw ex; }
        }
        public GroceryItemModel UpdateGrocery(GroceryItemModel groceryItemsModel)
        {
            var result = _context.groceryItemModel.FirstOrDefault(x => x.Id == groceryItemsModel.Id);
            if (result != null)
            {
                result.ItemName = groceryItemsModel.ItemName;
                result.Price = groceryItemsModel.Price;
                result.Quantity = groceryItemsModel.Quantity;
                result.CategoryId = groceryItemsModel.CategoryId;
                result.Category = groceryItemsModel.Category;
                
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public GroceryItemModel DeleteGrocery(int groceryId)
        {
            try
            {
                var result = _context.groceryItemModel.FirstOrDefault(x => x.Id == groceryId);
                if (result != null)
                {
                    _context.groceryItemModel.Remove(result);
                    _context.SaveChanges();
                }
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
