using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Schemas;

namespace Models
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ED807>().HasKey(u => u.EDNo);
            modelBuilder.Entity<ED807BICDirectoryEntry>().HasKey(u => u.BIC);
            modelBuilder.Entity<ED807BICDirectoryEntryAccounts>().HasKey(t => t.Account);
            modelBuilder.Entity<ED807BICDirectoryEntryAccountsAccRstrList>().HasKey(t => t.AccRstr);
            modelBuilder.Entity<ED807BICDirectoryEntry>().Ignore(t => t.ParticipantInfo);
            modelBuilder.Entity<ED807BICDirectoryEntry>().Ignore(t => t.SWBICS);
            /*
            modelBuilder.Entity<ED807>().HasKey(u => u.EDNo);
            modelBuilder.Entity<ED807>().Ignore(u => u.BICDirectoryEntry);       
            */
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=50152;Database=postgres;Username=postgres;Password=postgrespw");
        }
    }
}
//xsd filename.xml  /c
//dotnet ef migrations add test000
//dotnet ef database update