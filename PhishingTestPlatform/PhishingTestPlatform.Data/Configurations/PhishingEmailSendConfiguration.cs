using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhishingTestPlatform.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PhishingTestPlatform.Data.Configurations
{
    public class PhishingEmailSendConfiguration : IEntityTypeConfiguration<PhishingEmailSend>
    {
        public void Configure(EntityTypeBuilder<PhishingEmailSend> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.TemplateId).IsRequired();
            builder.Property(x => x.IsClicked).IsRequired();

            builder.HasOne(x => x.EmailTemplates)
                .WithMany(x => x.PhishingEmailSend)
                .HasForeignKey(x => x.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
