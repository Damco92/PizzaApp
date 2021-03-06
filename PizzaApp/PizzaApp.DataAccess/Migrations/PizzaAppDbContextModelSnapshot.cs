// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaApp.DataAccess.Models;

namespace PizzaApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaAppDbContext))]
    partial class PizzaAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaApp.DataAccess.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeSubmited")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("StateId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PizzaSizeId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaSizeId");

                    b.HasIndex("PizzaTypeId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.PizzaSize", b =>
                {
                    b.Property<int>("PizzaSizeId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnName("PizzaSize")
                        .HasColumnType("char(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("PizzaSizeId");

                    b.ToTable("PizzaSize");

                    b.HasData(
                        new
                        {
                            PizzaSizeId = 1,
                            Size = "Small"
                        },
                        new
                        {
                            PizzaSizeId = 2,
                            Size = "Medium"
                        },
                        new
                        {
                            PizzaSizeId = 3,
                            Size = "Large"
                        },
                        new
                        {
                            PizzaSizeId = 4,
                            Size = "Family"
                        });
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.PizzaType", b =>
                {
                    b.Property<int>("PizzaTypeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfPizza")
                        .IsRequired()
                        .HasColumnName("PizzaType")
                        .HasColumnType("char(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("PizzaTypeId");

                    b.ToTable("PizzaType");

                    b.HasData(
                        new
                        {
                            PizzaTypeId = 1,
                            TypeOfPizza = "Capri"
                        },
                        new
                        {
                            PizzaTypeId = 2,
                            TypeOfPizza = "Margaritha"
                        },
                        new
                        {
                            PizzaTypeId = 3,
                            TypeOfPizza = "Funghi"
                        },
                        new
                        {
                            PizzaTypeId = 4,
                            TypeOfPizza = "Peperoni"
                        },
                        new
                        {
                            PizzaTypeId = 5,
                            TypeOfPizza = "Stelato"
                        },
                        new
                        {
                            PizzaTypeId = 6,
                            TypeOfPizza = "Vege"
                        });
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("StateTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateTypeId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.StateType", b =>
                {
                    b.Property<int>("StateTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("StateType")
                        .HasColumnType("char(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("StateTypeId");

                    b.ToTable("StateType");

                    b.HasData(
                        new
                        {
                            StateTypeId = 1,
                            Type = "Preparing"
                        },
                        new
                        {
                            StateTypeId = 2,
                            Type = "Baking"
                        },
                        new
                        {
                            StateTypeId = 3,
                            Type = "Delivering"
                        },
                        new
                        {
                            StateTypeId = 4,
                            Type = "Delivered"
                        },
                        new
                        {
                            StateTypeId = 5,
                            Type = "Canceled"
                        });
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.Transition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentStateId")
                        .HasColumnType("int");

                    b.Property<int>("NextStateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentStateId");

                    b.HasIndex("NextStateId");

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.Order", b =>
                {
                    b.HasOne("PizzaApp.DataAccess.Models.Pizza", "Pizza")
                        .WithMany("Orders")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("FK_pizza")
                        .IsRequired();

                    b.HasOne("PizzaApp.DataAccess.Models.State", "StateNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("StateId")
                        .HasConstraintName("FK_order_state")
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.Pizza", b =>
                {
                    b.HasOne("PizzaApp.DataAccess.Models.PizzaSize", "PizzaSize")
                        .WithMany("Pizzas")
                        .HasForeignKey("PizzaSizeId")
                        .HasConstraintName("FK_pizza_size")
                        .IsRequired();

                    b.HasOne("PizzaApp.DataAccess.Models.PizzaType", "PizzaType")
                        .WithMany("Pizzas")
                        .HasForeignKey("PizzaTypeId")
                        .HasConstraintName("FK_pizza_type")
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.State", b =>
                {
                    b.HasOne("PizzaApp.DataAccess.Models.StateType", "StateType")
                        .WithMany("States")
                        .HasForeignKey("StateTypeId")
                        .HasConstraintName("FK_state_type")
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaApp.DataAccess.Models.Transition", b =>
                {
                    b.HasOne("PizzaApp.DataAccess.Models.State", "CurrentStateNavigation")
                        .WithMany("TransitionsStateNavigation")
                        .HasForeignKey("CurrentStateId")
                        .HasConstraintName("FK_current_state")
                        .IsRequired();

                    b.HasOne("PizzaApp.DataAccess.Models.State", "NextStateNavigation")
                        .WithMany("TransitionsNextStateNavigation")
                        .HasForeignKey("NextStateId")
                        .HasConstraintName("FK_next_state")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
