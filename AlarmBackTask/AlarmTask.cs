using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;

namespace AlarmBackTask
{
	public sealed class AlarmTask : IBackgroundTask
    {
		public void Run ( IBackgroundTaskInstance taskInstance )
		{
			var toaster = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier ();
			var xml = new XmlDocument ();
			xml.LoadXml ( "<toast><visual version='1'><binding template='ToastText01'>" +
				"<text id='1'>열정적인 아침</text><text id='2'>" + "" +
				"</text></binding></visual></toast>" );
			toaster.Show ( new Windows.UI.Notifications.ToastNotification ( xml ) );
			Debug.WriteLine ( "15!!!!!!!!!!!!!!!!!!!!!!!" );
		}
	}
}
