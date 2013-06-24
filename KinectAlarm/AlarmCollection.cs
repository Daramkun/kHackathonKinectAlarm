using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace KinectAlarm
{
    public static class AlarmCollection
    {
        static ObservableCollection<Alarm> alarmList = new ObservableCollection<Alarm>();

        public static void addAlarm(Alarm inputAlarm)
        {
            alarmList.Add(inputAlarm);
        }

        public static void removeAlarm(int index)
        {
            alarmList.RemoveAt(index);
        }

        public static ObservableCollection<Alarm> AlarmList { get { return alarmList; } }

        public static async void loadData()
        {
            alarmList.Clear();
            try
            {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("alarmList.dat");
                using (IRandomAccessStream raStream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    DataReader reader = new DataReader(raStream);

                    reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                    reader.ByteOrder = ByteOrder.LittleEndian;

                    int dataLength = reader.ReadInt32();
                    for (int i = 0; i < dataLength; i++)
                    {
                        Alarm alarm = new Alarm(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadString(255));
                        alarmList.Add(alarm);
                    }
                }
            }
            catch
            {
            }
        }

        public static async void saveData()
        {
            StorageFile storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("alarmList.dat",
                CreationCollisionOption.ReplaceExisting);
            using (IRandomAccessStream raStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                DataWriter writer = new DataWriter(raStream);
                writer.WriteInt32(alarmList.Count);
                foreach (Alarm a in alarmList)
                {
                    writer.WriteInt32((int)a.dateType);
                    writer.WriteInt32(a.timeForAlarm.Hours);
                    writer.WriteInt32(a.timeForAlarm.Minutes);
                    writer.WriteString(a.alarmMemo);
                }

                await writer.FlushAsync();
                await writer.StoreAsync();
            }
        }
    }
}
