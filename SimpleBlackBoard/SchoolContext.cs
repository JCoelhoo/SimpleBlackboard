using SimpleBlackBoard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleBlackBoard
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

    }
}