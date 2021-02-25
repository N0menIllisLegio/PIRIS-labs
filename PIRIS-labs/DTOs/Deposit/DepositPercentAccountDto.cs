using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.DTOs.Deposit
{
  public class DepositPercentAccountDto
  {
    public decimal Percent { get; set; }
    public Account Account { get; set; }
    public Data.Entities.Deposit Deposit { get; set; }
  }
}
