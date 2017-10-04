using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StockVisionConsole.Models;

namespace StockVisionConsole.Migrations
{
    [DbContext(typeof(EFCoreDemoContext))]
    [Migration("20171003014837_CreatenewComany")]
    partial class CreatenewComany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockVisionConsole.Models.Companies", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int?>("CountriesId");

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<string>("Symbol");

                    b.HasKey("CompanyId");

                    b.HasIndex("CountriesId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockVisionConsole.Models.Countries", b =>
                {
                    b.Property<int>("CountriesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CountriesId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("StockVisionConsole.Models.Companies", b =>
                {
                    b.HasOne("StockVisionConsole.Models.Countries")
                        .WithMany("Companieses")
                        .HasForeignKey("CountriesId");
                });
        }
    }
}
