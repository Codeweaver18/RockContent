using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockContent.DataAccessLayer.DbContexts
{
   public class AppDbContextFactory: IDesignTimeDbContextFactory<RockContentDbContext>
    {
        public RockContentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RockContentDbContext>();
            //TODO: This is very Insecure, sore this in Config or secrets vault
            optionsBuilder.UseSqlServer("Server=localhost;Database=RockContent;Persist Security Info=True;User ID=Rockcontent;Password=password;MultipleActiveResultSets=true");
            return new RockContentDbContext(optionsBuilder.Options);
        }
    }
}
