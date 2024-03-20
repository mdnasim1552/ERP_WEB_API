using System;
using System.Collections.Generic;
using ERP_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acinf> Acinfs { get; set; }

    public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }

    public virtual DbSet<Backupstatus> Backupstatuses { get; set; }

    public virtual DbSet<Commodinf> Commodinfs { get; set; }

    public virtual DbSet<Compinf> Compinfs { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<Databackup> Databackups { get; set; }

    public virtual DbSet<ErrorlogBk> ErrorlogBks { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<Hrginf> Hrginfs { get; set; }

    public virtual DbSet<Interface> Interfaces { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobParameter> JobParameters { get; set; }

    public virtual DbSet<JobQueue> JobQueues { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Salginf> Salginfs { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<Sirinf> Sirinfs { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TbleCity> TbleCities { get; set; }

    public virtual DbSet<Userinf> Userinfs { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    public virtual DbSet<Usrimginf> Usrimginfs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acinf>(entity =>
        {
            entity.HasKey(e => new { e.Comcod, e.Actcode }).HasName("PK_ACINF_1");

            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Actcode).IsFixedLength();
            entity.Property(e => e.Acgcode).HasDefaultValue("");
            entity.Property(e => e.Actdesc).HasDefaultValue("");
            entity.Property(e => e.Actelev).HasDefaultValue("");
            entity.Property(e => e.Acttdesc).HasDefaultValue("");
            entity.Property(e => e.Acttype).HasDefaultValue("");
            entity.Property(e => e.Cfcode).HasDefaultValue("");
            entity.Property(e => e.Docpath).HasDefaultValue("");
            entity.Property(e => e.Usercode).HasDefaultValue("");
            entity.Property(e => e.Wodesc).HasDefaultValue("");
        });

        modelBuilder.Entity<AggregatedCounter>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_HangFire_CounterAggregated");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");
        });

        modelBuilder.Entity<Backupstatus>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Ftppath).HasDefaultValue("");
            entity.Property(e => e.Latestbk).HasDefaultValue("");
            entity.Property(e => e.Latestmaxbk).HasDefaultValue("");
            entity.Property(e => e.Upldate).HasDefaultValue("");
        });

        modelBuilder.Entity<Commodinf>(entity =>
        {
            entity.HasKey(e => new { e.Comcod, e.Moduleid }).HasName("PK_COMMODINF_1");

            entity.Property(e => e.Comcod)
                .HasDefaultValue("0000")
                .IsFixedLength();
            entity.Property(e => e.Moduleid).HasDefaultValue("");
            entity.Property(e => e.Modulename).HasDefaultValue("");
        });

        modelBuilder.Entity<Compinf>(entity =>
        {
            entity.Property(e => e.Comcod)
                .HasDefaultValue("0000")
                .IsFixedLength();
            entity.Property(e => e.Comadd1).HasDefaultValue("");
            entity.Property(e => e.Comadd2).HasDefaultValue("");
            entity.Property(e => e.Comadd3).HasDefaultValue("");
            entity.Property(e => e.Comadd4).HasDefaultValue("");
            entity.Property(e => e.Comnam).HasDefaultValue("");
            entity.Property(e => e.Comsnam).HasDefaultValue("");
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_Counter");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Databackup>(entity =>
        {
            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Ftppassword).HasDefaultValue("");
            entity.Property(e => e.Ftpserver).HasDefaultValue("");
            entity.Property(e => e.Ftpuploadpath).HasDefaultValue("");
            entity.Property(e => e.Ftpusername).HasDefaultValue("");
        });

        modelBuilder.Entity<ErrorlogBk>(entity =>
        {
            entity.Property(e => e.Comcod).IsFixedLength();
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Field }).HasName("PK_HangFire_Hash");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");
        });

        modelBuilder.Entity<Hrginf>(entity =>
        {
            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Hrgdesc).HasDefaultValue("");
            entity.Property(e => e.Hrgdescb).HasDefaultValue("");
            entity.Property(e => e.Hrgdescbn).HasDefaultValue("");
            entity.Property(e => e.Hrgval)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.Percnt).HasDefaultValue(0m);
            entity.Property(e => e.Rankcode).HasDefaultValue("");
            entity.Property(e => e.Rate).HasDefaultValue(0m);
            entity.Property(e => e.Slno).HasDefaultValue(0);
            entity.Property(e => e.Unit).HasDefaultValue("");

            entity.HasOne(d => d.ComcodNavigation).WithMany(p => p.Hrginfs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HRGINF_COMPINF");
        });

        modelBuilder.Entity<Interface>(entity =>
        {
            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Interfaceid).IsFixedLength();

            entity.HasOne(d => d.ComcodNavigation).WithMany(p => p.Interfaces)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INTERFACE_COMPINF");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Job");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName").HasFilter("([StateName] IS NOT NULL)");
        });

        modelBuilder.Entity<JobParameter>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Name }).HasName("PK_HangFire_JobParameter");

            entity.HasOne(d => d.Job).WithMany(p => p.JobParameters).HasConstraintName("FK_HangFire_JobParameter_Job");
        });

        modelBuilder.Entity<JobQueue>(entity =>
        {
            entity.HasKey(e => new { e.Queue, e.Id }).HasName("PK_HangFire_JobQueue");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_List");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Salginf>(entity =>
        {
            entity.Property(e => e.Comcod)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.Color).HasDefaultValue("");
            entity.Property(e => e.Gdesc).HasDefaultValue("");
            entity.Property(e => e.Gval)
                .HasDefaultValue("t")
                .IsFixedLength();
            entity.Property(e => e.Slno).HasDefaultValue(99);
            entity.Property(e => e.Symbol).HasDefaultValue("");
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK_HangFire_Schema");

            entity.Property(e => e.Version).ValueGeneratedNever();
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Server");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Value }).HasName("PK_HangFire_Set");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");
        });

        modelBuilder.Entity<Sirinf>(entity =>
        {
            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Sircode).IsFixedLength();
            entity.Property(e => e.Actcode)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.Deptcod).HasDefaultValue("");
            entity.Property(e => e.Empid).HasDefaultValue("");
            entity.Property(e => e.Hrcomadd).HasDefaultValue("");
            entity.Property(e => e.Hrcomaddb).HasDefaultValue("");
            entity.Property(e => e.Hrcomname).HasDefaultValue("");
            entity.Property(e => e.Hrsection).HasDefaultValue("");
            entity.Property(e => e.Incoterms)
                .HasDefaultValue("00000")
                .IsFixedLength();
            entity.Property(e => e.Method).HasDefaultValue("");
            entity.Property(e => e.Prodprocess).HasDefaultValue("000000000000");
            entity.Property(e => e.Rowdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Sirdesc).HasDefaultValue("");
            entity.Property(e => e.Sirdescb).HasDefaultValue("");
            entity.Property(e => e.Sirtdes).HasDefaultValue("");
            entity.Property(e => e.Sirtype).HasDefaultValue("");
            entity.Property(e => e.Sirunit).HasDefaultValue("");
            entity.Property(e => e.Untcod).HasDefaultValue("");
            entity.Property(e => e.Usercode).HasDefaultValue("");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Id }).HasName("PK_HangFire_State");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Job).WithMany(p => p.States).HasConstraintName("FK_HangFire_State_Job");
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__TblCount__D32076BC31E27EE1");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TblUsers__CB9A1CFFF2893D2C");

            entity.HasOne(d => d.UserCityNavigation).WithMany(p => p.TblUsers).HasConstraintName("FK__TblUsers__userCi__46E78A0C");
        });

        modelBuilder.Entity<TbleCity>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__TbleCity__B4BEB95E49CB416D");

            entity.HasOne(d => d.Country).WithMany(p => p.TbleCities).HasConstraintName("FK__TbleCity__countr__267ABA7A");
        });

        modelBuilder.Entity<Userinf>(entity =>
        {
            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Usrid).IsFixedLength();
            entity.Property(e => e.Empid).HasDefaultValue("");
            entity.Property(e => e.Mailid).HasDefaultValue("");
            entity.Property(e => e.Userrole)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.Usrdesig).HasDefaultValue("");
            entity.Property(e => e.Usrname).HasDefaultValue("");
            entity.Property(e => e.Usrpass).HasDefaultValue("");
            entity.Property(e => e.Usrsname).HasDefaultValue("");

            entity.HasOne(d => d.UserroleNavigation).WithMany(p => p.Userinfs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERINF_COMPINF");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.Property(e => e.Roleid).IsFixedLength();
            entity.Property(e => e.Role).HasDefaultValue("");
        });

        modelBuilder.Entity<Usrimginf>(entity =>
        {
            entity.Property(e => e.Comcod).IsFixedLength();
            entity.Property(e => e.Usrid).IsFixedLength();
            entity.Property(e => e.Remarks).HasDefaultValue("");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
