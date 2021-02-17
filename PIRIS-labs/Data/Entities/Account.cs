using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIRIS_labs.Data.Entities
{
  public class Account
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    [Required]
    [StringLength(13)]
    public string AccountNumber { get; set; }

    public decimal DebitValue { get; set; }
    public decimal CreditValue { get; set; }
    public decimal Balance { get; set; }

    public Guid AccountPlanID { get; set; }
    [Required]
    public virtual AccountPlan AccountPlan { get; set; }

    public virtual ICollection<Deposit> MainAccountDeposits { get; set; }
    public virtual ICollection<Deposit> PercentAccountDeposits { get; set; }

    public virtual ICollection<Transaction> CreditTransactions { get; set; }
    public virtual ICollection<Transaction> DebitTransactions { get; set; }
  }
}
