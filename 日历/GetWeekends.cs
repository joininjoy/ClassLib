using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Utilities
{
    public class GetWeekends
    {
        public void GetWeekends() { }
        protected List<DateTime> GetWeekendsList()
        {
            List<DateTime> Weekends = new List<DateTime>();
            try
            {
                Int32 Year = DateTime.Now.Year;
                Boolean IsLeapYear = DateTime.IsLeapYear(Year);
                DateTime FirstDayOfYear = new DateTime(Year, 1, 1);
                DateTime LastDayOfYear = new DateTime(Year, 12, 31);
                #region
                //for (Int32 i = 0; FirstDayOfYear <= LastDayOfYear; i++)
                //{
                //    if (FirstDayOfYear.DayOfWeek == DayOfWeek.Saturday || FirstDayOfYear.DayOfWeek == DayOfWeek.Sunday)
                //    {
                //        Weekends.Add(FirstDayOfYear);
                //        FirstDayOfYear = FirstDayOfYear.AddDays(1);
                //    }
                //    else
                //    {
                //        FirstDayOfYear = FirstDayOfYear.AddDays(1);
                //    }
                //}
                #endregion
                while (FirstDayOfYear <= LastDayOfYear)
                {
                    if (FirstDayOfYear.DayOfWeek == DayOfWeek.Saturday || FirstDayOfYear.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Weekends.Add(FirstDayOfYear);
                    }
                    FirstDayOfYear = FirstDayOfYear.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
                string ErrorMessage = "Some Error happened.";
            }
            return Weekends;
        }

    }
}
