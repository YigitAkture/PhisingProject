namespace PhishingTestPlatform.UI.Views.Models
{
    public class CreditCardViewModel
    {
        public Guid Id { get; set; }

        public string NameSurname { get; set; }
        public string CreditCardNumber { get; set; }
        public int CreditCardExpirationMonth { get; set; }
        public int CreditCardExpirationYear { get; set; }
        public string CreditCardCVV { get; set; }
    }
}
