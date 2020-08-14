using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using KaryaMurniTask.Helper;
using KaryaMurniTask.Models;

namespace KaryaMurniTask
{
    public class TaskToDoServices : ITaskToDoServices
    {
        SQLHelper sqlh;

        private string spProcess = "exec uspProcessMstTask ";
        private string spGetData = "exec uspVwGetTask ";

        public TaskToDoServices(SQLHelper SqlHelper)
        {
            this.sqlh = SqlHelper;
            this.sqlh.switchConnection("1");
        }

        public string CreateTask(MstTask data)
        {
            try
            {
                var ExpressinSQL = spProcess;

                ExpressinSQL += "'CREATE','" + data.TaskTitle + "','" + data.TaskDescription + "'," + data.Progress;
                ExpressinSQL += ",'" + data.ExpiredDate.ToString() + "'";

                var rst = sqlh.Execute(ExpressinSQL);
                sqlh.Dispose();
                return "Success To Create Task With ID = " + rst["ID"];
            }
            catch (Exception ex)
            {
                sqlh.Dispose();
                return ex.Message;
            }
        }

        public string UpdateTask(MstTask data)
        {
            try
            {
                var ExpressinSQL = spProcess;

                ExpressinSQL += "'UPDATE','" + data.TaskTitle + "','" + data.TaskDescription + "'," + data.Progress;
                ExpressinSQL += ",'" + data.ExpiredDate.ToString() + "'," + data.ID;

                var rst = sqlh.Execute(ExpressinSQL);
                sqlh.Dispose();
                return "Success To Update Task ID = " + rst["ID"];
            }
            catch (Exception ex)
            {
                sqlh.Dispose();
                return ex.Message;
            }
        }

        public List<MstTask> GetData(string gettype,int Id = 0)
        {
            List<MstTask> rst = new List<MstTask>();

            try
            {
                var ExpressinSQL = spGetData;

                ExpressinSQL += "'" + gettype + "'," + Id.ToString();

                var dr = sqlh.Execute(ExpressinSQL);

                while (dr.Read())
                {
                    rst.Add(new MstTask()
                    {
                        TaskTitle = dr["TaskTitle"].ToString(),
                        TaskDescription = dr["TaskDescription"].ToString(),
                        Progress = decimal.Parse(dr["Progress"].ToString()),
                        ExpiredDate = DateTime.Parse(dr["ExpiredDate"].ToString()),
                        ID = Int32.Parse(dr["ID"].ToString()),
                    });
                }

                sqlh.Dispose();
                return rst;
            }
            catch (Exception ex)
            {
                rst.Add(new MstTask()
                {
                    TaskTitle = ex.Message
                });
                sqlh.Dispose();
                return rst;
            }
        }

        public string UpdatePercentage(MstTask data)
        {
            try
            {
                var ExpressinSQL = spProcess;

                ExpressinSQL += "'PCT','" + data.TaskTitle + "','" + data.TaskDescription + "'," + data.Progress;
                ExpressinSQL += ",'" + data.ExpiredDate.ToString() + "'," + data.ID;

                var rst = sqlh.Execute(ExpressinSQL);
                sqlh.Dispose();
                return "Success To Update Task ID = " + rst["ID"];
            }
            catch (Exception ex)
            {
                sqlh.Dispose();
                return ex.Message;
            }
        }

        public string UpdateDone(MstTask data)
        {
            try
            {
                var ExpressinSQL = spProcess;

                ExpressinSQL += "'DONE','" + data.TaskTitle + "','" + data.TaskDescription + "'," + data.Progress;
                ExpressinSQL += ",'" + data.ExpiredDate.ToString() + "'," + data.ID;

                var rst = sqlh.Execute(ExpressinSQL);
                sqlh.Dispose();
                return "Success To Update Task ID = " + rst["ID"];
            }
            catch (Exception ex)
            {
                sqlh.Dispose();
                return ex.Message;
            }
        }
    }
}
