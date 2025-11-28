using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebKinoPoisk.DB;

public partial class _1135KinopoiskContext : DbContext
{
    public _1135KinopoiskContext()
    {
    }

    public _1135KinopoiskContext(DbContextOptions<_1135KinopoiskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Content> Contents { get; set; }

    public virtual DbSet<ContentGerne> ContentGernes { get; set; }

    public virtual DbSet<FavoriteContentId> FavoriteContentIds { get; set; }

    public virtual DbSet<Gerne> Gernes { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Series> Series { get; set; }

    public virtual DbSet<TypeContent> TypeContents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WatchedContentId> WatchedContentIds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("userid=student;password=student;database=1135_kinopoisk;server=192.168.200.13", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Author");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Content");

            entity.HasIndex(e => e.IdAuthor, "FK_Content_IdAuthor");

            entity.HasIndex(e => e.IdTypeContent, "FK_Content_IdTypeContent");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Age).HasMaxLength(255);
            entity.Property(e => e.CountSeries).HasColumnType("int(11)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IdAuthor).HasColumnType("int(11)");
            entity.Property(e => e.IdTypeContent).HasColumnType("int(11)");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Contents)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_IdAuthor");

            entity.HasOne(d => d.IdTypeContentNavigation).WithMany(p => p.Contents)
                .HasForeignKey(d => d.IdTypeContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Content_IdTypeContent");
        });

        modelBuilder.Entity<ContentGerne>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ContentGerne");

            entity.HasIndex(e => e.IdContent, "FK_ContentGerne_IdContent");

            entity.HasIndex(e => e.IdGerne, "FK_ContentGerne_IdGerne");

            entity.Property(e => e.IdContent).HasColumnType("int(11)");
            entity.Property(e => e.IdGerne).HasColumnType("int(11)");

            entity.HasOne(d => d.IdContentNavigation).WithMany()
                .HasForeignKey(d => d.IdContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContentGerne_IdContent");

            entity.HasOne(d => d.IdGerneNavigation).WithMany()
                .HasForeignKey(d => d.IdGerne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContentGerne_IdGerne");
        });

        modelBuilder.Entity<FavoriteContentId>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.IdContent, "FK_FavoriteContentIds_IdContent");

            entity.HasIndex(e => e.IdUser, "FK_FavoriteContentIds_IdUser");

            entity.Property(e => e.IdContent).HasColumnType("int(11)");
            entity.Property(e => e.IdUser).HasColumnType("int(11)");

            entity.HasOne(d => d.IdContentNavigation).WithMany()
                .HasForeignKey(d => d.IdContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FavoriteContentIds_IdContent");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FavoriteContentIds_IdUser");
        });

        modelBuilder.Entity<Gerne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Gerne");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Rating");

            entity.HasIndex(e => e.IdContent, "FK_Rating_IdContent");

            entity.HasIndex(e => e.IdUser, "FK_Rating_IdUser");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Feedback).HasMaxLength(255);
            entity.Property(e => e.IdContent).HasColumnType("int(11)");
            entity.Property(e => e.IdUser).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.IdContentNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.IdContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_IdContent");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_IdUser");
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdContent, "FK_Series_IdContent");

            entity.HasIndex(e => e.IdRating, "FK_Series_IdRating");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IdContent).HasColumnType("int(11)");
            entity.Property(e => e.IdRating).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdContentNavigation).WithMany(p => p.Series)
                .HasForeignKey(d => d.IdContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Series_IdContent");

            entity.HasOne(d => d.IdRatingNavigation).WithMany(p => p.Series)
                .HasForeignKey(d => d.IdRating)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Series_IdRating");
        });

        modelBuilder.Entity<TypeContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TypeContent");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        modelBuilder.Entity<WatchedContentId>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.IdContent, "FK_WatchedContentIds_IdContent");

            entity.HasIndex(e => e.IdUser, "FK_WatchedContentIds_IdUser");

            entity.Property(e => e.IdContent).HasColumnType("int(11)");
            entity.Property(e => e.IdUser).HasColumnType("int(11)");

            entity.HasOne(d => d.IdContentNavigation).WithMany()
                .HasForeignKey(d => d.IdContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WatchedContentIds_IdContent");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WatchedContentIds_IdUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
