using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.DTOs.Deposit
{
  public class DepositPlanDto
  {
    public Guid ID { get; set; }
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    [Range(0, 100, ErrorMessage = "Percent should be in [0, 100]")]
    public decimal Percent { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Days value can't be negative")]
    public int DayPeriod { get; set; }
    public bool Revocable { get; set; }

    public override string ToString()
    {
      return $"{Name} {Percent} %";
    }
  }
}
