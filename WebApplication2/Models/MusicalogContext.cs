﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class MusicalogContext : DbContext
{
    public MusicalogContext()
    {
    }

    public MusicalogContext(DbContextOptions<MusicalogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<AlbumType> AlbumTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=luistomarsql.database.windows.net,1433; Initial Catalog = Musicalog; Persist Security Info = True; User ID = MusicalogDBUser; Password =DBUser#123!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Album_ID);

            entity.ToTable("Album");

            entity.Property(e => e.Album_ArtistName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Album_Title)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Album_Type).WithMany(p => p.Albums)
                .HasForeignKey(d => d.Album_TypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Album_AlbumType");
        });

        modelBuilder.Entity<AlbumType>(entity =>
        {
            entity.HasKey(e => e.Album_TypeID);

            entity.ToTable("AlbumType");

            entity.Property(e => e.Album_TypeDesc)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}