﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppForTests.Shared.Models.DbModels;

namespace AppForTests.Shared.Domain
{
    public partial class TestsDBContext : DbContext
    {
        public TestsDBContext()
        {
        }

        public TestsDBContext(DbContextOptions<TestsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswersHistory> AnswersHistories { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionsHistory> QuestionsHistories { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestsHistory> TestsHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Data Source=NHPC\\SQLEXPRESS;Initial Catalog=TestsDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Tilte)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Questions");
            });

            modelBuilder.Entity<AnswersHistory>(entity =>
            {
                entity.ToTable("AnswersHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.QuestionHistoryId).HasColumnName("QuestionHistoryID");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.AnswersHistories)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswersHistory_Answers");

                entity.HasOne(d => d.QuestionHistory)
                    .WithMany(p => p.AnswersHistories)
                    .HasForeignKey(d => d.QuestionHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswersHistory_QuestionsHistory");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Tests");
            });

            modelBuilder.Entity<QuestionsHistory>(entity =>
            {
                entity.ToTable("QuestionsHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.TestHistoryId).HasColumnName("TestHistoryID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionsHistories)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionsHostory_Questions");

                entity.HasOne(d => d.TestHistory)
                    .WithMany(p => p.QuestionsHistories)
                    .HasForeignKey(d => d.TestHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionsHistory_TestsHistory");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TestsHistory>(entity =>
            {
                entity.ToTable("TestsHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestsHistories)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestsHistory_Tests");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestsHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestsHistory_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login, "IX_Users")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}