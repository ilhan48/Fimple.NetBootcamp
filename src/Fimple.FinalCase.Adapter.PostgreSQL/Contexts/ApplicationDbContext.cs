using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Contexts;

public class ApplicationDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Process> Processes { get; set; }
    public DbSet<Transfer> Transfers { get; set; }
    public DbSet<PaymentPlan> PaymentPlans { get; set; }
    public DbSet<CreditApplication> CreditApplications { get; set; }
    public DbSet<SupportTicket> SupportTickets { get; set; }
    public DbSet<AutomaticPayment> AutomaticPayments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transfer>()
        .HasOne(t => t.SenderAccount)
        .WithMany(a => a.Transfers)
        .HasForeignKey(t => t.SenderAccountId);

        modelBuilder.Entity<Transfer>()
            .HasOne(t => t.ReceiverAccount)
            .WithMany()
            .HasForeignKey(t => t.ReceiverAccountId);

        base.OnModelCreating(modelBuilder);
    }

}