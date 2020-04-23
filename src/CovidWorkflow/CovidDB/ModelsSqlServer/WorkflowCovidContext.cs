using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CovidDB.ModelsSqlServer
{
    public partial class WorkflowCovidContext : DbContext
    {
        public WorkflowCovidContext()
        {
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WorkflowCovid;UID=sa;PWD=<YourStrong@Passw0rd>");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnamnesisPatient>(entity =>
            {
                entity.HasKey(e => new { e.Idpatient, e.Idanamnesis });

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
            });

            modelBuilder.Entity<Bed>(entity =>
            {
                entity.HasKey(e => e.Idbed)
                    .HasName("PK_BedInRoom");

                entity.HasOne(d => d.IdroomNavigation)
                    .WithMany(p => p.Bed)
                    .HasForeignKey(d => d.Idroom)
                    .HasConstraintName("FK_BedInRoom_PatientRoom");
            });

            modelBuilder.Entity<BedPatient>(entity =>
            {
                entity.HasKey(e => new { e.Idpatient, e.Idbed });

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

            modelBuilder.Entity<LocationPatient>(entity =>
            {
                entity.HasKey(e => new { e.Idpatient, e.Idlocation });

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

            modelBuilder.Entity<PatientMedicalTest>(entity =>
            {
                entity.HasKey(e => new { e.Idpacient, e.IdmedicalTest });

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
