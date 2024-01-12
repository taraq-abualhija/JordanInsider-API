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
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Touristsite> Touristsites { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userevent> Userevents { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;

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
                entity.HasNoKey();

                entity.ToTable("EVENT");

                entity.Property(e => e.Coordinatoorid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COORDINATOORID");

                entity.Property(e => e.Datestart)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DATESTART");

                entity.Property(e => e.Details)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DETAILS");

                entity.Property(e => e.Eventid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EVENTID");

                entity.Property(e => e.Image1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Validity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VALIDITY");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HISTORY");

                entity.Property(e => e.Historyid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HISTORYID");

                entity.Property(e => e.Touristsiteid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TOURISTSITEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REVIEW");

                entity.Property(e => e.Rating)
                    .HasColumnType("FLOAT")
                    .HasColumnName("RATING");

                entity.Property(e => e.Reviewdate)
                    .HasColumnType("DATE")
                    .HasColumnName("REVIEWDATE")
                    .HasDefaultValueSql("sysdate\n   ");

                entity.Property(e => e.Reviewid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEWID");

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
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

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
                entity.HasNoKey();

                entity.ToTable("TICKET");

                entity.Property(e => e.Eventid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EVENTID");

          

                entity.Property(e => e.Ticketid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TICKETID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<Touristsite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TOURISTSITE");

                entity.Property(e => e.Coordinatorid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COORDINATORID");

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

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tfrom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TFROM");

                entity.Property(e => e.Touristsiteid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TOURISTSITEID");

                entity.Property(e => e.Tto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TTO");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USERS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

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
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<Userevent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USEREVENT");

                entity.Property(e => e.Eventid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EVENTID");

                entity.Property(e => e.Usereventid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USEREVENTID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("FAVORITE");

                entity.Property(e => e.Favoriteid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FAVORITEID");

                entity.Property(e => e.Touristsiteid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TOURISTSITEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
