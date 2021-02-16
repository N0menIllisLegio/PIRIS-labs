using System.ComponentModel.DataAnnotations;
using PIRIS_labs.Helpers;

namespace PIRIS_labs.Data.Entities
{
  public class City : IEntity
  {
    [Key]
    [MaxLength(250)]
    [ExpressionsBuilder]
    public string Name { get; set; }
  }
}
