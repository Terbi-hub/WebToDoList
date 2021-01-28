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
                        priotities = Tasks.Priotity.important
                    },
                    new Tasks
                    {
                        Text = "Usual task",
                        priotities = Tasks.Priotity.usual
                    },
                    new Tasks
                    {
                        Text = "Unimportant task",
                        priotities = Tasks.Priotity.unimportant
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
