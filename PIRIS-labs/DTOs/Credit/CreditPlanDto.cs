using System;

namespace PIRIS_labs.DTOs.Credit
{
  public class CreditPlanDto
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int MonthPeriod { get; set; }
    public decimal Percent { get; set; }
    public decimal? MinAmount { get; set; }
    public bool Anuity { get; set; }
  }
}
