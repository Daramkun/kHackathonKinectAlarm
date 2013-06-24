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

// 기본 페이지 항목 템플릿에 대한 설명은 http://go.microsoft.com/fwlink/?LinkId=234237에 나와 있습니다.

namespace KinectAlarm
{
	public sealed partial class AddActionPage : KinectAlarm.Common.LayoutAwarePage
	{
		KinectProviderServiceClient client;
		DispatcherTimer kinectTimer = new DispatcherTimer ();
		DispatcherTimer counterTimer = new DispatcherTimer ();
		bool isKinectConnected = false;

        Kinect.Joint[] currentAction;

		public AddActionPage ()
		{
			this.InitializeComponent ();
		}

		protected override void LoadState ( Object navigationParameter, Dictionary<String, Object> pageState )
		{
		}

		protected override void SaveState ( Dictionary<String, Object> pageState )
		{
		}

		private void SetPosition ( Ellipse eliipse, Kinect.Joint joint )
		{
			Canvas.SetLeft ( eliipse, joint.X * 300 + skeletonCanvas.ActualWidth / 2 );
			Canvas.SetTop ( eliipse, -joint.Y * 300 + skeletonCanvas.ActualHeight / 2 );
		}

		private void pageRoot_Loaded ( object sender, RoutedEventArgs e )
		{
			client = new KinectProviderServiceClient ( new BasicHttpBinding (),
				new EndpointAddress ( new Uri ( "http://localhost:49172/KinectProviderService.svc", UriKind.RelativeOrAbsolute ) ) );
			kinectTimer.Interval = TimeSpan.FromTicks ( 333333 );
			kinectTimer.Tick += async ( object s, object ee ) =>
			{
				Kinect data;
				try
				{
					data = await client.GetDataAsync ( new Kinect () );
				}
				catch ( Exception ex )
				{
					textNotice.Text = String.Format ( "문제가 발생했습니다:{0}",
						ex );
					return;
				}

				if ( data == null )
				{
					textNotice.Text = "키넥트 데이터가 소실되었습니다.";
					isKinectConnected = false;
					return;
				}
				if ( !data.IsConnected )
				{
					textNotice.Text = "키넥트가 연결되지 않았습니다.";
					isKinectConnected = false;
					return;
				}
				if ( data.Skeleton == null || data.Skeleton.Length == 0 )
				{
					textNotice.Text = "사람을 찾지 못했습니다.";
					isKinectConnected = false;
					return;
				}
				textNotice.Text = "";
				isKinectConnected = true;

				if ( textBoxCounter.Text == "0" ) return;

                currentAction = data.Skeleton;

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
			};
			kinectTimer.Start ();
			counterTimer.Interval = TimeSpan.FromSeconds ( 1 );
			counterTimer.Tick += ( object s, object ee ) =>
			{
				if ( isKinectConnected )
				{
					int count = int.Parse ( textBoxCounter.Text ) - 1;
					if ( count < 0 ) return;
					textBoxCounter.Text = count.ToString ();
				}
			};
			counterTimer.Start ();
		}

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxCounter.Text = "10";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ActionCollection.AddAction(currentAction);
            ActionCollection.SaveData();
            Frame.GoBack();
        }
	}
}
