using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaryaMurniTask.Models
{
    public class MstTask
    {
        public int ID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public decimal Progress { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
