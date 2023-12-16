using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhishingTestPlatform.Data.Models;

namespace PhishingTestPlatform.Data.Configurations
{
    public class EmailTemplatesConfiguration : IEntityTypeConfiguration<EmailTemplates>
    {
        public void Configure(EntityTypeBuilder<EmailTemplates> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TemplateName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TemplateSubject).IsRequired().HasMaxLength(256);
            builder.Property(x => x.TemplateBody).IsRequired();
        }
    }
}
