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
                IRandomAccessStream raStream = await storageFile.OpenAsync(FileAccessMode.Read);
                DataReader reader = new DataReader(raStream);
                reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf16LE;
                reader.ByteOrder = ByteOrder.LittleEndian;

                await reader.LoadAsync((uint)raStream.Size);

                int dataLength = reader.ReadInt32();
                for (int i = 0; i < dataLength; i++)
                {
                    Alarm alarm = new Alarm(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadString(128));
                    alarmList.Add(alarm);
                }

                raStream.Dispose();
            }
            catch
            {
            }
        }

        public static async void saveData(Action finishAction = null)
        {
            StorageFile storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("alarmList.dat",
                CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream raStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
            DataWriter writer = new DataWriter(raStream);
            writer.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf16LE;
            writer.ByteOrder = ByteOrder.LittleEndian;

            writer.WriteInt32(alarmList.Count);
            foreach (Alarm a in alarmList)
            {
                writer.WriteInt32((int)a.dateType);
                writer.WriteInt32(a.timeForAlarm.Hours);
                writer.WriteInt32(a.timeForAlarm.Minutes);
                writer.WriteString(a.alarmMemo.PadRight(128));
            }

            await writer.FlushAsync();
            await writer.StoreAsync();
            raStream.Dispose();
            if (finishAction != null)
                finishAction();
        }
    }
}
