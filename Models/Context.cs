using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhatT1808A.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Context:DbContext
    {

        public Context() : base("name=MySQLContext")
        {
        }
        public DbSet<ClassLate> ClassLates { get; set; }
        public System.Data.Entity.DbSet<PhatT1808A.Models.Student> Students { get; set; }

    }
}