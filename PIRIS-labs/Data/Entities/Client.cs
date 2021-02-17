using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PIRIS_labs.Enums;
using PIRIS_labs.Helpers;

namespace PIRIS_labs.Data.Entities
{
  public class Client: IEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }

    [Required]
    [MaxLength(250)]
    [ExpressionsBuilder]
    public string Surname { get; set; }

    [Required]
    [MaxLength(250)]
    [ExpressionsBuilder]
    public string Name { get; set; }

    [Required]
    [MaxLength(250)]
    [ExpressionsBuilder]
    public string Patronymic { get; set; }

    [Required]
    public DateTime Birthday { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    [MaxLength(250)]
    public string BirthPlace { get; set; }

    public string ActualResidenceCityName { get; set; }
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

    public string RegistrationCityName { get; set; }
    [Required]
    public virtual City RegistrationCity { get; set; }

    [MaxLength(250)]
    public string Email { get; set; }

    [Required]
    [MaxLength(250)]
    public string RegistrationAddress { get; set; }

    public string MaritalStatusName { get; set; }
    [Required]
    public virtual MaritalStatus MaritalStatus { get; set; }

    public string NationalityName { get; set; }
    [Required]
    public virtual Nationality Nationality { get; set; }

    public string DisabilityName { get; set; }
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
