﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Utah.Udot.Atspm.Data;

#nullable disable

namespace Utah.Udot.ATSPM.SqlLiteDatabaseProvider.Migrations.EventLog
{
    [DbContext(typeof(EventLogContext))]
    partial class EventLogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Utah.Udot.Atspm.Data.Models.CompressedEventLogBase", b =>
                {
                    b.Property<string>("LocationIdentifier")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<int>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ArchiveDate")
                        .HasColumnType("Date");

                    b.Property<byte[]>("Data")
                        .HasColumnType("BLOB");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.HasKey("LocationIdentifier", "DeviceId", "ArchiveDate");

                    b.ToTable("CompressedEvents", t =>
                        {
                            t.HasComment("Compressed device data log events");
                        });

                    b.HasDiscriminator<string>("DataType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Utah.Udot.Atspm.Data.Models.CompressedEventLogs<Utah.Udot.Atspm.Data.Models.EventLogModels.IndianaEvent>", b =>
                {
                    b.HasBaseType("Utah.Udot.Atspm.Data.Models.CompressedEventLogBase");

                    b.HasDiscriminator().HasValue("IndianaEvent");
                });

            modelBuilder.Entity("Utah.Udot.Atspm.Data.Models.CompressedEventLogs<Utah.Udot.Atspm.Data.Models.EventLogModels.PedestrianCounter>", b =>
                {
                    b.HasBaseType("Utah.Udot.Atspm.Data.Models.CompressedEventLogBase");

                    b.HasDiscriminator().HasValue("PedestrianCounter");
                });

            modelBuilder.Entity("Utah.Udot.Atspm.Data.Models.CompressedEventLogs<Utah.Udot.Atspm.Data.Models.EventLogModels.SpeedEvent>", b =>
                {
                    b.HasBaseType("Utah.Udot.Atspm.Data.Models.CompressedEventLogBase");

                    b.HasDiscriminator().HasValue("SpeedEvent");
                });
#pragma warning restore 612, 618
        }
    }
}
