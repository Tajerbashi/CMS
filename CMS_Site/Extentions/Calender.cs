using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
namespace CMS_Site
{
    public static class Calender
    {
       public static string PersionCalender(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value)+"/"+
                   pc.GetMonth(value).ToString("00")+"/"+
                   pc.GetDayOfMonth(value).ToString("00");
        }
    }
}