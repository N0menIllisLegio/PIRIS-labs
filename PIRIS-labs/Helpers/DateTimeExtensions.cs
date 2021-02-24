using System;

namespace PIRIS_labs.Helpers
{
  public static class DateTimeExtensions
  {
    public static int GetMonthDifference(this DateTime startDate, DateTime endDate)
    {
      int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
      return Math.Abs(monthsApart);
    }

    public static int DaysInMonth(this DateTime date)
    {
      return DateTime.DaysInMonth(date.Year, date.Month);
    }
  }
}
