﻿// <auto-generated />
using System;
using Cordelia.LoginRegister.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cordelia.LoginRegister.Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231120102047_AgregarCampoSecretKey")]
    partial class AgregarCampoSecretKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("pcfapi")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cordelia.LoginRegister.Domain.Model.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageId"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<string>("MessageContent")
                        .HasColumnType("text");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MessageReceiverId")
                        .HasColumnType("integer");

                    b.Property<int>("MessageSenderId")
                        .HasColumnType("integer");

                    b.Property<string>("MessageSubject")
                        .HasColumnType("text");

                    b.HasKey("MessageId");

                    b.HasIndex("MessageReceiverId");

                    b.HasIndex("MessageSenderId");

                    b.ToTable("Message", "pcfapi");
                });

            modelBuilder.Entity("Cordelia.LoginRegister.Domain.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<bool>("DarkMode")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("SecretKet")
                        .HasColumnType("text");

                    b.Property<DateTime>("UserBirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserCity")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.Property<int>("UserLanguageId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("UserPhone")
                        .HasColumnType("text");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User", "pcfapi");
                });

            modelBuilder.Entity("Enfonsalaflota.Domain.Model.FriendRequest", b =>
                {
                    b.Property<int>("FriendRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FriendRequestId"));

                    b.Property<int>("FriendRequestReceiverId")
                        .HasColumnType("integer");

                    b.Property<int>("FriendRequestSenderId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("FriendRequestId");

                    b.HasIndex("FriendRequestReceiverId");

                    b.HasIndex("FriendRequestSenderId");

                    b.ToTable("FriendRequest", "pcfapi");
                });

            modelBuilder.Entity("Cordelia.LoginRegister.Domain.Model.Message", b =>
                {
                    b.HasOne("Cordelia.LoginRegister.Domain.Model.User", "MessageReceiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("MessageReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cordelia.LoginRegister.Domain.Model.User", "MessageSender")
                        .WithMany("SentMessages")
                        .HasForeignKey("MessageSenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageReceiver");

                    b.Navigation("MessageSender");
                });

            modelBuilder.Entity("Enfonsalaflota.Domain.Model.FriendRequest", b =>
                {
                    b.HasOne("Cordelia.LoginRegister.Domain.Model.User", "FriendRequestReceiver")
                        .WithMany("ReceivedFriendRequests")
                        .HasForeignKey("FriendRequestReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cordelia.LoginRegister.Domain.Model.User", "FriendRequestSender")
                        .WithMany("SentFriendRequests")
                        .HasForeignKey("FriendRequestSenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FriendRequestReceiver");

                    b.Navigation("FriendRequestSender");
                });

            modelBuilder.Entity("Cordelia.LoginRegister.Domain.Model.User", b =>
                {
                    b.Navigation("ReceivedFriendRequests");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentFriendRequests");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
