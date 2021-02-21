using System;
using PIRIS_labs.Data.Entities;

namespace PIRIS_labs.DTOs.Credit
{
  public class CreditPercentAccountDto
  {
    public Account PercentAccount { get; set; }
    public decimal CreditPercent { get; set; }
    public decimal CreditAmount { get; set; }
    public bool Anuity { get; set; }
    public int Months { get; set; }
    public DateTime StartDate { get; set; }
  }
}
