using KinectData;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace KinectProvider
{
	public class KinectProviderService : IKinectProviderService
	{
		KinectSensor kinectSensor;

		public KinectProviderService ()
		{
			KinectSensor.KinectSensors.StatusChanged += ( object sender, StatusChangedEventArgs e ) =>
			{
				if ( e.Status == KinectStatus.Connected )
				{
					kinectSensor = e.Sensor;
					SetupKinectSensor ();
				}
			};

			new Thread ( () =>
			{
				if ( KinectSensor.KinectSensors.Count <= 0 )
				{
					kinectSensor = KinectSensor.KinectSensors [ 0 ];
					SetupKinectSensor ();
				}
			} ).Start ();
		}

		private void SetupKinectSensor ()
		{
			kinectSensor.SkeletonStream.Enable ();
			kinectSensor.ColorStream.Enable ();
		}

		public Kinect GetData ( Kinect composite )
		{
			composite.IsKinectConnected = ( kinectSensor != null );
			if ( kinectSensor != null )
			{
				using ( ColorImageFrame imageFrame = kinectSensor.ColorStream.OpenNextFrame ( 0 ) )
				{
					byte [] pixelData = new byte [ imageFrame.Width * imageFrame.Height * imageFrame.BytesPerPixel ];
					imageFrame.CopyPixelDataTo ( pixelData );
					composite.ImageFrame = pixelData;
				}

				using ( SkeletonFrame skeletonFrame = kinectSensor.SkeletonStream.OpenNextFrame ( 0 ) )
				{
					Skeleton [] skeletons = new Skeleton [ 6 ];
					skeletonFrame.CopySkeletonDataTo ( skeletons );
					Skeleton skeleton = skeletons [ 0 ];
					composite.Skeleton = new Kinect.Joint [ 20 ];
					foreach ( Joint joint in skeleton.Joints )
					{
						composite.Skeleton [ 0 ] = new Kinect.Joint ()
						{
							JointType = ( Kinect.JointType ) joint.JointType,
							X = joint.Position.X,
							Y = joint.Position.Y,
							Z = joint.Position.Z
						};
					}
				}
			}
			else
			{
				composite.ImageFrame = null;
				composite.Skeleton = null;
			}
			return composite;
		}
	}
}
