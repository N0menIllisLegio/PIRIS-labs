using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PIRIS_labs.Data.Entities
{
  public class CreditCard : IEntity
  {
    [Key]
    [StringLength(16, MinimumLength = 16)]
    public string Number { get; set; }

    public DateTime EndDate { get; set; }

    [Required]
    [StringLength(4, MinimumLength = 4)]
    public string PIN { get; set; }

    public virtual Client Owner { get; set; }

    [ForeignKey("Owner")]
    public Guid OwnerID { get; set; }

    public virtual Account CreditAccount { get; set; }

    [Required]
    [ForeignKey("CreditAccount")]
    public string CreditAccountNumber { get; set; }
  }
}
