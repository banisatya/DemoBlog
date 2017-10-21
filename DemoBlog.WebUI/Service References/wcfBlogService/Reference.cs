﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoBlog.WebUI.wcfBlogService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcfBlogService.IBlogService")]
    public interface IBlogService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/CreateBlog", ReplyAction="http://tempuri.org/IBlogService/CreateBlogResponse")]
        DemoBlog.DataAccess.ViewModel.dbActionResult CreateBlog(DemoBlog.DataAccess.EntityModel.Blog model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/CreateBlog", ReplyAction="http://tempuri.org/IBlogService/CreateBlogResponse")]
        System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.dbActionResult> CreateBlogAsync(DemoBlog.DataAccess.EntityModel.Blog model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/IsValidSubject", ReplyAction="http://tempuri.org/IBlogService/IsValidSubjectResponse")]
        bool IsValidSubject(string Subject);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/IsValidSubject", ReplyAction="http://tempuri.org/IBlogService/IsValidSubjectResponse")]
        System.Threading.Tasks.Task<bool> IsValidSubjectAsync(string Subject);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/GetAllBlogs", ReplyAction="http://tempuri.org/IBlogService/GetAllBlogsResponse")]
        DemoBlog.DataAccess.ViewModel.BlogList[] GetAllBlogs(System.Nullable<int> UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/GetAllBlogs", ReplyAction="http://tempuri.org/IBlogService/GetAllBlogsResponse")]
        System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.BlogList[]> GetAllBlogsAsync(System.Nullable<int> UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/GetBlog", ReplyAction="http://tempuri.org/IBlogService/GetBlogResponse")]
        DemoBlog.DataAccess.ViewModel.BlogViewModel GetBlog(int BlogID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/GetBlog", ReplyAction="http://tempuri.org/IBlogService/GetBlogResponse")]
        System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.BlogViewModel> GetBlogAsync(int BlogID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/DeleteBlog", ReplyAction="http://tempuri.org/IBlogService/DeleteBlogResponse")]
        DemoBlog.DataAccess.ViewModel.dbActionResult DeleteBlog(int BlogID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/DeleteBlog", ReplyAction="http://tempuri.org/IBlogService/DeleteBlogResponse")]
        System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.dbActionResult> DeleteBlogAsync(int BlogID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/CommentListAll", ReplyAction="http://tempuri.org/IBlogService/CommentListAllResponse")]
        DemoBlog.DataAccess.ViewModel.CommentList[] CommentListAll(int BlogID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/CommentListAll", ReplyAction="http://tempuri.org/IBlogService/CommentListAllResponse")]
        System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.CommentList[]> CommentListAllAsync(int BlogID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/CommentCreate", ReplyAction="http://tempuri.org/IBlogService/CommentCreateResponse")]
        DemoBlog.DataAccess.ViewModel.dbActionResult CommentCreate(DemoBlog.DataAccess.ViewModel.CommentViewModel model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBlogService/CommentCreate", ReplyAction="http://tempuri.org/IBlogService/CommentCreateResponse")]
        System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.dbActionResult> CommentCreateAsync(DemoBlog.DataAccess.ViewModel.CommentViewModel model);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBlogServiceChannel : DemoBlog.WebUI.wcfBlogService.IBlogService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BlogServiceClient : System.ServiceModel.ClientBase<DemoBlog.WebUI.wcfBlogService.IBlogService>, DemoBlog.WebUI.wcfBlogService.IBlogService {
        
        public BlogServiceClient() {
        }
        
        public BlogServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BlogServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BlogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DemoBlog.DataAccess.ViewModel.dbActionResult CreateBlog(DemoBlog.DataAccess.EntityModel.Blog model) {
            return base.Channel.CreateBlog(model);
        }
        
        public System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.dbActionResult> CreateBlogAsync(DemoBlog.DataAccess.EntityModel.Blog model) {
            return base.Channel.CreateBlogAsync(model);
        }
        
        public bool IsValidSubject(string Subject) {
            return base.Channel.IsValidSubject(Subject);
        }
        
        public System.Threading.Tasks.Task<bool> IsValidSubjectAsync(string Subject) {
            return base.Channel.IsValidSubjectAsync(Subject);
        }
        
        public DemoBlog.DataAccess.ViewModel.BlogList[] GetAllBlogs(System.Nullable<int> UserID) {
            return base.Channel.GetAllBlogs(UserID);
        }
        
        public System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.BlogList[]> GetAllBlogsAsync(System.Nullable<int> UserID) {
            return base.Channel.GetAllBlogsAsync(UserID);
        }
        
        public DemoBlog.DataAccess.ViewModel.BlogViewModel GetBlog(int BlogID) {
            return base.Channel.GetBlog(BlogID);
        }
        
        public System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.BlogViewModel> GetBlogAsync(int BlogID) {
            return base.Channel.GetBlogAsync(BlogID);
        }
        
        public DemoBlog.DataAccess.ViewModel.dbActionResult DeleteBlog(int BlogID) {
            return base.Channel.DeleteBlog(BlogID);
        }
        
        public System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.dbActionResult> DeleteBlogAsync(int BlogID) {
            return base.Channel.DeleteBlogAsync(BlogID);
        }
        
        public DemoBlog.DataAccess.ViewModel.CommentList[] CommentListAll(int BlogID) {
            return base.Channel.CommentListAll(BlogID);
        }
        
        public System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.CommentList[]> CommentListAllAsync(int BlogID) {
            return base.Channel.CommentListAllAsync(BlogID);
        }
        
        public DemoBlog.DataAccess.ViewModel.dbActionResult CommentCreate(DemoBlog.DataAccess.ViewModel.CommentViewModel model) {
            return base.Channel.CommentCreate(model);
        }
        
        public System.Threading.Tasks.Task<DemoBlog.DataAccess.ViewModel.dbActionResult> CommentCreateAsync(DemoBlog.DataAccess.ViewModel.CommentViewModel model) {
            return base.Channel.CommentCreateAsync(model);
        }
    }
}
