﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF.Demo.Client.RemoveService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RemoveService.IRemove")]
    public interface IRemove {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemove/DoWork", ReplyAction="http://tempuri.org/IRemove/DoWorkResponse")]
        bool DoWork(int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemove/DoWork", ReplyAction="http://tempuri.org/IRemove/DoWorkResponse")]
        System.Threading.Tasks.Task<bool> DoWorkAsync(int UserID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRemoveChannel : WCF.Demo.Client.RemoveService.IRemove, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RemoveClient : System.ServiceModel.ClientBase<WCF.Demo.Client.RemoveService.IRemove>, WCF.Demo.Client.RemoveService.IRemove {
        
        public RemoveClient() {
        }
        
        public RemoveClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RemoveClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoveClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoveClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool DoWork(int UserID) {
            return base.Channel.DoWork(UserID);
        }
        
        public System.Threading.Tasks.Task<bool> DoWorkAsync(int UserID) {
            return base.Channel.DoWorkAsync(UserID);
        }
    }
}