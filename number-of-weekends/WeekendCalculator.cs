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
            // Workout how many weeks it has
            var numberOfWeeks = totalDays/ 7;

            // Then move the start date forward and work out how many weekends is in the rest of days
            return numberOfWeeks * 2 + CalculateRestOfDays(dateTimeStart.AddDays(numberOfWeeks * 7), dateTimeEnd);

        }

        private static int CalculateRestOfDays(DateTime newStartDay, DateTime endDate)
        {
            var start = newStartDay.DayOfWeek;
            var end = endDate.DayOfWeek;

            if (end < start) // Saturday is 6, Sunday is 0, so if end is less than start , it definitely has weekends in between.
                return 2;
            else // in case of not, we just need to check whether or not the end day is landed on a weekend
                return end == DayOfWeek.Saturday || end == DayOfWeek.Sunday ? 1 : 0;
        }
    }
}
