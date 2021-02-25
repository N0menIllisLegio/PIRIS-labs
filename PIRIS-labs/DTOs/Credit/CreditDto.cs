using System;

namespace PIRIS_labs.DTOs.Credit
{
  public class CreditDto
  {
    public Guid ID { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
    public bool Closed { get; set; }

    public string CreditPlan { get; set; }
    public bool Anuity { get; set; }

    public string Client { get; set; }

    public decimal MonthlyPayment { get; set; }
  }
}
