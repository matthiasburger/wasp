﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wasp.WebApi.Data;

namespace wasp.WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Id");

                    b.Property<string>("DataTableId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DataTableId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("Name");

                    b.Property<string>("PythonId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PythonId");

                    b.HasKey("Id", "DataTableId");

                    b.HasIndex("DataTableId");

                    b.ToTable("DataItem");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataTable", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("SqlId")
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SqlId");

                    b.HasKey("Id");

                    b.ToTable("DataTable");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Index", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Id");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("Index");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Relation", b =>
                {
                    b.Property<string>("IndexId")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("IndexId");

                    b.Property<string>("KeyDataItemId")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("KeyDataItemId");

                    b.Property<string>("KeyDataTableId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("KeyDataTableId");

                    b.Property<string>("ReferenceDataItemId")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("ReferenceDataItemId");

                    b.Property<string>("ReferenceDataTableId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReferenceDataTableId");

                    b.HasKey("IndexId", "KeyDataItemId", "KeyDataTableId", "ReferenceDataItemId", "ReferenceDataTableId")
                        .IsClustered(false);

                    b.HasIndex("KeyDataItemId", "KeyDataTableId");

                    b.HasIndex("ReferenceDataItemId", "ReferenceDataTableId");

                    b.ToTable("Relation");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataItem", b =>
                {
                    b.HasOne("wasp.WebApi.Data.Models.DataTable", "DataTable")
                        .WithMany()
                        .HasForeignKey("DataTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataTable");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Relation", b =>
                {
                    b.HasOne("wasp.WebApi.Data.Models.Index", "Index")
                        .WithMany()
                        .HasForeignKey("IndexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wasp.WebApi.Data.Models.DataItem", "KeyDataItem")
                        .WithMany("KeyRelations")
                        .HasForeignKey("KeyDataItemId", "KeyDataTableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("wasp.WebApi.Data.Models.DataItem", "ReferenceDataItem")
                        .WithMany("ReferenceRelations")
                        .HasForeignKey("ReferenceDataItemId", "ReferenceDataTableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Index");

                    b.Navigation("KeyDataItem");

                    b.Navigation("ReferenceDataItem");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataItem", b =>
                {
                    b.Navigation("KeyRelations");

                    b.Navigation("ReferenceRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
