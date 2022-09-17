using GroceryStore.DataAccess;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.Repository
{
    public class Rating
    {
        private readonly GroceryStoreDbContext _context;
        public Rating(GroceryStoreDbContext _context)
        {
            this._context = _context;
        }
        public List<RatingModel> GetRating()
        {
            try
            {
                var result = _context.ratingModel.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public RatingModel AddRating(RatingModel ratingModel)
        {
            try
            {
                _context.ratingModel.AddAsync(ratingModel);
                _context.SaveChangesAsync();
                return ratingModel;
            }
            catch (Exception ex) { throw ex; }
        }
        public RatingModel UpdateRating(RatingModel ratingModel)
        {
            var result = _context.ratingModel.FirstOrDefault(x => x.Id == ratingModel.Id);
            if (result != null)
            {
                result.GroceryName = ratingModel.GroceryName;
                
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public RatingModel DeleteRating(int id)
        {
            try
            {
                var result = _context.ratingModel.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    _context.ratingModel.Remove(result);
                    _context.SaveChanges();
                }
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}

