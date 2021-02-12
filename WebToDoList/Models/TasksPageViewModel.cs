using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebToDoList.DataTasks;

namespace WebToDoList.Models
{
    public class TasksPageViewModel
    {
        public IEnumerable<Tasks> Tasks { get; set; }

        public string PageTitle { get; set; }
    }
}
