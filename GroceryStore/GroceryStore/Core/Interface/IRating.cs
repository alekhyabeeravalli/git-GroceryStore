using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Core.Interface
{
    public  interface IRating
    {
        List<RatingModel> GetRating();
        RatingModel AddRating(RatingModel ratingModel);
        RatingModel UpdateRating(RatingModel ratingModel);
        RatingModel DeleteRating(int Id);
    }
    
   
}
