﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBModels.Models
{
    public partial class YVFlashCardContext : DbContext
    {
        public YVFlashCardContext()
        {
        }

        public YVFlashCardContext(DbContextOptions<YVFlashCardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<ForgetWords> ForgetWords { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<SpeechParts> SpeechParts { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Synonyms> Synonyms { get; set; }
        public virtual DbSet<Themes> Themes { get; set; }
        public virtual DbSet<UserInfos> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Accounts__C9F284575CDF9DD5");

                entity.Property(e => e.UserName)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PassWord)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('R')");
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.HasKey(e => e.WordId)
                    .HasName("PK__Dictiona__2C20F04629886DC0");

                entity.Property(e => e.WordId).HasColumnName("WordID");

                entity.Property(e => e.Author)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mean).IsUnicode(false);

                entity.Property(e => e.SpeechPart)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ThemeId).HasColumnName("ThemeID");

                entity.Property(e => e.WordText).IsUnicode(false);

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Dictionary)
                    .HasForeignKey(d => d.Author)
                    .HasConstraintName("FK_Dic_Acc");

                entity.HasOne(d => d.SpeechPartNavigation)
                    .WithMany(p => p.Dictionary)
                    .HasForeignKey(d => d.SpeechPart)
                    .HasConstraintName("FK_Dic_SpeechParts");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Dictionary)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_Dic_Themes");
            });

            modelBuilder.Entity<ForgetWords>(entity =>
            {
                entity.HasKey(e => e.ForgetWordId)
                    .HasName("PK__ForgetWo__489DD9A270C627F1");

                entity.Property(e => e.ForgetWordId).HasColumnName("ForgetWordID");

                entity.Property(e => e.StudyId).HasColumnName("StudyID");

                entity.Property(e => e.WordId).HasColumnName("WordID");

                entity.HasOne(d => d.Study)
                    .WithMany(p => p.ForgetWords)
                    .HasForeignKey(d => d.StudyId)
                    .HasConstraintName("FK_Forget_Study");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.ForgetWords)
                    .HasForeignKey(d => d.WordId)
                    .HasConstraintName("FK_Forget_Word");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Setting__737584F797081D4E");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<SpeechParts>(entity =>
            {
                entity.HasKey(e => e.SpeechPartName)
                    .HasName("PK__SpeechPa__B4865E60C76100B9");

                entity.Property(e => e.SpeechPartName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mean).IsUnicode(false);
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.StudyId)
                    .HasName("PK__Studies__1B4BFBF8E8D6242B");

                entity.Property(e => e.StudyId).HasColumnName("StudyID");

                entity.Property(e => e.ThemeId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ThemeID")
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.Studies)
                    .HasForeignKey(d => d.UserName)
                    .HasConstraintName("FK_Study_User");
            });

            modelBuilder.Entity<Synonyms>(entity =>
            {
                entity.HasKey(e => e.SynonymId)
                    .HasName("PK__Synonyms__066F63A3B22738C4");

                entity.Property(e => e.SynonymId).HasColumnName("SynonymID");

                entity.Property(e => e.WordId1).HasColumnName("WordID1");

                entity.Property(e => e.WordId2).HasColumnName("WordID2");

                entity.HasOne(d => d.WordId1Navigation)
                    .WithMany(p => p.SynonymsWordId1Navigation)
                    .HasForeignKey(d => d.WordId1)
                    .HasConstraintName("FK_Syn_Dic_Word1");

                entity.HasOne(d => d.WordId2Navigation)
                    .WithMany(p => p.SynonymsWordId2Navigation)
                    .HasForeignKey(d => d.WordId2)
                    .HasConstraintName("FK_Syn_Dic_Word2");
            });

            modelBuilder.Entity<Themes>(entity =>
            {
                entity.HasKey(e => e.ThemeId)
                    .HasName("PK__Themes__FBB3E4B909E33BEA");

                entity.Property(e => e.ThemeId).HasColumnName("ThemeID");

                entity.Property(e => e.Author)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Mean).IsUnicode(false);

                entity.Property(e => e.ThemeName).IsUnicode(false);

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Themes)
                    .HasForeignKey(d => d.Author)
                    .HasConstraintName("FK_Theme_Acc");
            });

            modelBuilder.Entity<UserInfos>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__UserInfo__C9F28457A11D3F29");

                entity.Property(e => e.UserName)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserNameNavigation)
                    .WithOne(p => p.UserInfos)
                    .HasForeignKey<UserInfos>(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Acc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=YVFlashCard;Integrated Security=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}