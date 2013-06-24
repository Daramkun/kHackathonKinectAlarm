﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.18046
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinectData
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Kinect", Namespace="http://schemas.datacontract.org/2004/07/KinectData")]
    public partial class Kinect : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private byte[] ImageFrameField;
        
        private bool IsKinectConnectedField;
        
        private KinectData.Kinect.Joint[] SkeletonField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] ImageFrame
        {
            get
            {
                return this.ImageFrameField;
            }
            set
            {
                this.ImageFrameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsKinectConnected
        {
            get
            {
                return this.IsKinectConnectedField;
            }
            set
            {
                this.IsKinectConnectedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public KinectData.Kinect.Joint[] Skeleton
        {
            get
            {
                return this.SkeletonField;
            }
            set
            {
                this.SkeletonField = value;
            }
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Kinect.Joint", Namespace="http://schemas.datacontract.org/2004/07/KinectData")]
        public partial struct Joint : System.Runtime.Serialization.IExtensibleDataObject
        {
            
            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
            
            private KinectData.Kinect.JointType JointTypeField;
            
            private float XField;
            
            private float YField;
            
            private float ZField;
            
            public System.Runtime.Serialization.ExtensionDataObject ExtensionData
            {
                get
                {
                    return this.extensionDataField;
                }
                set
                {
                    this.extensionDataField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public KinectData.Kinect.JointType JointType
            {
                get
                {
                    return this.JointTypeField;
                }
                set
                {
                    this.JointTypeField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public float X
            {
                get
                {
                    return this.XField;
                }
                set
                {
                    this.XField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public float Y
            {
                get
                {
                    return this.YField;
                }
                set
                {
                    this.YField = value;
                }
            }
            
            [System.Runtime.Serialization.DataMemberAttribute()]
            public float Z
            {
                get
                {
                    return this.ZField;
                }
                set
                {
                    this.ZField = value;
                }
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Kinect.JointType", Namespace="http://schemas.datacontract.org/2004/07/KinectData")]
        public enum JointType : int
        {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            HipCenter = 0,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            Spine = 1,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            ShoulderCenter = 2,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            Head = 3,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            ShoulderLeft = 4,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            ElbowLeft = 5,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            WristLeft = 6,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            HandLeft = 7,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            ShoulderRight = 8,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            ElbowRight = 9,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            WristRight = 10,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            HandRight = 11,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            HipLeft = 12,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            KneeLeft = 13,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            AnkleLeft = 14,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            FootLeft = 15,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            HipRight = 16,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            KneeRight = 17,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            AnkleRight = 18,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            FootRight = 19,
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IKinectProviderService")]
public interface IKinectProviderService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKinectProviderService/GetData", ReplyAction="http://tempuri.org/IKinectProviderService/GetDataResponse")]
    KinectData.Kinect GetData(KinectData.Kinect composite);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKinectProviderService/GetData", ReplyAction="http://tempuri.org/IKinectProviderService/GetDataResponse")]
    System.Threading.Tasks.Task<KinectData.Kinect> GetDataAsync(KinectData.Kinect composite);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IKinectProviderServiceChannel : IKinectProviderService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class KinectProviderServiceClient : System.ServiceModel.ClientBase<IKinectProviderService>, IKinectProviderService
{
    
    public KinectProviderServiceClient()
    {
    }
    
    public KinectProviderServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public KinectProviderServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public KinectProviderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public KinectProviderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public KinectData.Kinect GetData(KinectData.Kinect composite)
    {
        return base.Channel.GetData(composite);
    }
    
    public System.Threading.Tasks.Task<KinectData.Kinect> GetDataAsync(KinectData.Kinect composite)
    {
        return base.Channel.GetDataAsync(composite);
    }
}
