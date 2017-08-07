using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace websites
{
    public partial class AlexwilkinsonContext : DbContext
    {
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<BlogPost> BlogPost { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }


        public AlexwilkinsonContext(DbContextOptions<AlexwilkinsonContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.HasIndex(e => e.Authoremail)
                    .HasName("authoremail_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Authorusername)
                    .HasName("authorusername_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Authorid)
                    .HasColumnName("authorid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Authoractive)
                    .HasColumnName("authoractive")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Authoremail)
                    .IsRequired()
                    .HasColumnName("authoremail")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Authorfirstname)
                    .HasColumnName("authorfirstname")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Authorlastname)
                    .HasColumnName("authorlastname")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Authorpassword)
                    .IsRequired()
                    .HasColumnName("authorpassword")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Authorusername)
                    .IsRequired()
                    .HasColumnName("authorusername")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.ToTable("blog_post");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("blog_post_4f331e2f");

                entity.HasIndex(e => e.Slug)
                    .HasName("sqlite_autoindex_blog_post_1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body");

                entity.Property(e => e.CoverImg)
                    .IsRequired()
                    .HasColumnName("cover_img")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date");

                entity.Property(e => e.Draft)
                    .IsRequired()
                    .HasColumnName("draft");

                entity.Property(e => e.LastModified).HasColumnName("last_modified");

                entity.Property(e => e.Publish)
                    .IsRequired()
                    .HasColumnName("publish");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(140)");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.ToTable("portfolio");

                entity.Property(e => e.Portfolioid)
                    .HasColumnName("portfolioid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Portfolioauthorid)
                    .HasColumnName("portfolioauthorid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Portfoliobody)
                    .HasColumnName("portfoliobody")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Portfoliodate).HasColumnName("portfoliodate");

                entity.Property(e => e.Portfoliodraft)
                    .HasColumnName("portfoliodraft")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Portfoliofeaturedimage)
                    .HasColumnName("portfoliofeaturedimage")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Portfoliolastmodified).HasColumnName("portfoliolastmodified");

                entity.Property(e => e.Portfoliopublished)
                    .HasColumnName("portfoliopublished")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Portfolioslug)
                    .HasColumnName("portfolioslug")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Portfoliotitle)
                    .HasColumnName("portfoliotitle")
                    .HasColumnType("varchar(45)");
            });
        }
    }
}