using System;
using System.ComponentModel.DataAnnotations;
using PIRIS_labs.Enums;
using PIRIS_labs.Helpers;

namespace PIRIS_labs.DTOs.Client
{
  public class ClientDto
  {
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Patronymic { get; set; }
    [Required]
    [Birthday]
    public DateTime Birthday { get; set; }
    [Required]
    public Gender Gender { get; set; }
    [Required]
    public string BirthPlace { get; set; }

    [Required]
    public string ActualResidenceCity { get; set; }
    [Required]
    public string ActualResidenceAddress { get; set; }
    [Required]
    public string RegistrationCity { get; set; }
    [Required]
    public string RegistrationAddress { get; set; }

    [RegularExpression(@"(^80[0-9]{9}$)|(^$)", ErrorMessage = "Invalid home phone format.")]
    public string HomePhoneNumber { get; set; }
    [RegularExpression(@"(^\+375[0-9]{9}$)|(^$)", ErrorMessage = "Invalid mobile phone format.")]
    public string MobilePhoneNumber { get; set; }
    public string Email { get; set; }

    [Required]
    public string PassportSeries { get; set; }
    [Required]
    [RegularExpression(@"^[0-9]{7}$", ErrorMessage = "Invalid passport number.")]
    public string PassportNumber { get; set; }
    [Required]
    public string PassportIssuedBy { get; set; }
    [Required]
    [PassportIssueDate]
    public DateTime PassportIssuedDate { get; set; }
    [Required]
    [RegularExpression(@"^[0-9]{7}[A-Z][0-9]{3}(PB|РВ)[0-9]$", ErrorMessage = "Invalid identification number.")]
    public string IdentificationNumber { get; set; }

    public string WorkPlace { get; set; }
    public string Position { get; set; }

    [Required]
    public string MaritalStatus { get; set; }
    [Required]
    public string Nationality { get; set; }
    [Required]
    public string Disability { get; set; }

    public int? MonthlyIncome { get; set; }

    [Required]
    public bool Pensioner { get; set; }
    [Required]
    public bool LiableForMilitaryService { get; set; }
  }
}