using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<GithubAddress> GithubAddresses { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GithubAddress>(p =>
            {
                p.ToTable("GithubAddresses").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasOne(p => p.User);
            });
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<RefreshToken>(p =>
            {
                p.ToTable("RefreshTokens").HasKey(p => p.Id);
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.Token).HasColumnName("Token");
                p.Property(p => p.Expires).HasColumnName("Expires");
                p.Property(p => p.Created).HasColumnName("Created");
                p.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                p.Property(p => p.Revoked).HasColumnName("Revoked");
                p.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                p.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                p.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                p.HasOne(p => p.User);


            });

            modelBuilder.Entity<Technology>(p =>
            {
                p.ToTable("Technologies").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.Status).HasColumnName("Status");
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(p => p.User);
                p.HasOne(p => p.OperationClaim);
            });
        }
    }
}
