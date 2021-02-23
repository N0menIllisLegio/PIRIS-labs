using System;
using System.Linq;
using System.Xml.Linq;

namespace PIRIS_labs.Services
{
  public class DateService
  {
    private const string _currentDateFilePath = "CurrentDate.xml";
    private const string _currentDateTagName = "currentDate";

    private readonly XDocument _currentDateFile;
    private readonly XElement _currentDateElement;

    public DateService()
    {
      if (System.IO.File.Exists(_currentDateFilePath))
      {
        _currentDateFile = XDocument.Load(_currentDateFilePath);
        _currentDateElement = _currentDateFile.Descendants(_currentDateTagName).First();
        Today = DateTime.Parse(_currentDateElement.Value);
      }
      else
      {
        Today = DateTime.Today;
        _currentDateFile = new XDocument(new XElement("SystemInfo",
                new XElement(_currentDateTagName, Today.ToShortDateString())));

        _currentDateFile.Save(_currentDateFilePath);
      }
    }

    public DateTime Today { get; private set; }

    public DateTime DaysPassed(int days)
    {
      Today = Today.AddDays(days);

      _currentDateElement.Value = Today.ToShortDateString();
      _currentDateFile.Save(_currentDateFilePath);

      return Today;
    }
  }
}
