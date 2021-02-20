namespace PIRIS_labs.DTOs.Common
{
  public class AccountDto
  {
    public string Number { get; set; }
    public string AccountPlanName { get; set; }
    public decimal DebitValue { get; set; }
    public decimal CreditValue { get; set; }
    public decimal Balance { get; set; }
  }
}
