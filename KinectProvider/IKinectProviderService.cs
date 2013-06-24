using KinectData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KinectProvider
{
	[ServiceContract]
	public interface IKinectProviderService
	{
		[OperationContract]
		Kinect GetData ( Kinect composite );
	}
}
