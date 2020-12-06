using System;
using System.Collections.Generic;
using System.Text;
using RockContent.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace RockContent.DataAccessLayer.DbContexts
{
   public class RockContentDbContext:DbContext
    {
        public RockContentDbContext(DbContextOptions<RockContentDbContext> options)
             : base(options)
        {
            Database.Migrate();
        }

        public DbSet<PostLikes> PostLikes { get; set; }

    }
}
