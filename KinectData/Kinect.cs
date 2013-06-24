using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace KinectData
{
	[DataContract]
    public class Kinect
    {
		[DataMember]
		public bool IsKinectConnected { get; set; }
		[DataMember]
		public byte [] ImageFrame { get; set; }
		[DataMember]
		public Joint [] Skeleton { get; set; }

		public enum JointType
		{
			HipCenter = 0,
			Spine = 1,
			ShoulderCenter = 2,
			Head = 3,
			ShoulderLeft = 4,
			ElbowLeft = 5,
			WristLeft = 6,
			HandLeft = 7,
			ShoulderRight = 8,
			ElbowRight = 9,
			WristRight = 10,
			HandRight = 11,
			HipLeft = 12,
			KneeLeft = 13,
			AnkleLeft = 14,
			FootLeft = 15,
			HipRight = 16,
			KneeRight = 17,
			AnkleRight = 18,
			FootRight = 19,
		}

		public struct Joint
		{
			public JointType JointType { get; set; }
			public float X { get; set; }
			public float Y { get; set; }
			public float Z { get; set; }
		}
	}
}
