using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.DTOs.ATM
{
  public class InputNumberDto
  {
    [Required]
    [Range(1, 100000, ErrorMessage = "Entered amount should be in range [1, 100000]")]
    public decimal Number { get; set; }
  }
}
