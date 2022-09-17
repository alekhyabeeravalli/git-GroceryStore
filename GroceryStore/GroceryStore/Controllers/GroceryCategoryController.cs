using GroceryStore.Core.User;
using GroceryStore.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryCategoryController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IGroceryCategory _context;
        public GroceryCategoryController(IGroceryCategory _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> GetGroceryCategory()
        {
            try
            {
                log.Info("Data Successfull Displayed");
                var result = _context.GetGroceryCategory();
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddGroceryCategory(GroceryCategoryModel groceryCategoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.AddGroceryCategory(groceryCategoryModel);
                    log.Info("Created Successfully");
                    return StatusCode(200, "Created Successfully");
                }
                else
                {
                    log.Error("Something Went Wrong");
                    return BadRequest("Something Went Wrong");
                }
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGroceryCategory(GroceryCategoryModel groceryCategoryModel)
        {
            try
            {
                var result = _context.UpdateGroceryCategory(groceryCategoryModel);
                log.Info("Updated Successfully");
                return StatusCode(200, "Updated Successfully");
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGroceryCategory(int Id)
        {
            try
            {
                var result = _context.DeleteGroceryCategory(Id);
                log.Info("Deleted Successfully");
                return StatusCode(200, "Deleted Successfully");
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data to the Database");
            }
        }
    }
}
