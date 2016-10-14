using DailyTaskMang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DailyTaskMang.Controllers
{
    public class CategoryController : ApiController
    {
        DataContext _db = new DataContext();

        [HttpGet]

        public List<Categories> CategoryList()
        {
            return _db.Categories.OrderBy(p => p.Id).ToList();
        }

        [HttpGet]
        public List<Categories> GetCategoryList(int id)
        {
            return _db.Categories.Where(p => p.FK_Tasks == id).OrderBy(p => p.Id).ToList();
        }

       [HttpPost]
        public IHttpActionResult CreateCategory(Categories model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Categories.Add(model);
            _db.SaveChanges();
            return Ok(model);
        }
    }
}
