﻿// <auto-generated />
using System;
using ArcelikWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArcelikWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240130081418_new3")]
    partial class new3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArcelikWebApi.Models.AiApplication", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConversationRetentionPeriod")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EnableUploadPdfFile")
                        .HasColumnType("bit");

                    b.Property<float>("ModalTemperature")
                        .HasColumnType("real");

                    b.Property<string>("Pdfs_Urls")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemPrompt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UseKnowledgebase")
                        .HasColumnType("bit");

                    b.Property<string>("WelcomeMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AiApplications");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Answers", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Answer1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Answer1 = "Paris",
                            Answer2 = "London"
                        },
                        new
                        {
                            QuestionId = 2,
                            Answer1 = "William Shakespeare"
                        },
                        new
                        {
                            QuestionId = 3,
                            Answer1 = "H2O",
                            Answer2 = "CO2",
                            Answer3 = "O2"
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.ApplicationSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("LandingUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupportedFileTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ApplicationSettings");

                    b.HasData(
                        new
                        {
                            id = 1,
                            LandingUrl = "Somelink will be here",
                            SupportedFileTypes = "Pdf"
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Options", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Option1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option4")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Option1 = "Paris",
                            Option2 = "London",
                            Option3 = "Berlin",
                            Option4 = "Madrid"
                        },
                        new
                        {
                            QuestionId = 2,
                            Option1 = "William Shakespeare",
                            Option2 = "Jane Austen",
                            Option3 = "Charles Dickens",
                            Option4 = "Mark Twain"
                        },
                        new
                        {
                            QuestionId = 3,
                            Option1 = "H2O",
                            Option2 = "CO2",
                            Option3 = "O2",
                            Option4 = "NaCl"
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Questions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Point = 10,
                            Question = "What is the capital of France?"
                        },
                        new
                        {
                            id = 2,
                            Point = 15,
                            Question = "Who wrote 'Romeo and Juliet'?"
                        },
                        new
                        {
                            id = 3,
                            Point = 10,
                            Question = "What is the chemical symbol for water?"
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Users", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WatchedTimeInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("WatchedVideoId")
                        .HasColumnType("int");

                    b.Property<bool>("isTutorialDone")
                        .HasColumnType("bit");

                    b.Property<bool>("isWatchedAll")
                        .HasColumnType("bit");

                    b.Property<int>("quizPoint")
                        .HasColumnType("int");

                    b.Property<int?>("secondsSpendOnQuiz")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("WatchedVideoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BlobStorageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoDuration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlobStorageUrl = "https://arcelikstorage.blob.core.windows.net/videos/sample1.mp4",
                            Title = "Video 1",
                            VideoDuration = 5
                        },
                        new
                        {
                            Id = 2,
                            BlobStorageUrl = "https://arcelikstorage.blob.core.windows.net/videos/sample2.mp4",
                            Title = "Video 2",
                            VideoDuration = 8
                        },
                        new
                        {
                            Id = 3,
                            BlobStorageUrl = "https://arcelikstorage.blob.core.windows.net/videos/sample3.mp4",
                            Title = "Video 3",
                            VideoDuration = 10
                        });
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Answers", b =>
                {
                    b.HasOne("ArcelikWebApi.Models.Questions", "Question")
                        .WithOne("Answers")
                        .HasForeignKey("ArcelikWebApi.Models.Answers", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Options", b =>
                {
                    b.HasOne("ArcelikWebApi.Models.Questions", "Question")
                        .WithOne("Options")
                        .HasForeignKey("ArcelikWebApi.Models.Options", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Users", b =>
                {
                    b.HasOne("ArcelikWebApi.Models.Video", "WatchedVideo")
                        .WithMany()
                        .HasForeignKey("WatchedVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WatchedVideo");
                });

            modelBuilder.Entity("ArcelikWebApi.Models.Questions", b =>
                {
                    b.Navigation("Answers")
                        .IsRequired();

                    b.Navigation("Options")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
