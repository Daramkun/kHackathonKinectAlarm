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

		List<Kinect.Joint []> patterns;

		public KinectPage ()
		{
			this.InitializeComponent ();
			patterns = new List<Kinect.Joint []> ();
			if ( ActionCollection.ActionList.Count > 0 )
			{
				Random rand = new Random();
				for ( int i = 0; i < 3; i++ )
				{
					patterns.Add ( ActionCollection.ActionList [ rand.Next ( 0,
						ActionCollection.ActionList.Count ) ] );
				}
			}
			SetNextPattern ();
		}

		private void SetNextPattern ()
		{
			if ( patterns.Count == 0 )
			{
				if ( Frame.CanGoBack ) Frame.GoBack ();
				else Application.Current.Exit ();
			}

			Kinect.Joint [] skeleton = patterns [ 0 ];
			SetPosition ( patternHead, skeleton [ ( int ) Kinect.JointType.Head ] );
			SetPosition ( patternShoulderCenter, skeleton [ ( int ) Kinect.JointType.ShoulderCenter ] );
			SetPosition ( patternShoulderLeft, skeleton [ ( int ) Kinect.JointType.ShoulderLeft ] );
			SetPosition ( patternShoulderRight, skeleton [ ( int ) Kinect.JointType.ShoulderRight ] );
			SetPosition ( patternSpine, skeleton [ ( int ) Kinect.JointType.Spine ] );
			SetPosition ( patternHipCenter, skeleton [ ( int ) Kinect.JointType.HipCenter ] );
			SetPosition ( patternHipLeft, skeleton [ ( int ) Kinect.JointType.HipLeft ] );
			SetPosition ( patternHipRight, skeleton [ ( int ) Kinect.JointType.HipRight ] );
			SetPosition ( patternKneeLeft, skeleton [ ( int ) Kinect.JointType.KneeLeft ] );
			SetPosition ( patternKneeRight, skeleton [ ( int ) Kinect.JointType.KneeRight ] );
			SetPosition ( patternAnkleLeft, skeleton [ ( int ) Kinect.JointType.AnkleLeft ] );
			SetPosition ( patternAnkleRight, skeleton [ ( int ) Kinect.JointType.AnkleRight ] );
			SetPosition ( patternFootLeft, skeleton [ ( int ) Kinect.JointType.FootLeft ] );
			SetPosition ( patternFootRight, skeleton [ ( int ) Kinect.JointType.FootRight ] );
			SetPosition ( patternElbowLeft, skeleton [ ( int ) Kinect.JointType.ElbowLeft ] );
			SetPosition ( patternElbowRight, skeleton [ ( int ) Kinect.JointType.ElbowRight ] );
			SetPosition ( patternWristLeft, skeleton [ ( int ) Kinect.JointType.WristLeft ] );
			SetPosition ( patternWristRight, skeleton [ ( int ) Kinect.JointType.WristRight ] );
			SetPosition ( patternHandLeft, skeleton [ ( int ) Kinect.JointType.HandLeft ] );
			SetPosition ( patternHandRight, skeleton [ ( int ) Kinect.JointType.HandRight ] );
		}

		private void SetPosition ( Ellipse ellipse, Kinect.Joint joint )
		{
			Canvas.SetLeft ( ellipse, joint.X * 300 + skeletonCanvas.ActualWidth / 2 );
            Canvas.SetTop(ellipse, -joint.Y * 300 + skeletonCanvas.ActualHeight / 2);
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

				SetPosition ( boneHead, data.Skeleton [ ( int ) Kinect.JointType.Head ] );
				SetPosition ( boneShoulderCenter, data.Skeleton [ ( int ) Kinect.JointType.ShoulderCenter ] );
				SetPosition ( boneShoulderLeft, data.Skeleton [ ( int ) Kinect.JointType.ShoulderLeft ] );
				SetPosition ( boneShoulderRight, data.Skeleton [ ( int ) Kinect.JointType.ShoulderRight ] );
				SetPosition ( boneSpine, data.Skeleton [ ( int ) Kinect.JointType.Spine ] );
				SetPosition ( boneHipCenter, data.Skeleton [ ( int ) Kinect.JointType.HipCenter ] );
				SetPosition ( boneHipLeft, data.Skeleton [ ( int ) Kinect.JointType.HipLeft ] );
				SetPosition ( boneHipRight, data.Skeleton [ ( int ) Kinect.JointType.HipRight ] );
				SetPosition ( boneKneeLeft, data.Skeleton [ ( int ) Kinect.JointType.KneeLeft ] );
				SetPosition ( boneKneeRight, data.Skeleton [ ( int ) Kinect.JointType.KneeRight ] );
				SetPosition ( boneAnkleLeft, data.Skeleton [ ( int ) Kinect.JointType.AnkleLeft ] );
				SetPosition ( boneAnkleRight, data.Skeleton [ ( int ) Kinect.JointType.AnkleRight ] );
				SetPosition ( boneFootLeft, data.Skeleton [ ( int ) Kinect.JointType.FootLeft ] );
				SetPosition ( boneFootRight, data.Skeleton [ ( int ) Kinect.JointType.FootRight ] );
				SetPosition ( boneElbowLeft, data.Skeleton [ ( int ) Kinect.JointType.ElbowLeft ] );
				SetPosition ( boneElbowRight, data.Skeleton [ ( int ) Kinect.JointType.ElbowRight ] );
				SetPosition ( boneWristLeft, data.Skeleton [ ( int ) Kinect.JointType.WristLeft ] );
				SetPosition ( boneWristRight, data.Skeleton [ ( int ) Kinect.JointType.WristRight ] );
				SetPosition ( boneHandLeft, data.Skeleton [ ( int ) Kinect.JointType.HandLeft ] );
				SetPosition ( boneHandRight, data.Skeleton [ ( int ) Kinect.JointType.HandRight ] );

				MatchTest ();
            };
            timer.Start();
        }

		private void MatchTest ()
		{
			if ( patterns.Count == 0 ) return;

			Kinect.Joint [] pattern = patterns [ 0 ];

			if ( !CompareTwoEllipse ( boneHead, patternHead ) ) return;
			if ( !CompareTwoEllipse ( boneShoulderCenter, patternShoulderCenter ) ) return;
			if ( !CompareTwoEllipse ( boneShoulderLeft, patternShoulderLeft ) ) return;
			if ( !CompareTwoEllipse ( boneShoulderRight, patternShoulderRight ) ) return;
			if ( !CompareTwoEllipse ( boneSpine, patternSpine ) ) return;
			if ( !CompareTwoEllipse ( boneHipCenter, patternHipCenter ) ) return;
			if ( !CompareTwoEllipse ( boneHipLeft, patternHipLeft ) ) return;
			if ( !CompareTwoEllipse ( boneHipRight, patternHipRight ) ) return;
			if ( !CompareTwoEllipse ( boneKneeLeft, patternKneeLeft ) ) return;
			if ( !CompareTwoEllipse ( boneKneeRight, patternKneeRight ) ) return;
			if ( !CompareTwoEllipse ( boneAnkleLeft, patternAnkleLeft ) ) return;
			if ( !CompareTwoEllipse ( boneAnkleRight, patternAnkleRight ) ) return;
			if ( !CompareTwoEllipse ( boneFootLeft, patternFootLeft ) ) return;
			if ( !CompareTwoEllipse ( boneFootRight, patternFootRight ) ) return;
			if ( !CompareTwoEllipse ( boneElbowLeft, patternElbowLeft ) ) return;
			if ( !CompareTwoEllipse ( boneElbowRight, patternElbowRight ) ) return;
			if ( !CompareTwoEllipse ( boneWristLeft, patternWristLeft ) ) return;
			if ( !CompareTwoEllipse ( boneWristRight, patternWristRight ) ) return;
			if ( !CompareTwoEllipse ( boneHandLeft, patternHandLeft ) ) return;
			if ( !CompareTwoEllipse ( boneHandRight, patternHandRight ) ) return;

			patterns.RemoveAt ( 0 );
			SetNextPattern ();
		}

		private bool CompareTwoEllipse ( Ellipse e1, Ellipse e2 )
		{
			Point p1 = new Point ( Canvas.GetLeft ( e1 ), Canvas.GetTop ( e1 ) );
			Point p2 = new Point ( Canvas.GetLeft ( e2 ), Canvas.GetTop ( e2 ) );

			double distance = Math.Sqrt ( Math.Pow ( p2.X - p1.X, 2 ) + Math.Pow ( p2.Y - p1.Y, 2 ) );
			if ( distance <= e1.Width + e2.Width )
				return true;
			return false;
		}
	}
}
