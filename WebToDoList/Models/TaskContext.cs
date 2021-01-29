using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebToDoList.DataTasks
{
    public class TaskContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
