using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaryaMurniTask.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KaryaMurniTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskToDoServices tasksvc;

        public TaskController(ITaskToDoServices _ITaskSvc)
        {
            tasksvc = _ITaskSvc;
        }

        // GET: api/<TaskController>/GetAll
        //Get All To DO
        [HttpGet, Route("GetAll")]
        public IEnumerable<MstTask> GetAll()
        {
            return tasksvc.GetData("ALL");
        }

        //Get All To DO
        [HttpGet, Route("GetToday")]
        public IEnumerable<MstTask> GetToday()
        {
            return tasksvc.GetData("TODAY");
        }

        //Get All To DO
        [HttpGet, Route("GetNextDay")]
        public IEnumerable<MstTask> GetNextDay()
        {
            return tasksvc.GetData("NEXTDAY");
        }

        //Get All To DO
        [HttpGet, Route("GetWeek")]
        public IEnumerable<MstTask> GetWeek()
        {
            return tasksvc.GetData("CURRENTWEEK");
        }

        // GET api/<TaskController>/5
        //Get Spesific data
        [HttpGet, Route("GetRow")]
        public MstTask GetRow(int id)
        {
            return tasksvc.GetData("SPESIFIC",id).FirstOrDefault();
        }

        // POST api/<TaskController>
        //Create To Do
        [HttpPost, Route("CreateTask")]
        public void CreateTask([FromBody] MstTask value)
        {
            if (value.TaskTitle != "" && value.TaskDescription != "")
            {
                var trx = value;

                tasksvc.CreateTask(trx);
            }
        }

        //Update To Do
        [HttpPost, Route("UpdateTask")]
        public void UpdateTask([FromBody] MstTask value)
        {
            if (value.ID != 0)
            {
                var trx = value;

                tasksvc.UpdateTask(trx);
            }
        }

        // DELETE api/<TaskController>/5
        //Delete To Do
        [HttpGet, Route("DeleteTask")]
        public void Delete(int id)
        {
        }

        //Update Percentage
        [HttpPost, Route("UpdatePercentage")]
        public void UpdatePercentage([FromBody] MstTask value)
        {
            if (value.ID != 0)
            {
                var trx = value;

                tasksvc.UpdateTask(trx);
            }
        }

        //Update Status To Done
        [HttpPost, Route("UpdateDone")]
        public void UpdateDone([FromBody] MstTask value)
        {
            if (value.ID != 0)
            {
                var trx = value;

                tasksvc.UpdateTask(trx);
            }
        }
    }
}
