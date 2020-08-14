using KaryaMurniTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaryaMurniTask
{
    public interface ITaskToDoServices
    {
        string CreateTask(MstTask data);
        string UpdateTask(MstTask data);
        List<MstTask> GetData(string gettype, int Id = 0);
        string UpdateDone(MstTask data);
        string UpdatePercentage(MstTask data);
    }
}
