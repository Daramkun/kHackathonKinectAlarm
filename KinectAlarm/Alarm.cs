using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectAlarm
{
    public class Alarm
    {
        public enum DateType { WeekDay = 0, Weekend = 1, DayByDay = 2 }
        public DateType dateType { get; set; }
        public TimeSpan timeForAlarm { get; set; }
        public String alarmMemo { get; set; }

        public Alarm(int inputDateType, int h, int m, String memo)
        {
            dateType = (DateType)inputDateType;

            timeForAlarm = new TimeSpan(h, m, 0);
            alarmMemo = memo;
        }

    }
}
