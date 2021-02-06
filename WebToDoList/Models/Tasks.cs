using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebToDoList.DataTasks
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public enum Priority
        {
            usual = 0,
            important = 1,
            unimportant = 2
        }
        public Priority priorities { get; set; }

        public bool IsCompleted { get; set; }
        
    }
}
