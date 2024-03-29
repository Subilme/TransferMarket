﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransferMarket.Data;

#nullable disable

namespace TransferMarket.Data.Migrations
{
    [DbContext(typeof(TransferMarketDbContext))]
    [Migration("20230202190218_q")]
    partial class q
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TransferMarket.Data.Amplification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Amplifications");
                });

            modelBuilder.Entity("TransferMarket.Data.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("TransferMarket.Data.CardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("TransferMarket.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("GuestTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TransferMarket.Data.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmplififcationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmplififcationId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TransferMarket.Data.ScoredGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerScoredId")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerScoredId");

                    b.ToTable("ScoredGoals");
                });

            modelBuilder.Entity("TransferMarket.Data.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BestAssistantId")
                        .HasColumnType("int");

                    b.Property<int>("BestStrikerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BestAssistantId");

                    b.HasIndex("BestStrikerId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("TransferMarket.Data.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TransferMarket.Data.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TransferMarket.Data.Card", b =>
                {
                    b.HasOne("TransferMarket.Data.CardType", "CardType")
                        .WithMany()
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TransferMarket.Data.Game", b =>
                {
                    b.HasOne("TransferMarket.Data.Team", "GuestTeam")
                        .WithMany()
                        .HasForeignKey("GuestTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuestTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("TransferMarket.Data.Player", b =>
                {
                    b.HasOne("TransferMarket.Data.Amplification", "Amplification")
                        .WithMany()
                        .HasForeignKey("AmplififcationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Amplification");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TransferMarket.Data.ScoredGoal", b =>
                {
                    b.HasOne("TransferMarket.Data.Game", "Game")
                        .WithMany("ScoredGoals")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Player", "PlayerScored")
                        .WithMany()
                        .HasForeignKey("PlayerScoredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("PlayerScored");
                });

            modelBuilder.Entity("TransferMarket.Data.Season", b =>
                {
                    b.HasOne("TransferMarket.Data.Player", "BestAssistant")
                        .WithMany()
                        .HasForeignKey("BestAssistantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Player", "BestStriker")
                        .WithMany()
                        .HasForeignKey("BestStrikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Tournament", "Tournament")
                        .WithMany("Seasons")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransferMarket.Data.Team", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BestAssistant");

                    b.Navigation("BestStriker");

                    b.Navigation("Tournament");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("TransferMarket.Data.Team", b =>
                {
                    b.HasOne("TransferMarket.Data.Season", "Season")
                        .WithMany("Teams")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("TransferMarket.Data.Game", b =>
                {
                    b.Navigation("ScoredGoals");
                });

            modelBuilder.Entity("TransferMarket.Data.Season", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("TransferMarket.Data.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("TransferMarket.Data.Tournament", b =>
                {
                    b.Navigation("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}
