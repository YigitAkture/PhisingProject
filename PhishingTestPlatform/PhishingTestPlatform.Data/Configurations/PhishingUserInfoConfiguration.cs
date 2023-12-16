using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhishingTestPlatform.Data.Models;

namespace PhishingTestPlatform.Data.Configurations
{
    public class PhishingUserInfoConfiguration : IEntityTypeConfiguration<PhishingUserInfo>
    {
        public void Configure(EntityTypeBuilder<PhishingUserInfo> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.CreditCardNumber).IsRequired().HasMaxLength(16);
            builder.Property(x => x.CreditCardExpirationDateMonth).IsRequired().HasMaxLength(2);
            builder.Property(x => x.CreditCardExpirationDateYear).IsRequired().HasMaxLength(4);
            builder.Property(x => x.CreditCardCVV).IsRequired().HasMaxLength(3);

            builder.HasOne(x => x.PhishingEmailSend)
                .WithOne(x => x.PhishingUserInfo)
                .HasForeignKey<PhishingUserInfo>(x => x.PhishingEmailSendId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
