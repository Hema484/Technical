using Microsoft.EntityFrameworkCore;
using Test11.Models;

namespace Test11.Context
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext>options):base(options)
        {

        }
        public DbSet<Node> Node { get; set; }
        public DbSet<Edges> Edges { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<Customers> Customers { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
           
        }

    }
}

