using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CRUDVjezba.Models;

namespace CRUDVjezba.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20161208092110_DateTimeMigration1")]
    partial class DateTimeMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDVjezba.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress");

                    b.Property<DateTime>("Date");

                    b.Property<string>("LogoString");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("CRUDVjezba.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FacultyId");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CRUDVjezba.Models.Student", b =>
                {
                    b.HasOne("CRUDVjezba.Models.Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyId");
                });
        }
    }
}
