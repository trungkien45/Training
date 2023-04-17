using Training.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Training.Entities
{
    public class TrainingDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public TrainingDbContext(IConfiguration configurTrainingion, DbContextOptions options) : base(options)
        {
            Configuration = configurTrainingion;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var key = Convert.FromBase64String(Configuration["EncryptionKey"]);
            modelBuilder.Entity<Account>().HasKey(a=>a.Id);
            modelBuilder.Entity<Account>().HasAlternateKey(a=>a.Username);
            modelBuilder.Entity<Account>().HasAlternateKey(a => a.Email);
            modelBuilder.Entity<Account>().HasAlternateKey(a => a.Phone);
            modelBuilder.Entity<Account>().Property(a => a.Balance).IsRequired();
            modelBuilder.Entity<Account>().Property(a => a.Birthday).IsRequired();
            modelBuilder.Entity<Account>().Property(a => a.FullName).IsRequired();
            modelBuilder.Entity<Account>().HasData(new Account { Balance = 0, Birthday = DateTime.Now, Email="admin@admin.com", FullName="Admin", Id = 2, Password= AesAlgorithm.AesEncryptString("kien", key), Phone="089", Username = "admin" });

            modelBuilder.Entity<Grade>().HasKey(g => g.GradeId);
            modelBuilder.Entity<Student>().HasKey(s => s.StudentID);


        }
    }
}
