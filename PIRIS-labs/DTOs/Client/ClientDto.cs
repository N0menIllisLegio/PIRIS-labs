using System;

namespace PIRIS_labs.DTOs.Client
{
  public class ClientDto
  {
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }
    public bool Male { get; set; }
    public string BirthPlace { get; set; }
    public string ActualResidenceCity { get; set; }
    public string ActualResidenceAddress { get; set; }
    public string HomePhoneNumber { get; set; }
    public string MobilePhoneNumber { get; set; }
    public string WorkPlace { get; set; }
    public string Position { get; set; }
    public string RegistrationCity { get; set; }
    public string Email { get; set; }
    public string RegistrationAddress { get; set; }
    public string MaritalStatus { get; set; }
    public string Nationality { get; set; }
    public string Disability { get; set; }
    public bool Pensioner { get; set; }
    public int? MonthlyIncome { get; set; }
    public bool LiableForMilitaryService { get; set; }
    public string PassportSeries { get; set; }
    public string PassportNumber { get; set; }
    public string PassportIssuedBy { get; set; }
    public DateTime PassportIssuedDate { get; set; }
    public string IdentificationNumber { get; set; }
  }
}