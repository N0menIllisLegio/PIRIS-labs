using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.Data.Entities
{
  public class Credit: IEntity
  {
    public Guid ID { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }

    [Required]
    public virtual Account MainAccount { get; set; }
    public string MainAccountNumber { get; set; }

    [Required]
    public virtual Account PercentAccount { get; set; }
    public string PercentAccountNumber { get; set; }

    [Required]
    public virtual Client Client { get; set; }
    public Guid ClientID { get; set; }

    [Required]
    public virtual CreditPlan CreditPlan { get; set; }
    public Guid CreditPlanID { get; set; }
  }
}
