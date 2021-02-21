using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.DTOs.Credit
{
  public class CreditPlanDto
  {
    public Guid ID { get; set; }

    [Required]
    [MinLength(5)]
    public string Name { get; set; }

    [Required]
    [Range(12, 480, ErrorMessage = "Month period should be in [12, 480]")]
    public int MonthPeriod { get; set; }

    [Required]
    [Range(1, 5000, ErrorMessage = "Percent should be in [1, 5000]")]
    public decimal Percent { get; set; }

    [Range(1, 100_000_000_000, ErrorMessage = "Min amount should be in [1, 100_000_000_000] or NULL")]
    public decimal? MinAmount { get; set; }
    public bool Anuity { get; set; }
  }
}
