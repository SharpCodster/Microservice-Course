﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VivaioInCloud.Notification.Infrastructure;

#nullable disable

namespace VivaioInCloud.Notification.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221111114338_AddedUserNotificationAndUSerPReference")]
    partial class AddedUserNotificationAndUSerPReference
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VivaioInCloud.Notification.Entities.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc")
                        .HasColumnOrder(1000);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)")
                        .HasColumnName("CreatedBy")
                        .HasColumnOrder(1001);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted")
                        .HasColumnOrder(1004);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAtUtc")
                        .HasColumnOrder(1002);

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)")
                        .HasColumnName("UpdatedBy")
                        .HasColumnOrder(1003);

                    b.HasKey("Id");

                    b.ToTable("Contacts", "dbo");
                });

            modelBuilder.Entity("VivaioInCloud.Notification.Entities.Models.UserNotification", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAtUtc")
                        .HasColumnOrder(1000);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)")
                        .HasColumnName("CreatedBy")
                        .HasColumnOrder(1001);

                    b.Property<bool>("Delivered")
                        .HasColumnType("boolean")
                        .HasColumnOrder(2);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted")
                        .HasColumnOrder(1004);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UpdatedAtUtc")
                        .HasColumnOrder(1002);

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)")
                        .HasColumnName("UpdatedBy")
                        .HasColumnOrder(1003);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotifications", "dbo");
                });

            modelBuilder.Entity("VivaioInCloud.Notification.Entities.Models.UserPreference", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(2);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPreferences", "dbo");
                });

            modelBuilder.Entity("VivaioInCloud.Notification.Entities.Models.UserNotification", b =>
                {
                    b.HasOne("VivaioInCloud.Notification.Entities.Models.Contact", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VivaioInCloud.Notification.Entities.Models.UserPreference", b =>
                {
                    b.HasOne("VivaioInCloud.Notification.Entities.Models.Contact", "User")
                        .WithMany("UserPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VivaioInCloud.Notification.Entities.Models.Contact", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("UserPreferences");
                });
#pragma warning restore 612, 618
        }
    }
}
