using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples.Data
{
    public class CustomerNorthWindContext : NorthwindContext
    {
        public DbSet<ProductModel> ProductModels { get; set; }
        public CustomerNorthWindContext()
        {
        }

        public CustomerNorthWindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductModel>(a => a.HasNoKey());
        }
    }
}
