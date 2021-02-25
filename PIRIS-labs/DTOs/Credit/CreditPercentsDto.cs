using System;

namespace PIRIS_labs.DTOs.Credit
{
  public class CreditPercentsDto
  {
    public int RowNumber { get; set; }
    public DateTime Date { get; set; }

    public decimal MainDebth { get; set; }
    public decimal PercentDebth { get; set; }
    public decimal PaymentSum { get; set; }
  }
}
