﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PIRIS_labs.Data.Entities
{
  public class User: IdentityUser<Guid>
  {
    [Required]
    [MaxLength(250)]
    public string Surname { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    [Required]
    [MaxLength(250)]
    public string Patronymic { get; set; }

    [Required]
    public DateTime Birthday { get; set; }

    [Required]
    public bool Male { get; set; }

    [Required]
    [MaxLength(250)]
    public string BirthPlace { get; set; }

    [Required]
    public virtual City ActualResidenceCity { get; set; }

    [Required]
    [MaxLength(250)]
    public string ActualResidenceAddress { get; set; }

    [MaxLength(250)]
    public string HomePhoneNumber { get; set; }

    [MaxLength(250)]
    public string MobilePhoneNumber { get; set; }

    [MaxLength(250)]
    public string WorkPlace { get; set; }

    [MaxLength(250)]
    public string Position { get; set; }

    [Required]
    public virtual City RegistrationCity { get; set; }

    [Required]
    [MaxLength(250)]
    public string RegistrationAddress { get; set; }

    [Required]
    public virtual MaritalStatus MaritalStatus { get; set; }

    [Required]
    public virtual Nationality Nationality { get; set; }

    [Required]
    public virtual Disability Disability { get; set; }

    [Required]
    public bool Pensioner { get; set; }

    public int? MonthlyIncome { get; set; }

    [Required]
    public bool LiableForMilitaryService { get; set; }

    [Required]
    [MaxLength(250)]
    public string PassportSeries { get; set; }

    [Required]
    [MaxLength(250)]
    public string PassportNumber { get; set; }

    [Required]
    [MaxLength(250)]
    public string PassportIssuedBy { get; set; }

    [Required]
    public DateTime PassportIssuedDate { get; set; }

    [Required]
    [MaxLength(250)]
    public string IdentificationNumber { get; set; }
  }
}
