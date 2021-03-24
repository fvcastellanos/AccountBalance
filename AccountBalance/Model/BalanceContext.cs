using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AccountBalance.Model
{
    public partial class BalanceContext : DbContext
    {
        public BalanceContext()
        {
        }

        public BalanceContext(DbContextOptions<BalanceContext> options): base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistory { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ScheduledTransaction> ScheduledTransactions { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionDetail> TransactionsDetails { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<UserTenant> UserTenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("idx_account_number");

                entity.HasIndex(e => e.AccountTypeId)
                    .HasName("fk_account_account_type1_idx");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_account_name");

                entity.HasIndex(e => e.ProviderId)
                    .HasName("fk_account_provider_idx");

                entity.HasIndex(e => e.Tenant)
                    .HasName("idx_account_tenant");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnName("account_number")
                    .HasMaxLength(150);

                entity.Property(e => e.AccountNumber1)
                    .HasColumnName("accountNumber")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountTypeId)
                    .HasColumnName("account_type_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.ProviderId)
                    .HasColumnName("provider_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bank_account_account_type1");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bank_account_bank");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("account_type");

                entity.HasIndex(e => e.Tenant)
                    .HasName("idx_account_type_tenant");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<FlywaySchemaHistory>(entity =>
            {
                entity.HasKey(e => e.InstalledRank)
                    .HasName("PRIMARY");

                entity.ToTable("flyway_schema_history");

                entity.HasIndex(e => e.Success)
                    .HasName("flyway_schema_history_s_idx");

                entity.Property(e => e.InstalledRank).HasColumnName("installed_rank");

                entity.Property(e => e.Checksum).HasColumnName("checksum");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");

                entity.Property(e => e.InstalledBy)
                    .IsRequired()
                    .HasColumnName("installed_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnName("script")
                    .HasMaxLength(1000);

                entity.Property(e => e.Success).HasColumnName("success");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("provider");

                entity.HasIndex(e => e.Tenant)
                    .HasName("idx_provider_tenant");

                entity.HasIndex(e => new { e.Name, e.Country })
                    .HasName("UQ_NAME_COUNTRY")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'GT'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<ScheduledTransaction>(entity =>
            {
                entity.ToTable("scheduled_transaction");

                entity.HasIndex(e => e.AccountId)
                    .HasName("fk_scheduled_transaction_account1_idx");

                entity.HasIndex(e => e.Tenant)
                    .HasName("idx_scheduled_transaction_tenant");

                entity.HasIndex(e => e.TransactionTypeId)
                    .HasName("fk_scheduled_transaction_transaction_type1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Cron)
                    .IsRequired()
                    .HasColumnName("cron")
                    .HasMaxLength(250);

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("transaction_type_id")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ScheduledTransaction)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_scheduled_transaction_account1");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.ScheduledTransaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_scheduled_transaction_transaction_type1");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("tenant");

                entity.HasIndex(e => e.Code)
                    .HasName("code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction");

                entity.HasIndex(e => e.AccountId)
                    .HasName("fk_transaction_account1_idx");

                entity.HasIndex(e => e.Tenant)
                    .HasName("idx_transaction_tenant");

                entity.HasIndex(e => e.TransactionTypeId)
                    .HasName("fk_transaction_transaction_type1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("currency")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'GTQ'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("transaction_type_id")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transaction_bank_account1");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transaction_transaction_type1");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.ToTable("transaction_detail");

                entity.HasIndex(e => e.Tenant)
                    .HasName("idx_transaction_detail_tenant");

                entity.HasIndex(e => e.TransactionId)
                    .HasName("fk_transaction_detail_transaction1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ImagePath).HasColumnName("image_path");

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionDetail)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transaction_detail_transaction1");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_type");

                entity.HasIndex(e => e.Tenant)
                    .HasName("idx_transaction_type_tenant");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Credit).HasColumnName("credit");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<UserTenant>(entity =>
            {
                entity.ToTable("user_tenant");

                entity.HasIndex(e => new { e.Username, e.Tenant })
                    .HasName("uq_user_tenant")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Tenant)
                    .IsRequired()
                    .HasColumnName("tenant")
                    .HasMaxLength(150);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
