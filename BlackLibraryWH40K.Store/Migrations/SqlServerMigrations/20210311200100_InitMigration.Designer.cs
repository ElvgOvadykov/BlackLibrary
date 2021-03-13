﻿// <auto-generated />
using System;
using BlackLibraryWH40K.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackLibraryWH40K.Store.Migrations.SqlServerMigrations
{
    [DbContext(typeof(BlackLibraryContext))]
    [Migration("20210311200100_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<int?>("ChapterMasterId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomeWorldId")
                        .HasColumnType("int");

                    b.Property<int?>("LegionNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Warcry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("ChapterMasterId");

                    b.HasIndex("HomeWorldId");

                    b.HasIndex("LegionNumber");

                    b.ToTable("Chapter");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Legion", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChapterMasterId")
                        .HasColumnType("int");

                    b.Property<int?>("HomeWorldId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrimarchNumber")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("ChapterMasterId");

                    b.HasIndex("HomeWorldId");

                    b.HasIndex("PrimarchNumber");

                    b.ToTable("Legion");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Primarch", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomeWorldId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("HomeWorldId");

                    b.HasIndex("StateId");

                    b.ToTable("Primarch");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.World", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("World");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Chapter", b =>
                {
                    b.HasOne("BlackLibraryWH40K.Store.Model.Chapter", null)
                        .WithMany("Successors")
                        .HasForeignKey("ChapterId");

                    b.HasOne("BlackLibraryWH40K.Store.Model.Person", "ChapterMaster")
                        .WithMany()
                        .HasForeignKey("ChapterMasterId");

                    b.HasOne("BlackLibraryWH40K.Store.Model.World", "HomeWorld")
                        .WithMany()
                        .HasForeignKey("HomeWorldId");

                    b.HasOne("BlackLibraryWH40K.Store.Model.Legion", "Legion")
                        .WithMany()
                        .HasForeignKey("LegionNumber");

                    b.Navigation("ChapterMaster");

                    b.Navigation("HomeWorld");

                    b.Navigation("Legion");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Legion", b =>
                {
                    b.HasOne("BlackLibraryWH40K.Store.Model.Person", "ChapterMaster")
                        .WithMany()
                        .HasForeignKey("ChapterMasterId");

                    b.HasOne("BlackLibraryWH40K.Store.Model.World", "HomeWorld")
                        .WithMany()
                        .HasForeignKey("HomeWorldId");

                    b.HasOne("BlackLibraryWH40K.Store.Model.Primarch", "Primarch")
                        .WithMany()
                        .HasForeignKey("PrimarchNumber");

                    b.Navigation("ChapterMaster");

                    b.Navigation("HomeWorld");

                    b.Navigation("Primarch");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Organization", b =>
                {
                    b.HasOne("BlackLibraryWH40K.Store.Model.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Person", b =>
                {
                    b.HasOne("BlackLibraryWH40K.Store.Model.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Primarch", b =>
                {
                    b.HasOne("BlackLibraryWH40K.Store.Model.World", "HomeWorld")
                        .WithMany()
                        .HasForeignKey("HomeWorldId");

                    b.HasOne("BlackLibraryWH40K.Store.Model.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("HomeWorld");

                    b.Navigation("State");
                });

            modelBuilder.Entity("BlackLibraryWH40K.Store.Model.Chapter", b =>
                {
                    b.Navigation("Successors");
                });
#pragma warning restore 612, 618
        }
    }
}
