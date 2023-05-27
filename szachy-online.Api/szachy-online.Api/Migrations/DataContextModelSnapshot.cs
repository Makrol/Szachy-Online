﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using szachy_online.Api.Data;

#nullable disable

namespace szachy_online.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("3264ff97-928e-4eff-be63-69f21d204067"),
                            DateCreated = new DateTime(2023, 5, 27, 16, 59, 45, 477, DateTimeKind.Local).AddTicks(6053),
                            Level = "One",
                            Nickname = "Stephan"
                        },
                        new
                        {
                            Id = new Guid("2ace6dc4-7fea-46b3-90f4-1839341a86af"),
                            DateCreated = new DateTime(2023, 5, 27, 16, 59, 45, 477, DateTimeKind.Local).AddTicks(6059),
                            Level = "Two",
                            Nickname = "Lora"
                        },
                        new
                        {
                            Id = new Guid("958e78fb-5e6b-4822-9f04-8a4a19d15257"),
                            DateCreated = new DateTime(2023, 5, 27, 16, 59, 45, 477, DateTimeKind.Local).AddTicks(6062),
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

            modelBuilder.Entity("szachy_online.Api.Entities.TipEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Zachowaj równowagę między atakiem a obroną: Wskazówka ta sugeruje, że ważne jest, aby skupić się zarówno na atakowaniu figury przeciwnika, jak i na ochronie swoich własnych. Unikaj zbytniego poświęcania swoich sił na atak, kosztem osłabienia swojej pozycji."
                        },
                        new
                        {
                            Id = 2,
                            Description = "Pamiętaj o wartości figur: W tej wskazówce wartości figur są ustalone tak, że pion jest wart 1 punkt, skoczek i goniec - 3 punkty, wieża - 5 punktów, a hetman - 9 punktów. Utrzymuj świadomość względnych wartości figur i staraj się nie tracić na zbędnych wymianach."
                        },
                        new
                        {
                            Id = 3,
                            Description = "Planuj z góry: Zawsze warto mieć jasny plan i strategię, zanim zaczniesz podejmować konkretne posunięcia. Staraj się przewidzieć reakcje przeciwnika i opracuj odpowiednie plany, aby zwiększyć swoje szanse na sukces."
                        },
                        new
                        {
                            Id = 4,
                            Description = "Utrzymuj kontrolę nad centrum: Centrum planszy jest strategicznie ważne w szachach. Postaraj się kontrolować pola centralne swoimi pionami i figurami, co pozwoli ci na większą swobodę ruchów i łatwiejsze przeprowadzenie ataku."
                        },
                        new
                        {
                            Id = 5,
                            Description = "Zawsze sprawdzaj możliwe zagrożenia: Przed wykonaniem ruchu zawsze sprawdź, czy nie narażasz swojego króla na szach lub czy nie zostajesz zmuszony do utraty materiału. Bądź czujny i staraj się przewidzieć potencjalne zagrożenia."
                        },
                        new
                        {
                            Id = 6,
                            Description = "Praktykuj taktykę szachową: Skup się na doskonaleniu umiejętności taktycznych, takich jak kombinacje, motywy szachowe i pułapki. Regularne rozwiązywanie zadań taktycznych pomoże w rozwoju twojego spostrzegawczości i umiejętności znajdowania najlepszych ruchów."
                        },
                        new
                        {
                            Id = 7,
                            Description = "Baw się i ucz się od swoich partii: Nie zapomnij czerpać radości z gry w szachy! Po zakończeniu partii analizuj swoje posunięcia, poszukuj błędów i próbuj wyciągać wnioski. Każda partia jest szansą do nauki i rozwoju jako szachista."
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
