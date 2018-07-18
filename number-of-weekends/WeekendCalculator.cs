using System;

namespace number_of_weekends
{
    public class WeekendCalculator
    {
        public static int GetTotalNUmberOfWeekends(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            if (dateTimeEnd < dateTimeStart)
                throw new ArgumentException("dataTimeEnd cannot be before dateTimeStart");

            var totalDays = (dateTimeEnd - dateTimeStart).Days + 1;

            var numberOfWeeks = totalDays/ 7;

            return numberOfWeeks * 2 + CalculateRestOfDays(dateTimeStart.AddDays(numberOfWeeks * 7), dateTimeEnd);

        }

        private static int CalculateRestOfDays(DateTime newStartDay, DateTime endDate)
        {
        //    if (v <= 0)  return 0;

            var start = newStartDay.DayOfWeek;
            var end = endDate.DayOfWeek;

            if (end < start)
                return 2;
            else
                return end == DayOfWeek.Saturday || end == DayOfWeek.Sunday ? 1 : 0;
            //var days = 0;
            //if (start == DayOfWeek.Saturday || start == DayOfWeek.Sunday)
            //    days++;
            //if (end == DayOfWeek.Saturday || end == DayOfWeek.Sunday)
            //    days++;

            //return days;
        }
    }
}
