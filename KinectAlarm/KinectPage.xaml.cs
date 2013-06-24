using KinectData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace KinectAlarm
{
	public sealed partial class KinectPage : Page
	{
		KinectProviderServiceClient client;

		public KinectPage ()
		{
			this.InitializeComponent ();
		}

		private void SetPosition ( Ellipse eliipse, Kinect.Joint joint )
		{
			Canvas.SetLeft ( eliipse, joint.X * 300 + skeletonCanvas.ActualWidth / 2 );
            Canvas.SetTop(eliipse, -joint.Y * 300 + skeletonCanvas.ActualHeight / 2);
		}

		protected override void OnNavigatedTo ( NavigationEventArgs e )
		{

		}

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            client = new KinectProviderServiceClient(new BasicHttpBinding(),
                new EndpointAddress(new Uri("http://localhost:49172/KinectProviderService.svc", UriKind.RelativeOrAbsolute)));
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromTicks(333333);
            timer.Tick += async (object s, object ee) =>
            {
                Kinect data;
                try
                {
                    data = await client.GetDataAsync(new Kinect());
                }
                catch { return; }

                if (data == null) { textNotice.Text = "Kinect data is lost."; return; }
                if (!data.IsConnected) { textNotice.Text = "Kinect is not connected."; return; }
                if (data.Skeleton == null || data.Skeleton.Length == 0) { textNotice.Text = "Skeleton is not found."; return; }
                textNotice.Text = "";

                SetPosition(boneHead, data.Skeleton[(int)Kinect.JointType.Head]);
                SetPosition(boneShoulderCenter, data.Skeleton[(int)Kinect.JointType.ShoulderCenter]);
                SetPosition(boneShoulderLeft, data.Skeleton[(int)Kinect.JointType.ShoulderLeft]);
                SetPosition(boneShoulderRight, data.Skeleton[(int)Kinect.JointType.ShoulderRight]);
                SetPosition(boneSpine, data.Skeleton[(int)Kinect.JointType.Spine]);
                SetPosition(boneHipCenter, data.Skeleton[(int)Kinect.JointType.HipCenter]);
                SetPosition(boneHipLeft, data.Skeleton[(int)Kinect.JointType.HipLeft]);
                SetPosition(boneHipRight, data.Skeleton[(int)Kinect.JointType.HipRight]);
                SetPosition(boneKneeLeft, data.Skeleton[(int)Kinect.JointType.KneeLeft]);
                SetPosition(boneKneeRight, data.Skeleton[(int)Kinect.JointType.KneeRight]);
                SetPosition(boneAnkleLeft, data.Skeleton[(int)Kinect.JointType.AnkleLeft]);
                SetPosition(boneAnkleRight, data.Skeleton[(int)Kinect.JointType.AnkleRight]);
                SetPosition(boneFootLeft, data.Skeleton[(int)Kinect.JointType.FootLeft]);
                SetPosition(boneFootRight, data.Skeleton[(int)Kinect.JointType.FootRight]);
                SetPosition(boneElbowLeft, data.Skeleton[(int)Kinect.JointType.ElbowLeft]);
                SetPosition(boneElbowRight, data.Skeleton[(int)Kinect.JointType.ElbowRight]);
                SetPosition(boneWristLeft, data.Skeleton[(int)Kinect.JointType.WristLeft]);
                SetPosition(boneWristRight, data.Skeleton[(int)Kinect.JointType.WristRight]);
                SetPosition(boneHandLeft, data.Skeleton[(int)Kinect.JointType.HandLeft]);
                SetPosition(boneHandRight, data.Skeleton[(int)Kinect.JointType.HandRight]);
            };
            timer.Start();
        }
	}
}
