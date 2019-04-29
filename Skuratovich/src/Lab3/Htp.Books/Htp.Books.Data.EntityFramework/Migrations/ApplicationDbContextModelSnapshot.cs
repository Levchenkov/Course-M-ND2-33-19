﻿// <auto-generated />
using System;
using Htp.Books.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Htp.Books.Data.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Htp.Books.Data.Contracts.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("DeliveryRequired");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("GenreId");

                    b.Property<bool>("IsPaper");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Htp.Books.Data.Contracts.Entities.BookLanguage", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("LanguageId");

                    b.HasKey("BookId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("BookLanguages");
                });

            modelBuilder.Entity("Htp.Books.Data.Contracts.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Anthology"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Crime"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Fantasy"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Drama"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Horror"
                        });
                });

            modelBuilder.Entity("Htp.Books.Data.Contracts.Entities.HistoryLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actually");

                    b.Property<string>("EntityId")
                        .IsRequired();

                    b.Property<string>("EntityType")
                        .IsRequired();

                    b.Property<string>("Origin");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("HistoryLogs");
                });

            modelBuilder.Entity("Htp.Books.Data.Contracts.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "English"
                        },
                        new
                        {
                            Id = 2,
                            Title = "German"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Russian"
                        });
                });

            modelBuilder.Entity("Htp.Books.Data.Contracts.Entities.Book", b =>
                {
                    b.HasOne("Htp.Books.Data.Contracts.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Htp.Books.Data.Contracts.Entities.BookLanguage", b =>
                {
                    b.HasOne("Htp.Books.Data.Contracts.Entities.Book", "Book")
                        .WithMany("BookLanguages")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Htp.Books.Data.Contracts.Entities.Language", "Language")
                        .WithMany("BookLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
