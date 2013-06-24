using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace KinectAlarm
{
    public static class AlarmCollection
    {
        static List<Alarm> alarmList = new List<Alarm>();

        public static void addAlarm(Alarm inputAlarm)
        {
            alarmList.Add(inputAlarm);
        }

        public static void removeAlarm(int index)
        {
            alarmList.RemoveAt(index);
        }

        public static async void loadData()
        {
            alarmList.Clear();
            try
            {
                StorageFile storageFile = await StorageFile.GetFileFromPathAsync("alarmList.dat");
                using (IRandomAccessStream raStream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    DataReader reader = new DataReader(raStream);
                    int dataLength = reader.ReadInt32();
                    for (int i = 0; i < dataLength; i++)
                    {
                        Alarm alarm = new Alarm(reader.ReadString(255), reader.ReadInt32(), reader.ReadInt32(), reader.ReadString(255));\
                        alarmList.Add(alarm);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
