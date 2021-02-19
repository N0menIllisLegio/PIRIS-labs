using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.DTOs.Deposit
{
  public class CreateDepositDto
  {
    [Required]
    [Range(0, 99999999999999, ErrorMessage = "Amount cant be negative")]
    public decimal Amount { get; set; }

    [Required]
    public Guid ClientID { get; set; }

    [Required]
    public Guid DepositPlanID { get; set; }
  }
}