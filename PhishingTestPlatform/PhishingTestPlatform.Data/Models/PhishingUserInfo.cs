namespace PhishingTestPlatform.Data.Models
{
    public class PhishingUserInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreditCardNumber { get; set; }
        public int CreditCardExpirationDateMonth { get; set; }
        public int CreditCardExpirationDateYear { get; set; }
        public string CreditCardCVV { get; set; }
        public Guid PhishingEmailSendId { get; set; }
        public PhishingEmailSend PhishingEmailSend { get; set; }
    }
}
