// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TcKimlikTest.Data;

namespace TcKimlikTest.Data.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20210820081806_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TcKimlikTest.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("MersisControl")
                        .HasColumnType("bit");

                    b.Property<long>("Name")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("TcKimlikTest.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyNameId")
                        .HasColumnType("int");

                    b.Property<int?>("TcKimlikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyNameId");

                    b.HasIndex("TcKimlikId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TcKimlikTest.Models.TcKimlik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DogumYili")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TCKimlikNo")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TcKimlik");
                });

            modelBuilder.Entity("TcKimlikTest.Models.Customer", b =>
                {
                    b.HasOne("TcKimlikTest.Models.Company", "CompanyName")
                        .WithMany()
                        .HasForeignKey("CompanyNameId");

                    b.HasOne("TcKimlikTest.Models.TcKimlik", "TcKimlik")
                        .WithMany()
                        .HasForeignKey("TcKimlikId");

                    b.Navigation("CompanyName");

                    b.Navigation("TcKimlik");
                });
#pragma warning restore 612, 618
        }
    }
}
