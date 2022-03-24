using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TNS_API.Data
{
    public partial class TNS_Context : DbContext
    {
        public TNS_Context()
            : base("name=TNS_Context")
        {
        }

        public virtual DbSet<Abonent> Abonent { get; set; }
        public virtual DbSet<AbonentEquipment> AbonentEquipment { get; set; }
        public virtual DbSet<BaseStation> BaseStation { get; set; }
        public virtual DbSet<BaseStationAddresses> BaseStationAddresses { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Magistral> Magistral { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<RayonsSPb> RayonsSPb { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SetiDostupa> SetiDostupa { get; set; }
        public virtual DbSet<TabelEmployee> TabelEmployee { get; set; }
        public virtual DbSet<Tarif> Tarif { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonent>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.AddressProposki)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.AddressProzivania)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.Pasport)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.CodePodrazdelenia)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.KemVidan)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.DogovorNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.DogovorType)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.PrichinaRastorzenia)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .Property(e => e.DovorArendi)
                .IsUnicode(false);

            modelBuilder.Entity<Abonent>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.Abonent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Abonent>()
                .HasMany(e => e.Tarif)
                .WithMany(e => e.Abonent)
                .Map(m => m.ToTable("AbonentTarifs").MapLeftKey("AbonentId").MapRightKey("TarifId"));

            modelBuilder.Entity<Abonent>()
                .HasMany(e => e.Service)
                .WithMany(e => e.Abonent)
                .Map(m => m.ToTable("ServiceToAbonent").MapLeftKey("AbonentId").MapRightKey("ServiceId"));

            modelBuilder.Entity<AbonentEquipment>()
                .Property(e => e.SeriesNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AbonentEquipment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AbonentEquipment>()
                .Property(e => e.Ports)
                .IsUnicode(false);

            modelBuilder.Entity<AbonentEquipment>()
                .Property(e => e.Standart)
                .IsUnicode(false);

            modelBuilder.Entity<AbonentEquipment>()
                .Property(e => e.Speed)
                .IsUnicode(false);

            modelBuilder.Entity<AbonentEquipment>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<AbonentEquipment>()
                .HasMany(e => e.Abonent)
                .WithRequired(e => e.AbonentEquipment)
                .HasForeignKey(e => e.EquipmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaseStation>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BaseStation>()
                .Property(e => e.AntenaType)
                .IsUnicode(false);

            modelBuilder.Entity<BaseStation>()
                .Property(e => e.DiaposonPokazateley)
                .IsUnicode(false);

            modelBuilder.Entity<BaseStation>()
                .Property(e => e.Standart)
                .IsUnicode(false);

            modelBuilder.Entity<BaseStation>()
                .Property(e => e.Coords)
                .IsUnicode(false);

            modelBuilder.Entity<BaseStation>()
                .HasMany(e => e.BaseStationAddresses)
                .WithRequired(e => e.BaseStation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaseStationAddresses>()
                .Property(e => e.AdressPoshadki)
                .IsUnicode(false);

            modelBuilder.Entity<BaseStationAddresses>()
                .Property(e => e.MestoRaspolozenia)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TabelEmployee)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Magistral>()
                .Property(e => e.SeriesNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Magistral>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Magistral>()
                .Property(e => e.Koeffisient)
                .IsUnicode(false);

            modelBuilder.Entity<Magistral>()
                .Property(e => e.Technology)
                .IsUnicode(false);

            modelBuilder.Entity<Magistral>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Zadolzenost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<RayonsSPb>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RayonsSPb>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Tarif)
                .WithMany(e => e.Service)
                .Map(m => m.ToTable("ServiceToTarif").MapLeftKey("ServiceId").MapRightKey("TarifId"));

            modelBuilder.Entity<SetiDostupa>()
                .Property(e => e.SeriesNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SetiDostupa>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SetiDostupa>()
                .Property(e => e.Standart)
                .IsUnicode(false);

            modelBuilder.Entity<SetiDostupa>()
                .Property(e => e.Interfaces)
                .IsUnicode(false);

            modelBuilder.Entity<SetiDostupa>()
                .Property(e => e.Speed)
                .IsUnicode(false);

            modelBuilder.Entity<SetiDostupa>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<TabelEmployee>()
                .Property(e => e.Tabel)
                .IsUnicode(false);

            modelBuilder.Entity<Tarif>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tarif>()
                .Property(e => e.Usloviya)
                .IsUnicode(false);

            modelBuilder.Entity<Tarif>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
