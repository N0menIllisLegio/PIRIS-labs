using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIRIS_labs.Data.Entities
{
  public class DepositPlan: IEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public decimal Percent { get; set; }
    public int DayPeriod { get; set; }
    public bool Revocable { get; set; }
  }
}
