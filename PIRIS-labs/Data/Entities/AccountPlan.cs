using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PIRIS_labs.Enums;

namespace PIRIS_labs.Data.Entities
{
  public class AccountPlan: IEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    [Required]
    [StringLength(4)]
    public string AccountNumber { get; set; }

    [Required]
    [StringLength(250)]
    public string AccountName { get; set; }

    [Required]
    public AccountType AccountType { get; set; }

    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<DepositPlan> MainAccountPlanOfDeposits { get; set; }
    public virtual ICollection<DepositPlan> PercentAccountPlanOfDeposits { get; set; }
  }
}
