using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleBlackBoard.Models
{
    public class Roles
    {
        public int Role_ID { get; set; }
        public String Role_Description { get; set; }
    }
    public class RolesContext : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
    }
}