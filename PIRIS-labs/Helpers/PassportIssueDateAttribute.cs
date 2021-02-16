using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.Helpers
{
  public class PassportIssueDateAttribute: RangeAttribute
  {
    public PassportIssueDateAttribute()
      : base(typeof(DateTime),
              DateTime.Today.AddYears(-100).ToShortDateString(),
              DateTime.Today.AddDays(-1).ToShortDateString())
    { }

    public override string FormatErrorMessage(string name)
    {
      return $"Passport issue date cant be older than {DateTime.Today:d}";
    }
  }
}
