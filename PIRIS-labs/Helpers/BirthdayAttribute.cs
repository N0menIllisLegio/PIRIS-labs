using System;
using System.ComponentModel.DataAnnotations;

namespace PIRIS_labs.Helpers
{
  public class BirthdayAttribute: RangeAttribute
  {
    public BirthdayAttribute()
      : base(typeof(DateTime),
              DateTime.Today.AddYears(-150).ToShortDateString(),
              DateTime.Today.AddYears(-18).ToShortDateString())
    { }

    public override string FormatErrorMessage(string name)
    {
      return "Client should be at least 18 years old";
    }
  }
}
