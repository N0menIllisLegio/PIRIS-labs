using System;

namespace PIRIS_labs.DTOs.ATM
{
  public class CashWithdrawlDto
  {
    public string Number { get; set; }
    public string ClientFullName { get; set; }

    public decimal Amount { get; set; }
    public DateTime TransactionTime { get; set; }
    public string CreditAccountNumber { get; set; }
  }
}
