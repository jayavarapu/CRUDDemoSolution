using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDDemo.Models
{
    public class CrudContext:DbContext
    {
        public CrudContext():base("DemoAppContext")
        {
            Database.SetInitializer<CrudContext>(new DropCreateDatabaseIfModelChanges<CrudContext>());

        }
        public DbSet<Player> PlayerSet { get; set; }
    }
}