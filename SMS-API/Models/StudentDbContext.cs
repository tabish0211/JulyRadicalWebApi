using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;


namespace SMS_API.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext()
            :base("name=constr")
        {

        }

        public DbSet<Student> students { get; set; }
    }
}