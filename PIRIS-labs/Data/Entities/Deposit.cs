using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIRIS_labs.Data.Entities
{
  public class Deposit: IEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }

    public bool Closed { get; set; }

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
    public virtual DepositPlan DepositPlan { get; set; }

    public Guid DepositPlanID { get; set; }
  }
}