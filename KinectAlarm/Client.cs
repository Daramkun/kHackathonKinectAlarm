using KinectData;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace KinectAlarm
{
	[GeneratedCode ( "System.ServiceModel", "4.0.0.0" )]
	[ServiceContract ( ConfigurationName = "IKinectProviderService" )]
	public interface IKinectProviderService
	{
		[OperationContractAttribute ( Action = "http://127.0.0.1:49172/IKinectProviderService/GetData",
			ReplyAction = "http://127.0.0.1:49172/IKinectProviderService/GetDataResponse" )]
		Kinect GetData ( Kinect composite );
		[OperationContractAttribute ( Action = "http://127.0.0.1:49172/IKinectProviderService/GetData",
			ReplyAction = "http://127.0.0.1:49172/IKinectProviderService/GetDataResponse" )]
		Task<Kinect> GetDataAsync ( Kinect composite );
	}

	[GeneratedCode ( "System.ServiceModel", "4.0.0.0" )]
	public interface IKinectProviderServiceChannel : IKinectProviderService, IClientChannel { }

	[DebuggerStepThroughAttribute ()]
	[GeneratedCodeAttribute ( "System.ServiceModel", "4.0.0.0" )]
	public partial class KinectProviderServiceClient : ClientBase<IKinectProviderService>, IKinectProviderService
	{
		public KinectProviderServiceClient () { }
		public KinectProviderServiceClient ( string endpointConfigurationName ) :
			base ( endpointConfigurationName ) { }
		public KinectProviderServiceClient ( string endpointConfigurationName, string remoteAddress ) :
			base ( endpointConfigurationName, remoteAddress ) { }
		public KinectProviderServiceClient ( string endpointConfigurationName, EndpointAddress remoteAddress ) :
			base ( endpointConfigurationName, remoteAddress ) { }
		public KinectProviderServiceClient ( Binding binding, EndpointAddress remoteAddress ) :
			base ( binding, remoteAddress ) { }

		public Kinect GetData ( Kinect composite ) { return base.Channel.GetData ( composite ); }
		public Task<Kinect> GetDataAsync ( Kinect composite ) { return base.Channel.GetDataAsync ( composite ); }
	}
}
