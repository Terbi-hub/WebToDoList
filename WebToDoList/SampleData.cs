using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebToDoList.DataTasks;

namespace WebToDoList
{
    public static class SampleData
    {
        public static void Initialize(TaskContext context)
        {
            if(!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new Tasks
                    {
                        Text = "Important task",
                        priorities = Tasks.Priority.important
                    },
                    new Tasks
                    {
                        Text = "Usual task",
                        priorities = Tasks.Priority.usual
                    },
                    new Tasks
                    {
                        Text = "Unimportant task",
                        priorities = Tasks.Priority.unimportant
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
