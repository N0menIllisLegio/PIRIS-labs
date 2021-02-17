using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIRIS_labs.Data.Entities
{
  public class DepositPlan
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }
    public decimal Percent { get; set; }
    public int DayPeriod { get; set; }
    public bool Revocable { get; set; }

    public virtual ICollection<Deposit> Deposits { get; set; }

    public Guid MainAccountPlanID { get; set; }
    [Required]
    public virtual AccountPlan MainAccountPlan { get; set; }

    public Guid PercentAccountPlanID { get; set; }
    [Required]
    public virtual AccountPlan PercentAccountPlan { get; set; }
  }
}
