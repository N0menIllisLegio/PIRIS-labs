using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.Data.Entities
{
  public class Currency: IEntity
  {
    [Key]
    [MaxLength(20)]
    public string Code { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    [Required]
    [MaxLength(10)]
    public string Symbol { get; set; }
  }
}
