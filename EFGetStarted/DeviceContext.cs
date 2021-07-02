using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
   

   
        /*
         *Connecting to the database
         *Querying & Updating the database
         *Hold the Information needed to configure the database etc.
         */
        public class DeviceContext : DbContext
        {
            public DbSet<Device> Devices { get; set; }
            public DbSet<Part> Parts { get; set; }

            // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
            // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite(@"Data Source=e:\devices.db");
        }

        

    
    }

