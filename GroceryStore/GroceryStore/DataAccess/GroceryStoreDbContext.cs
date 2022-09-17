using GroceryStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.DataAccess
{
    public class GroceryStoreDbContext : DbContext
    {
        public GroceryStoreDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserModel> users { get; set; }
        public DbSet<RoleModel> roles { get; set; }
        public DbSet<GroceryCategoryModel> groceryCategoryModel { get; set; }
        public DbSet<GroceryItemModel> groceryItemModel { get; set; }
        public DbSet<OrderModel> orderModel { get; set; }
        public DbSet<RatingModel> ratingModel { get; set; }
    }
}
