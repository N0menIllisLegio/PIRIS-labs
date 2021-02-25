using System.ComponentModel.DataAnnotations;
using PIRIS_labs.Enums;

namespace PIRIS_labs.Data.Entities
{
  public class AccountPlan: IEntity
  {
    [Key]
    [StringLength(4)]
    public string Number { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }
    public AccountType Type { get; set; }
  }
}
