using System;

namespace PIRIS_labs.DTOs.Deposit
{
  public class DepositDto
  {
    public Guid ID { get; set; }
    public decimal Amount { get; set; }
    public DateTime EndDate { get; set; }
    public string DepositPlan { get; set; }
    public string Client { get; set; }
    public decimal AccumulatedAmount { get; set; }
    public bool Closed { get; set; }
    public bool Revocable { get; set; }
  }
}