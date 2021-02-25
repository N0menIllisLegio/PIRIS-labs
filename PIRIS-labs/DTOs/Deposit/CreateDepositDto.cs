using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.DTOs.Deposit
{
  public class CreateDepositDto
  {
    [Required]
    [Range(100, 99999999999999, ErrorMessage = "Amount can be in [100, 99999999999999]")]
    public decimal Amount { get; set; }

    [Required]
    public Guid ClientID { get; set; }

    [Required]
    public Guid DepositPlanID { get; set; }
  }
}