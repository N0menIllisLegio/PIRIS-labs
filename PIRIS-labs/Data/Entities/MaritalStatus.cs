﻿using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.Data.Entities
{
  public class MaritalStatus
  {
    [Key]
    [MaxLength(250)]
    public string Name { get; set; }
  }
}