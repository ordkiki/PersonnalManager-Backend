namespace PersonalManager.Application.Features.Banks.Query.GetBankBy
{
    public class GetBankByResponse
    {
        public Guid? Id { get; init; }
        public string? Rib { get; set; }
        public string? Iban { get; set; }
        public string? CountryCode { get; set; }
        public string? Bic { get; set; }
        public string? AccountLabel { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}