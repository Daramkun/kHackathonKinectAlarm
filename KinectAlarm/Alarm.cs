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
        DateType dateType;
        TimeSpan timeForAlarm;
        String alarmMemo;

        public Alarm(String inputDateType, int h, int m, String memo)
        {
            if (inputDateType == "WeekDay")
                dateType = DateType.WeekDay;
            else if(inputDateType = "

            timeForAlarm = new TimeSpan(h, m, 0);
            alarmMemo = memo;
        }
    }
}
