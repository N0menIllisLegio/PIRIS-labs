using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.DTOs.ATM
{
  public class AtmMobilePhoneDto
    {
        [Required]
        [RegularExpression(@"(^\+375[0-9]{9}$)|(^$)", ErrorMessage = "Invalid mobile phone format.")]
        public string MobilePhoneNumber { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Entered amount should be in range [1, 100000]")]
        public decimal Amount { get; set; }
    }
}