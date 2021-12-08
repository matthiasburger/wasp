﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wasp.WebApi.Data;

#nullable disable

namespace wasp.WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211208160612_MadeDataAreaRecursive")]
    partial class MadeDataAreaRecursive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataArea", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    b.Property<string>("ModuleId")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("ModuleId")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Name")
                        .HasColumnOrder(3);

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("ParentId")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("ParentId");

                    b.ToTable("DataAreas");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataField", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    b.Property<string>("DataAreaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("DataAreaId")
                        .HasColumnOrder(2);

                    b.Property<string>("DataItemId")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("DataItemId")
                        .HasColumnOrder(4);

                    b.Property<string>("DataTableId")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DataTableId")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("DataAreaId");

                    b.HasIndex("DataTableId");

                    b.HasIndex("DataItemId", "DataTableId");

                    b.ToTable("DataFields");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<string>("DataTableId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DataTableId")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2);

                    b.Property<string>("PythonId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PythonId")
                        .HasColumnOrder(3);

                    b.HasKey("Id", "DataTableId");

                    b.HasIndex("DataTableId");

                    b.ToTable("DataItem");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataTable", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name")
                        .HasColumnOrder(1);

                    b.Property<string>("SqlId")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SqlId")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("DataTable");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Index", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint")
                        .HasColumnName("Type")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("Index");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Module", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.PrimaryKey", b =>
                {
                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CurrentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TableName");

                    b.ToTable("PrimaryKeys");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Relation", b =>
                {
                    b.Property<string>("IndexId")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("IndexId")
                        .HasColumnOrder(0);

                    b.Property<string>("KeyDataItemId")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("KeyDataItemId")
                        .HasColumnOrder(1);

                    b.Property<string>("KeyDataTableId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("KeyDataTableId")
                        .HasColumnOrder(2);

                    b.Property<string>("ReferenceDataItemId")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("ReferenceDataItemId")
                        .HasColumnOrder(3);

                    b.Property<string>("ReferenceDataTableId")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReferenceDataTableId")
                        .HasColumnOrder(4);

                    b.HasKey("IndexId", "KeyDataItemId", "KeyDataTableId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IndexId", "KeyDataItemId", "KeyDataTableId"), false);

                    b.HasIndex("KeyDataItemId", "KeyDataTableId");

                    b.HasIndex("ReferenceDataItemId", "ReferenceDataTableId");

                    b.ToTable("Relation");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataArea", b =>
                {
                    b.HasOne("wasp.WebApi.Data.Models.Module", "Module")
                        .WithMany("DataAreas")
                        .HasForeignKey("ModuleId");

                    b.HasOne("wasp.WebApi.Data.Models.DataArea", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Module");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataField", b =>
                {
                    b.HasOne("wasp.WebApi.Data.Models.DataArea", "DataArea")
                        .WithMany("DataFields")
                        .HasForeignKey("DataAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wasp.WebApi.Data.Models.DataTable", "DataTable")
                        .WithMany()
                        .HasForeignKey("DataTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wasp.WebApi.Data.Models.DataItem", "DataItem")
                        .WithMany()
                        .HasForeignKey("DataItemId", "DataTableId");

                    b.Navigation("DataArea");

                    b.Navigation("DataItem");

                    b.Navigation("DataTable");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataItem", b =>
                {
                    b.HasOne("wasp.WebApi.Data.Models.DataTable", "DataTable")
                        .WithMany("DataItems")
                        .HasForeignKey("DataTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataTable");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Relation", b =>
                {
                    b.HasOne("wasp.WebApi.Data.Models.Index", "Index")
                        .WithMany("Relations")
                        .HasForeignKey("IndexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wasp.WebApi.Data.Models.DataItem", "KeyDataItem")
                        .WithMany("KeyRelations")
                        .HasForeignKey("KeyDataItemId", "KeyDataTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wasp.WebApi.Data.Models.DataItem", "ReferenceDataItem")
                        .WithMany("ReferenceRelations")
                        .HasForeignKey("ReferenceDataItemId", "ReferenceDataTableId");

                    b.Navigation("Index");

                    b.Navigation("KeyDataItem");

                    b.Navigation("ReferenceDataItem");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataArea", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("DataFields");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataItem", b =>
                {
                    b.Navigation("KeyRelations");

                    b.Navigation("ReferenceRelations");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.DataTable", b =>
                {
                    b.Navigation("DataItems");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Index", b =>
                {
                    b.Navigation("Relations");
                });

            modelBuilder.Entity("wasp.WebApi.Data.Models.Module", b =>
                {
                    b.Navigation("DataAreas");
                });
#pragma warning restore 612, 618
        }
    }
}
