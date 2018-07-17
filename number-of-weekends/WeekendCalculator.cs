using System;

namespace number_of_weekends
{
    public class WeekendCalculator
    {
        public static int GetTotalNUmberOfWeekends(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            if (dateTimeEnd < dateTimeStart)
                throw new ArgumentException("dataTimeEnd cannot be before dateTimeStart");

            var totalDays = (dateTimeEnd - dateTimeStart).Days;

            var howManyWeeks = totalDays/ 7;

            return howManyWeeks * 2 + CalculateRestOfDays(totalDays % 7, dateTimeStart);

        }

        private static int CalculateRestOfDays(int v, DateTime date)
        {
            if (v <= 0)  return 0;

            var start = date.DayOfWeek;
            var end = date.AddDays(v).DayOfWeek;

            if (end < start)
                return 2;

            var days = 0;
            if (start == DayOfWeek.Saturday || start == DayOfWeek.Sunday)
                days++;
            if (end == DayOfWeek.Saturday || end == DayOfWeek.Sunday)
                days++;

            return days;
        }
    }
}
