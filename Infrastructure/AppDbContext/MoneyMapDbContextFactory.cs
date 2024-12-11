using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AppDbContext
{
    public class MoneyMapDbContextFactory : IDesignTimeDbContextFactory<MoneyMapDbContext>
    {
        public MoneyMapDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoneyMapDbContext>();
            optionsBuilder.UseSqlServer("Server=PEAGABOOK\\SQLEXPRESS;Database=MoneyMapDb;Trusted_Connection=True;Encrypt=False;"); 
            return new MoneyMapDbContext(optionsBuilder.Options);
        }
    }
}
