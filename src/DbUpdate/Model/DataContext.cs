using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbUpdate.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<SQLConfig> SQLConfigs { get; set; }
        public DbSet<SQLScript> SQLScripts { get; set; }
        public DbSet<SQLBuild> SQLBuilds { get; set; }
    }
}
