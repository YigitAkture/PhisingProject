using Microsoft.EntityFrameworkCore;
using PhishingTestPlatform.Data.Configurations;
using PhishingTestPlatform.Data.Models;

namespace PhishingTestPlatform.Data
{
    public class PhishingDbContext : DbContext
    {
        public PhishingDbContext(DbContextOptions<PhishingDbContext> options) : base(options)
        {
        }

        public DbSet<PhishingUserInfo> PhishingInfo { get; set; }
        public DbSet<PhishingEmailSend> PhishingEmailsSend { get; set; }
        public DbSet<EmailTemplates> EmailTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PhishingUserInfo
            modelBuilder.ApplyConfiguration(new PhishingUserInfoConfiguration());

            // PhishingEmailSend
            modelBuilder.ApplyConfiguration(new PhishingEmailSendConfiguration());

            // EmailTemplates
            modelBuilder.ApplyConfiguration(new EmailTemplatesConfiguration());
        }
    }
}
