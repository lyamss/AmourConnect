﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using server_api.Data;

#nullable disable

namespace server_api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240504135620_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("server_api.Models.Swipe", b =>
                {
                    b.Property<int>("Id_Swipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Swipe"));

                    b.Property<DateTime>("Date_of_swiping")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_User")
                        .HasColumnType("integer");

                    b.Property<int>("Id_User_which_was_Swiped")
                        .HasColumnType("integer");

                    b.HasKey("Id_Swipe");

                    b.HasIndex("Id_User");

                    b.HasIndex("Id_User_which_was_Swiped");

                    b.ToTable("Swipe");
                });

            modelBuilder.Entity("server_api.Models.User", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_User"));

                    b.Property<string>("EmailGoogle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte[]>("Profile_picture")
                        .HasColumnType("bytea");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<DateTime>("account_created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("date_of_birth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("date_token_session_expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("grade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("sex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("token_session_user")
                        .HasColumnType("text");

                    b.Property<string>("userIdGoogle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_User");

                    b.ToTable("User");
                });

            modelBuilder.Entity("server_api.Models.Swipe", b =>
                {
                    b.HasOne("server_api.Models.User", "User")
                        .WithMany("Swipes")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server_api.Models.User", "UserWhichWasSwiped")
                        .WithMany("SwipesReceived")
                        .HasForeignKey("Id_User_which_was_Swiped")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserWhichWasSwiped");
                });

            modelBuilder.Entity("server_api.Models.User", b =>
                {
                    b.Navigation("Swipes");

                    b.Navigation("SwipesReceived");
                });
#pragma warning restore 612, 618
        }
    }
}