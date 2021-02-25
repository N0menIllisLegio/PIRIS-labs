using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.DTOs.ATM
{
  public class CreditCardDto
  {
    [Required]
    [RegularExpression(@"^[0-9]{16}$")]
    public string Number { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]{4}$")]
    public string PIN { get; set; }

    public Guid OwnerID { get; set; }
    public string CreditAccountNumber { get; set; }
  }
}
