using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Daily_task
    {
        public int Daily_taskId { get; set; }

        public string taskName { get; set; }

        public DateTime timecreat { get; set; }

        public DateTime timeclose
        {
            get; set;
        }
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }
        
    }
}


