using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PizzaApp.DataAccess.Models
{
    public partial class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext()
        {
        }

        public PizzaAppDbContext(DbContextOptions<PizzaAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PizzaSize> PizzaSize { get; set; }
        public virtual DbSet<PizzaType> PizzaType { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StateType> StateType { get; set; }
        public virtual DbSet<Transition> Transitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=PizzaAppDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TimeSubmited).HasColumnType("datetime");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pizza");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_state");
            });

            modelBuilder.Entity<PizzaSize>(entity =>
            {
                entity.Property(x => x.PizzaSizeId)
                .HasConversion<int>();

                entity.
                   HasData
                       (
                       Enum.GetValues(typeof(PizzaSizeId))
                       .Cast<PizzaSizeId>().Select(x => new PizzaSize
                       {
                           PizzaSizeId = x,
                           Size = x.ToString()
                       }));

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("PizzaSize")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PizzaType>(entity =>
            {

                entity.Property(x => x.PizzaTypeId)
                    .HasConversion<int>();

                entity.
                    HasData
                        (
                        Enum.GetValues(typeof(PizzaTypeId))
                        .Cast<PizzaTypeId>().Select(x => new PizzaType
                        {
                            PizzaTypeId = x,
                            TypeOfPizza = x.ToString()
                        }));

                entity.Property(e => e.TypeOfPizza)
                    .IsRequired()
                    .HasColumnName("PizzaType")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasOne(d => d.PizzaSize)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.PizzaSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pizza_size");

                entity.HasOne(d => d.PizzaType)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.PizzaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pizza_type");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateTypeId)
                        .HasConversion<int>();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.StateType)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.StateTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_state_type");
            });

            modelBuilder.Entity<StateType>(entity =>
            {
                entity.Property(x => x.StateTypeId).HasConversion<int>();

                
                entity.HasData(
                Enum.GetValues(typeof(StateTypeId))
                    .Cast<StateTypeId>()
                    .Select(e => new StateType()
                    {
                        StateTypeId = e,
                        Type = e.ToString()
                    })
            );

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("StateType")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Transition>(entity =>
            {
                entity.HasOne(d => d.NextStateNavigation)
                    .WithMany(p => p.TransitionsNextStateNavigation)
                    .HasForeignKey(d => d.NextStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_next_state");

                entity.HasOne(d => d.CurrentStateNavigation)
                    .WithMany(p => p.TransitionsStateNavigation)
                    .HasForeignKey(d => d.CurrentStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_current_state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
