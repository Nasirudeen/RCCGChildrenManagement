using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RccgChildrenManagement.Models;

//using System.Data.Linq;
#nullable disable

namespace RccgChildrenManagement.Models
{
    public partial class RccgDbContext : DbContext
    {
        public RccgDbContext()
        {
        }

        public RccgDbContext(DbContextOptions<RccgDbContext> options)
            : base(options)
        {
        }
         
      
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Children> Childrens { get; set; }
          
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ResponsibleParty> ResponsiblePartys { get; set; }
            
        public virtual DbSet<User> Users { get; set; }
       
        public virtual DbSet<Otp> Otps { get; set; }
      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ChildrenApps;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.ToTable("AuditTrail");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.NewValue).HasMaxLength(50);

                entity.Property(e => e.IpAddress).HasMaxLength(50);
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.ObjectName).HasMaxLength(50);
                entity.Property(e => e.Created).HasColumnType("datetime");             

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");
                entity.Property(e => e.ParentCode).HasMaxLength(50);
                entity.Property(e => e.ChildrenCode).HasMaxLength(50);                
                entity.Property(e => e.EmailAddress).HasMaxLength(50);
               entity.Property(e => e.ChildrenId).HasMaxLength(50);
                
               
                entity.Property(e => e.QRImage).HasMaxLength(50);
                entity.Property(e => e.DroppedOff).HasMaxLength(50);
                entity.Property(e => e.PickedUp).HasMaxLength(50);
                entity.Property(e => e.isActive).HasMaxLength(50);            

                entity.Property(e => e.Created).HasColumnType("datetime");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });
            modelBuilder.Entity<Children>(entity =>
            {
                entity.ToTable("Children");
               // entity.Property(e => e.UserCode).HasMaxLength(50);
                entity.Property(e => e.ChildFirstName).HasMaxLength(50);
                entity.Property(e => e.ChildLastName).HasMaxLength(50);
              
                entity.Property(e => e.EmailAddress).HasMaxLength(50);
                //entity.Property(e => e.UserId).HasMaxLength(50);
                //entity.Property(e => e.DroppedOff).HasMaxLength(50);
                //entity.Property(e => e.PickedUp).HasMaxLength(50);
                entity.Property(e => e.DOB).HasMaxLength(50);
                entity.Property(e => e.Class).HasMaxLength(50);
                entity.Property(e => e.isActive).HasMaxLength(50);
                entity.Property(e => e.Created).HasColumnType("datetime");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });
           
           
            
           
            

            modelBuilder.Entity<ResponsibleParty>(entity =>
            {
                entity.ToTable("ResponsibleParty");
                entity.Property(e => e.EmailAddress).HasMaxLength(50);
                entity.Property(e => e.relfn).HasMaxLength(50);
                entity.Property(e => e.relln).HasMaxLength(50);
                entity.Property(e => e.RegistrationId).HasMaxLength(50);
                entity.Property(e => e.PersonType).HasMaxLength(50);
                entity.Property(e => e.relemail).HasMaxLength(50);
                entity.Property(e => e.relphonenumber).HasMaxLength(50);              

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });
            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("Otp");

                entity.Property(e => e.OtpCode).HasMaxLength(50);
                entity.Property(e => e.OtpUsed).HasMaxLength(50);
                
                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Updated).HasColumnType("datetime");
            });


          


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);
                entity.Property(e => e.EmailAddress).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(50);
              //  entity.Property(e => e.OldPassword).HasMaxLength(50);
             //  entity.Property(e => e.NewPassword).HasMaxLength(50);
               entity.Property(e => e.Kidnumber).HasMaxLength(50);
                entity.Property(e => e.Member_Visitor).HasMaxLength(50);
                entity.Property(e => e.RoleId).HasMaxLength(50);
                entity.Property(e => e.OtpUsed).HasMaxLength(50);
                entity.Property(e => e.Created).HasColumnType("datetime");
                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Updated).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
