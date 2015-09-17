using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatePicker
/// 
/// Written By Craig Smith 9/17/15
/// 
/// Used to provid a list of dates
/// </summary>

namespace cisseniorproject.utils
{

    public class DatePicker
    {

        public DatePicker()
        {
        }
        //returns a list of dates starting from today to <int days> back
        public static List<DateTime> getDatesBeforeToday(int days)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime date = System.DateTime.Now;
            dates.Add(date);

            for (int i = 0; i <= days; i++)
            {
                date = subtractOneDay(date);
                dates.Add(date);
            }

            return dates;
        }
        
        public static List<DateTime> getDatesAfterToday(int days)
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime date = System.DateTime.Now;
            dates.Add(date);

            for (int i = 0; i <= days; i++)
            {
                date = addOneDay(date);
                dates.Add(date);
            }

            return dates;
        }

        private static DateTime subtractOneDay(DateTime date)
        {
            return date.AddDays(-1);

        }

        private static DateTime addOneDay(DateTime date)
        {
            return date.AddDays(1);
        }

    }
}