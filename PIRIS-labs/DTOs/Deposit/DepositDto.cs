namespace PIRIS_labs.DTOs.Deposit
{
  public class DepositDto
  {
    public string DepositPlan { get; set; }
    public string Client { get; set; }
    public decimal Amount { get; set; }
    public decimal AccumulatedAmount { get; set; }
  }
}
