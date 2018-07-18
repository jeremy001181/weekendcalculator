using number_of_weekends;
using NUnit.Framework;
using System;
using System.Globalization;

namespace NumberOfWeekends.UnitTests
{
    [TestFixture]
    public class Class1
    {
        [TestCase("17/07/2018", "19/07/2018", 0, Description = "Both start and end date are in same week, and they are not weekends")]
        [TestCase("22/07/2018", "19/08/2018", 9, Description = "29 days and start date on Sunday")]
        [TestCase("18/07/2018", "28/07/2018", 3, Description = "End date on Saturday")]
        [TestCase("21/07/2018", "22/07/2018", 2, Description = "Both start and end date are weekends and in same week")]
        [TestCase("20/07/2018", "24/07/2018", 2, Description = "End date is on next week while start date is on previous week")]
        public void Should_calculate_correctly(string dateStart, string dateEnd, int expected)
        {
            var start = DateTime.ParseExact(dateStart, "d/M/yyyy", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(dateEnd, "d/M/yyyy", CultureInfo.InvariantCulture);
            var actual = WeekendCalculator.GetTotalNUmberOfWeekends(start, end);
            Assert.AreEqual(expected, actual);
        }
    }
}
