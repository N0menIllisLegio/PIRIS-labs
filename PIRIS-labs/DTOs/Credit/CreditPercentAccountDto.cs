using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.DTOs.Credit
{
  public class CreditPercentAccountDto
  {
    public Account PercentAccount { get; set; }
    public Data.Entities.Credit Credit { get; set; }
    public decimal CreditPercent { get; set; }
    public bool Anuity { get; set; }
    public int Months { get; set; }
  }
}
