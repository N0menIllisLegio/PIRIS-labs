using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIRIS_labs.Data.Entities
{
  public class Transaction: IEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    public decimal Amount { get; set; }
    public DateTime TransactionTime { get; set; }

    [Required]
    public virtual Account TransferToAccount { get; set; }
    public string TransferToAccountNumber { get; set; }

    [Required]
    public virtual Account TransferFromAccount { get; set; }
    public string TransferFromAccountNumber { get; set; }
  }
}
