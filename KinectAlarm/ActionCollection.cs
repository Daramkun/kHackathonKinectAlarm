using KinectData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KinectAlarm
{
    public static class ActionCollection
    {
        static List<Kinect.Joint[]> actionList = new List<Kinect.Joint[]>();

        public static async void LoadData()
        {
            actionList.Clear();
            try
            {
                StorageFile storageFile = await StorageFile.GetFileFromPathAsync("actionList.dat");
            }
            catch { }
        }

        public static async void SaveData()
        {
            StorageFile storageFile = await StorageFile.CreateStreamedFileAsync("actionList.dat", null, null);
        }
    }
}
