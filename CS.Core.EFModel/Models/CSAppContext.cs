using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CS.Core.EFModel.Models
{
    public partial class CSAppContext : DbContext
    {
        public CSAppContext()
            : base("name=CSAppContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<RoleModulePermission> RoleModulePermissions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserUserRole> UserUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.AddressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.AddressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.AddressLine3)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.States)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.BrandName)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.BagSizeLength)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Job>()
                .Property(e => e.BagSizeWidth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Job>()
                .Property(e => e.BagWeight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Job>()
                .Property(e => e.Micron)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Job>()
                .Property(e => e.Rate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Job>()
                .Property(e => e.BagMaking)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.CuttingSize)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.SpecialInstruction)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.Module1)
                .WithOptional(e => e.Module2)
                .HasForeignKey(e => e.ParentModuleId);

            modelBuilder.Entity<Party>()
                .Property(e => e.PartyName)
                .IsUnicode(false);

            modelBuilder.Entity<Party>()
                .Property(e => e.GSTNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Party>()
                .Property(e => e.ContactNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Party>()
                .Property(e => e.AlternateContactNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Party>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Token>()
                .Property(e => e.AuthToken)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Jobs)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ChangedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Jobs1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Parties)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ChangedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Parties1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RoleModulePermissions)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ChangedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RoleModulePermissions1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tokens)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User1)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.ChangedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User11)
                .WithOptional(e => e.User3)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserDetails)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ChangedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserDetails1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ChangedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserUserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.ProfilePicture)
                .IsUnicode(false);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.ContactNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserDetail>()
                .Property(e => e.AlternateContactNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.UserRoleName)
                .IsUnicode(false);

            modelBuilder.Entity<UserRole>()
                .HasMany(e => e.UserUserRoles)
                .WithRequired(e => e.UserRole)
                .WillCascadeOnDelete(false);
        }
    }
}
