using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.DTOs.Deposit
{
  public class DepositPercentAccountDto
  {
    public decimal Percent { get; set; }
    public decimal DepositAmount { get; set; }
    public Account Account { get; set; }
  }
}
