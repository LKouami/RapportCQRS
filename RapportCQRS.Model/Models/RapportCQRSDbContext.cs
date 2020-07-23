using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RapportCQRS.Model.Models
{
    public partial class RapportCQRSDbContext : DbContext
    {
        public RapportCQRSDbContext()
        {
        }

        public RapportCQRSDbContext(DbContextOptions<RapportCQRSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AClaim> AClaim { get; set; }
        public virtual DbSet<AConnections> AConnections { get; set; }
        public virtual DbSet<ARole> ARole { get; set; }
        public virtual DbSet<ARoleClaim> ARoleClaim { get; set; }
        public virtual DbSet<AUser> AUser { get; set; }
        public virtual DbSet<AUserClaim> AUserClaim { get; set; }
        public virtual DbSet<AUserRole> AUserRole { get; set; }
        public virtual DbSet<SActivity> SActivity { get; set; }
        public virtual DbSet<STimeTable> STimeTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RapportData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AClaim>(entity =>
            {
                entity.ToTable("A_Claim");

                entity.HasIndex(e => e.Name)
                    .HasName("Uk_A_Claim")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AConnections>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("A_Connections");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<ARole>(entity =>
            {
                entity.ToTable("A_Role");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ARoleClaim>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.ClaimId })
                    .HasName("Pk_A_RoleClaim");

                entity.ToTable("A_RoleClaim");

                entity.Property(e => e.ClaimValue)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<AUser>(entity =>
            {
                entity.ToTable("A_User");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Token).HasMaxLength(200);
            });

            modelBuilder.Entity<AUserClaim>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ClaimId })
                    .HasName("Pk_A_UserClaim");

                entity.ToTable("A_UserClaim");

                entity.Property(e => e.ClaimValue)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<AUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("Pk_A_UserRole");

                entity.ToTable("A_UserRole");
            });

            modelBuilder.Entity<SActivity>(entity =>
            {
                entity.ToTable("S_Activity");

                entity.Property(e => e.ContenuAct)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");
            });

            modelBuilder.Entity<STimeTable>(entity =>
            {
                entity.ToTable("S_TimeTable");

                entity.Property(e => e.CreatedAt).HasColumnName("Created_At");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.DeletedAt).HasColumnName("Deleted_At");

                entity.Property(e => e.DeletedBy).HasColumnName("Deleted_By");

                entity.Property(e => e.ModifiedAt).HasColumnName("Modified_At");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
