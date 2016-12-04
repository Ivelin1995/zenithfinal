using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ZenithSociety2.Models;

namespace ZenithSociety2.Migrations
{
    [DbContext(typeof(ZenithContext))]
    [Migration("20161117185946_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZenithSociety2.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivityDescription")
                        .IsRequired();

                    b.Property<DateTime>("CreationDate");

                    b.HasKey("ActivityId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("ZenithSociety2.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("FromDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ToDate");

                    b.HasKey("EventId");

                    b.HasIndex("ActivityId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("ZenithSociety2.Models.Event", b =>
                {
                    b.HasOne("ZenithSociety2.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
