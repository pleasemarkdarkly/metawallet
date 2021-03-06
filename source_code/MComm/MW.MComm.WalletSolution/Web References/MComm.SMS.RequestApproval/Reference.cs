﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.42.
// 
#pragma warning disable 1591
namespace MW.MComm.WalletSolution.MComm.SMS.RequestApproval {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="requestAprovalSoap", Namespace="http://tempuri.org/")]
    public partial class requestAproval : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback processSMSOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAprovalAndPinOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public requestAproval() {
            this.Url = global::MW.MComm.WalletSolution.Properties.Settings.Default.MW_MComm_WalletSolution_MComm_SMS_RequestApproval_requestAproval;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event processSMSCompletedEventHandler processSMSCompleted;
        
        /// <remarks/>
        public event getAprovalAndPinCompletedEventHandler getAprovalAndPinCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/processSMS", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string processSMS(long internalId, string sender, string receiver, string text, string connectionId) {
            object[] results = this.Invoke("processSMS", new object[] {
                        internalId,
                        sender,
                        receiver,
                        text,
                        connectionId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void processSMSAsync(long internalId, string sender, string receiver, string text, string connectionId) {
            this.processSMSAsync(internalId, sender, receiver, text, connectionId, null);
        }
        
        /// <remarks/>
        public void processSMSAsync(long internalId, string sender, string receiver, string text, string connectionId, object userState) {
            if ((this.processSMSOperationCompleted == null)) {
                this.processSMSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnprocessSMSOperationCompleted);
            }
            this.InvokeAsync("processSMS", new object[] {
                        internalId,
                        sender,
                        receiver,
                        text,
                        connectionId}, this.processSMSOperationCompleted, userState);
        }
        
        private void OnprocessSMSOperationCompleted(object arg) {
            if ((this.processSMSCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.processSMSCompleted(this, new processSMSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getAprovalAndPin", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getAprovalAndPin(string transactionID, string customerPhone) {
            object[] results = this.Invoke("getAprovalAndPin", new object[] {
                        transactionID,
                        customerPhone});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getAprovalAndPinAsync(string transactionID, string customerPhone) {
            this.getAprovalAndPinAsync(transactionID, customerPhone, null);
        }
        
        /// <remarks/>
        public void getAprovalAndPinAsync(string transactionID, string customerPhone, object userState) {
            if ((this.getAprovalAndPinOperationCompleted == null)) {
                this.getAprovalAndPinOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAprovalAndPinOperationCompleted);
            }
            this.InvokeAsync("getAprovalAndPin", new object[] {
                        transactionID,
                        customerPhone}, this.getAprovalAndPinOperationCompleted, userState);
        }
        
        private void OngetAprovalAndPinOperationCompleted(object arg) {
            if ((this.getAprovalAndPinCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAprovalAndPinCompleted(this, new getAprovalAndPinCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void processSMSCompletedEventHandler(object sender, processSMSCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class processSMSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal processSMSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getAprovalAndPinCompletedEventHandler(object sender, getAprovalAndPinCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAprovalAndPinCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAprovalAndPinCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}
#pragma warning restore 1591