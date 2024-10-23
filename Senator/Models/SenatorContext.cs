using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Senator.Models
{

    public class SenatorContext : DbContext
    {
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public SenatorContext() : base("name=SenatorDBConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Soldier>()
                .HasRequired(s => s.Training) 
                .WithMany(t => t.Soldiers)
                .HasForeignKey(s => s.TrainingId)
                .WillCascadeOnDelete(false); 

            
            modelBuilder.Entity<Soldier>()
                .HasRequired(s => s.Country) 
                .WithMany(c => c.Soldiers)
                .HasForeignKey(s => s.CountryId)
                .WillCascadeOnDelete(false); 

            
            modelBuilder.Entity<Soldier>()
                .HasRequired(s => s.Rank) 
                .WithMany(r => r.Soldiers)
                .HasForeignKey(s => s.RankId)
                .WillCascadeOnDelete(false); 
        }
    }
}
