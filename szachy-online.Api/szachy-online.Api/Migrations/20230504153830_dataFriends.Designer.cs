﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using szachy_online.Api.Data;

#nullable disable

namespace szachy_online.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230504153830_dataFriends")]
    partial class dataFriends
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("szachy_online.Api.Entities.AccountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("szachy_online.Api.Entities.FriendsEntity", b =>
                {
                    b.Property<long>("FriendshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("FriendshipID"));

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("User1ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("User2ID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FriendshipID");

                    b.HasIndex("User1ID");

                    b.HasIndex("User2ID");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("szachy_online.Api.Entities.GameEntity", b =>
                {
                    b.Property<Guid>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlackPlayer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<string>("PGN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WhitePlayer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Winner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("szachy_online.Api.Entities.FriendsEntity", b =>
                {
                    b.HasOne("szachy_online.Api.Entities.AccountEntity", "User1")
                        .WithMany()
                        .HasForeignKey("User1ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("szachy_online.Api.Entities.AccountEntity", "User2")
                        .WithMany()
                        .HasForeignKey("User2ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });
#pragma warning restore 612, 618
        }
    }
}