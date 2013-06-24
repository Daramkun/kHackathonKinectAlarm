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
		public Kinect GetData ( Kinect composite )
        {
            KinectSensor kinectSensor = null;
            if (KinectSensor.KinectSensors.Count > 0)
            {
                kinectSensor = KinectSensor.KinectSensors[0];
                if (kinectSensor != null)
                {
                    if (!(kinectSensor.Status == KinectStatus.Initializing ||
                        kinectSensor.Status == KinectStatus.Connected))
                        kinectSensor = null;
                    while (kinectSensor.Status != KinectStatus.Connected) ;
                    kinectSensor.SkeletonStream.Enable();
                    kinectSensor.ColorStream.Enable();
                    kinectSensor.Start();
                }
            }
            else
            {
                if (kinectSensor != null)
                    kinectSensor.Stop();
                kinectSensor = null;
            }

			if ( kinectSensor != null )
			{
                composite.IsConnected = true;
				using ( SkeletonFrame skeletonFrame = kinectSensor.SkeletonStream.OpenNextFrame ( 0 ) )
				{
                    Skeleton[] skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
					skeletonFrame.CopySkeletonDataTo ( skeletons );
                    foreach (Skeleton skeleton in skeletons)
                    {
                        if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            composite.Skeleton = new Kinect.Joint[20];
                            foreach (Joint joint in skeleton.Joints)
                            {
                                composite.Skeleton[(int)joint.JointType] = new Kinect.Joint()
                                {
                                    JointType = (Kinect.JointType)joint.JointType,
                                    X = joint.Position.X,
                                    Y = joint.Position.Y,
                                    Z = joint.Position.Z
                                };
                            }
                        }
                        else composite.Skeleton = null;
                    }
				}
			}
			else
			{
                composite.IsConnected = false;
				composite.Skeleton = null;
			}
			return composite;
		}
	}
}
