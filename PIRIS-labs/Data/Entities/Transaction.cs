using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIRIS_labs.Data.Entities
{
  public class Transaction
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDay { get; set; }

    public Guid DebetAccountID { get; set; }
    [Required]
    public virtual Account DebitAccount { get; set; }

    public Guid CreditAccountID { get; set; }
    [Required]
    public virtual Account CreditAccount { get; set; }
  }
}
