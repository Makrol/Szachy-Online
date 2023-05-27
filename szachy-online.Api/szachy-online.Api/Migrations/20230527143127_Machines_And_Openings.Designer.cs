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
    [Migration("20230527143127_Machines_And_Openings")]
    partial class Machines_And_Openings
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

            modelBuilder.Entity("szachy_online.Api.Entities.MachineEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d18840d1-9ca3-4fcd-aa78-5a21618521c1"),
                            DateCreated = new DateTime(2023, 5, 27, 16, 31, 26, 928, DateTimeKind.Local).AddTicks(9957),
                            Level = "One",
                            Nickname = "Stephan"
                        },
                        new
                        {
                            Id = new Guid("da6a73a3-98f4-4cda-ac42-85126087c6a0"),
                            DateCreated = new DateTime(2023, 5, 27, 16, 31, 26, 928, DateTimeKind.Local).AddTicks(9962),
                            Level = "Two",
                            Nickname = "Lora"
                        },
                        new
                        {
                            Id = new Guid("37979414-d6ae-4746-8150-8f269b697a0e"),
                            DateCreated = new DateTime(2023, 5, 27, 16, 31, 26, 928, DateTimeKind.Local).AddTicks(9966),
                            Level = "Random",
                            Nickname = "Brandon"
                        });
                });

            modelBuilder.Entity("szachy_online.Api.Entities.OpeningEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PGN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Openings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Otwarcie szachowe rozpoczynające się posunięciami:\r\n\r\ne4 c5\r\nDebiut ten jest najpopularniejszą i dającą najlepsze efekty odpowiedzią na pierwszy ruch białych 1. e4. Statystycznie skuteczniejszym otwarciem dla białych jest 1. d4, gdyż obrona (sycylijska) przed 1. e4 ma wysoki wskaźnik skuteczności. W czasopiśmie „New in Chess” (w roczniku wydanym w roku 2000) podano, że w grach z jego bazy danych białe wygrały 56,1% partii (z 296 200), zaczynając od 1. d4, a przy rozpoczęciu od 1. e4 było to 54,1% partii (z 349 855), głównie dzięki obronie sycylijskiej (52,3% wygranych przez białe ze 145 996 rozgrywek).",
                            Name = "Obrona Sycylijska - Wariant smoczy",
                            PGN = "1.e4 c5 2.Nf3 d6 3.d4 cxd4 4.Nxd4 Nf6 5.Nc3 g6"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Otwarcie szachowe charakteryzujące się posunięciami:\r\n\r\n1.e4 d5\r\\r\nJest to debiut półotwarty. W klasyfikacji encyklopedii otwarć szachowych jest oznaczony kodem ECO B01.\r\n\r\nObronę skandynawską zastosowano w najstarszej znanej partii szachów europejskich, rozegranej około 1475 r. w Walencji. W 1497 r. jej opis znalazł się w książce Luisa Luceny. W XIX wieku analizował ją Carl Jänisch. Dużą popularność zyskała na przełomie XIX i XX wieku. Swoją nazwę zawdzięcza pracom szwedzkich szachistów Ludwiga i Gustafa Collijnów. W 1918 roku monografię otwarcia opublikował Jacques Mieses, który często stosował ten debiut w turniejach i znacząco przyczynił się do rozwoju jego teorii.\r\n\r\nW późniejszych latach obrona skandynawska była rzadko stosowana przez czołowych szachistów świata. W 1979 r. w Montrealu Bent Larsen skutecznie zastosował ten debiut w wygranej partii z mistrzem świata, Anatolijem Karpowem[1] (była to jedyna porażka Karpowa w tym turnieju)[2]. W 1995 r. obrona skandynawska pojawiła się w meczu o mistrzostwa świata. Viswanathan Anand uzyskał po debiucie dobrą pozycję przeciwko Garriemu Kasparowowi, jednak partię przegrał[3].",
                            Name = "Obrona Skandynawska - Wariant Miesesa",
                            PGN = "1.e4 d5 2.ed5 Qxd5 3.Sc3 Qa5 4.d4 Nf6 5.Nf3 Bf5"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Otwarcie szachowe oznaczone kodem A40 ECO rzadko stosowane debiut zamknięty, wprowadzone do praktyki turniejowej przez Aleksandra Wagnera w roku 1913 i charakteryzujące się posunięciami:\r\n\r\n1.d4 b5\r\nIdea tego otwarcia polega na:\r\n\r\nrozwinięciu hetmańskiego gońca czarnych na pole b7, skąd, wzdłuż przekątnej a8-h1 oddziałuje on na skrzydło królewskie białych, a przede wszystkim kontroluje ważny punkt e4.\r\ndzięki obecności piona na polu b5 czarne mogą walczyć o przewagę przestrzeni na skrzydle hetmańskim.\r\nobrana przez czarne strategia nie narzuca zwykle forsownych rozwiązań w początkowej fazie gry, ewentualna erudycja przeciwnika traci na znaczeniu.",
                            Name = "Obrona Polska",
                            PGN = "1.d4 b5 2.e4 Bb7 3.Bd3 Nf6"
                        });
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
