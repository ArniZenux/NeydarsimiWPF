using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.SQLite;
using Neydarsimi.Data;

namespace Neydarsimi.Helper
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() :
             base(new SQLiteConnection()
             {
                 ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "neydarsimi.db", ForeignKeys = true }.ConnectionString
             }, true)
        {

        }
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<>();
            base.OnModelCreating(modelBuilder);
        }*/

        public DbSet<neydarsimi> EmployeeMaster { get; set; }

    }
}
