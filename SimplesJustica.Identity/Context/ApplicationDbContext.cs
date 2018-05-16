using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimplesJustica.Identity.Entities;

namespace SimplesJustica.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, ExternalLogin, UserRoles, Claim>
    {
        public ApplicationDbContext()
            : base("IdentityConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<ExternalLogin>().ToTable("ExternalLogins");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRoles>().ToTable("UserRoles");
            modelBuilder.Entity<Claim>().ToTable("Claims");
        }
    }
}