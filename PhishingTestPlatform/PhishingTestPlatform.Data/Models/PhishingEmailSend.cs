using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhishingTestPlatform.Data.Models
{
    public class PhishingEmailSend
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Guid TemplateId { get; set; }
        public EmailTemplates EmailTemplates { get; set; }
        public int Status { get; set; }
        public bool IsClicked { get; set; }
        public PhishingUserInfo PhishingUserInfo { get; set; }
    }
}
