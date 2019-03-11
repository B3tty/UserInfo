using System;
using System.Linq;
using System.Collections.Generic;

namespace UserInfo.Storage
{
    public class IntervalHelper
    {
        public static double GetMinutesSpentOnSite(List<DateTime> dates)
        {
            var intervals = GetIntervals(dates);

            return GetMinutesFromIntervals(intervals);
        }

        private static List<(DateTime, DateTime)> GetIntervals(List<DateTime> dates)
        {
            var intervals = new List<(DateTime, DateTime)>();
            dates.Sort(DateTime.Compare);
            int i = 0;
            while (i < dates.Count)
            {
                var first = dates[i];
                var last = dates[i];
                var range = Enumerable.Range(i + 1, dates.Count - i - 1);
                foreach (int j in range)
                {
                    if (DateTime.Compare(last.AddMinutes(30), dates[j]) > 0)
                    {
                        last = dates[j];
                        i = j + 1;
                    }
                    else
                    {
                        i = j;
                        break;
                    }
                }
                intervals.Add((first, last));
                if (range.Count() == 0)
                {
                    break;
                }
            }
            return intervals;
        }

        private static double GetMinutesFromIntervals(List<(DateTime, DateTime)> intervals)
        {
            return intervals.Select(datePair => (datePair.Item2 - datePair.Item1).TotalMinutes + 1).Sum();
        }
    }
}
