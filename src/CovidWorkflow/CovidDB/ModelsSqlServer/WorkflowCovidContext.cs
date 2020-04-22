using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CovidDB.ModelsSqlServer
{
    public partial class WorkflowCovidContext : DbContext
    {
       
        public WorkflowCovidContext(DbContextOptions<WorkflowCovidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anamnesis> Anamnesis { get; set; }
        public virtual DbSet<AnamnesisPatient> AnamnesisPatient { get; set; }
        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<Bed> Bed { get; set; }
        public virtual DbSet<BedPatient> BedPatient { get; set; }
        public virtual DbSet<CovidStatus> CovidStatus { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationPatient> LocationPatient { get; set; }
        public virtual DbSet<MedicalTests> MedicalTests { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientMedicalTest> PatientMedicalTest { get; set; }
        public virtual DbSet<PatientStatus> PatientStatus { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<StatusMedicalTest> StatusMedicalTest { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anamnesis>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AnamnesisPatient>(entity =>
            {
                entity.HasKey(e => new { e.Idpatient, e.Idanamnesis });

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idanamnesis).HasColumnName("IDAnamnesis");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdanamnesisNavigation)
                    .WithMany(p => p.AnamnesisPatient)
                    .HasForeignKey(d => d.Idanamnesis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnamnesisPatient_Anamnesis");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.AnamnesisPatient)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnamnesisPatient_Patient");
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TableName });

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.Property(e => e.DateTimeModified).HasColumnType("datetime");

                entity.Property(e => e.KeyValues)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NewValues).HasMaxLength(1000);

                entity.Property(e => e.OldValues).HasMaxLength(1000);
            });

            modelBuilder.Entity<Bed>(entity =>
            {
                entity.HasKey(e => e.Idbed)
                    .HasName("PK_BedInRoom");

                entity.Property(e => e.Idbed).HasColumnName("IDBed");

                entity.Property(e => e.Idroom).HasColumnName("IDRoom");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdroomNavigation)
                    .WithMany(p => p.Bed)
                    .HasForeignKey(d => d.Idroom)
                    .HasConstraintName("FK_BedInRoom_PatientRoom");
            });

            modelBuilder.Entity<BedPatient>(entity =>
            {
                entity.HasKey(e => new { e.Idpatient, e.Idbed });

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idbed).HasColumnName("IDBed");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.HasOne(d => d.IdbedNavigation)
                    .WithMany(p => p.BedPatient)
                    .HasForeignKey(d => d.Idbed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BedPatient_Bed");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.BedPatient)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BedPatient_Patient");
            });

            modelBuilder.Entity<CovidStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LocationPatient>(entity =>
            {
                entity.HasKey(e => new { e.Idpatient, e.Idlocation });

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idlocation).HasColumnName("IDLocation");

                entity.Property(e => e.DateModif).HasColumnType("datetime");

                entity.HasOne(d => d.IdlocationNavigation)
                    .WithMany(p => p.LocationPatient)
                    .HasForeignKey(d => d.Idlocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationPatient_Location");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.LocationPatient)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationPatient_Patient");
            });

            modelBuilder.Entity<MedicalTests>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comments).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PatientMedicalTest>(entity =>
            {
                entity.HasKey(e => new { e.Idpacient, e.IdmedicalTest });

                entity.Property(e => e.Idpacient).HasColumnName("IDPacient");

                entity.Property(e => e.IdmedicalTest).HasColumnName("IDMedicalTest");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.IdmedicalTestStatus).HasColumnName("IDMedicalTestStatus");

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.HasOne(d => d.IdmedicalTestNavigation)
                    .WithMany(p => p.PatientMedicalTest)
                    .HasForeignKey(d => d.IdmedicalTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientMedicalTest_MedicalTests");

                entity.HasOne(d => d.IdpacientNavigation)
                    .WithMany(p => p.PatientMedicalTest)
                    .HasForeignKey(d => d.Idpacient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientMedicalTest_Patient");
            });

            modelBuilder.Entity<PatientStatus>(entity =>
            {
                entity.HasKey(e => new { e.Idpatient, e.Idstatus });

                entity.Property(e => e.Idpatient).HasColumnName("IDPatient");

                entity.Property(e => e.Idstatus).HasColumnName("IDStatus");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.HasOne(d => d.IdpatientNavigation)
                    .WithMany(p => p.PatientStatus)
                    .HasForeignKey(d => d.Idpatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientStatus_Patient");

                entity.HasOne(d => d.IdstatusNavigation)
                    .WithMany(p => p.PatientStatus)
                    .HasForeignKey(d => d.Idstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientStatus_CovidStatus");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<StatusMedicalTest>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
