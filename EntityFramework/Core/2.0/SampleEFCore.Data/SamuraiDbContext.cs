using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SampleEF.Domain;

namespace SampleEFCore.Data
{
    public class SamuraiDbContext : DbContext
    {

        private static readonly LoggerFactory consoleLoggerFactory = new LoggerFactory(new ILoggerProvider[]
        {
            new ConsoleLoggerProvider((category, level) => category==DbLoggerCategory.Database.Command.Name && level== LogLevel.Information,true ),

        });


        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattle> SamuraiBattles { get; set; }
        public DbSet<SamuraiLivingDetail> SamuraiLivingDetails { get; set; }
        public DbSet<SamuraiLiving> SamuraiLivings { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(consoleLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(
                "server=LAPTOP-1SVQJBT6\\SQLEXPRESS;database=ef2_0_samuraiTest1;trusted_connection=true",
                opts => opts.MaxBatchSize(150));



            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setup composite key 
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(sb => new { sb.BattleId, sb.SamuraiId });

            modelBuilder.Entity<SamuraiLivingDetail>().HasKey(s => s.LivingId);

            modelBuilder.Entity<SamuraiLiving>(b =>
            {
                b.HasKey(x => new { x.LivingId, x.SamuraiId });
                
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
