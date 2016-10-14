using DailyTaskMang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DailyTaskMang.Controllers
{
    public class TaskController : ApiController
    {
        DataContext _db = new DataContext();

        [HttpGet]
        public List<Tasks> TaskList()
        {
            return _db.Tasks.OrderBy(p => p.Id).ToList();
        }

        [HttpGet]
        public List<Tasks> GetTaskList(int id)
        {
            return _db.Tasks.Where(p => p.FK_Categories == id).OrderBy(p => p.Id).ToList();
        }

        [HttpPost]
        public IHttpActionResult CreateTask(Tasks model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Tasks.Add(model);
            _db.SaveChanges();
            return Ok(model);
        }
    }
}
