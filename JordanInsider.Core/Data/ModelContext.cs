using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JordanInsider.Core.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Touristsite> Touristsites { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=orcl)));User Id=jinsider;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JINSIDER")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("EVENT");

                entity.Property(e => e.Eventid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EVENTID");

                entity.Property(e => e.Datestart)
                    .HasColumnType("DATE")
                    .HasColumnName("DATESTART");

                entity.Property(e => e.Details)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DETAILS");

                entity.Property(e => e.Image1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Validity)
                    .HasColumnType("DATE")
                    .HasColumnName("VALIDITY");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("REVIEW");

                entity.Property(e => e.Reviewid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEWID");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RATING");

                entity.Property(e => e.Reviewtxt)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REVIEWTXT");

                entity.Property(e => e.Touristsiteid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TOURISTSITEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Touristsite)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Touristsiteid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_REVIEW_TOURISTSITEID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_REVIEW_USERID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("TICKET");

                entity.Property(e => e.Ticketid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TICKETID");

                entity.Property(e => e.Eventid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EVENTID");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Eventid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TICKET_EVENTID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TICKET_USERID");
            });

            modelBuilder.Entity<Touristsite>(entity =>
            {
                entity.ToTable("TOURISTSITE");

                entity.Property(e => e.Touristsiteid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TOURISTSITEID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Image1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE4");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            entity.Property(e => e.location)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("location");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
                entity.Property(e => e.Password)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUM");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USERS_ROLEID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
