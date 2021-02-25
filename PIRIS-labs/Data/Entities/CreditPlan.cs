using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.Data.Entities
{
  public class CreditPlan: IEntity
  {
    public Guid ID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public int MonthPeriod { get; set; }
    public decimal Percent { get; set; }
    public decimal? MinAmount { get; set; }
    public bool Anuity { get; set; }
  }
}
