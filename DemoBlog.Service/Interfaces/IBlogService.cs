using DemoBlog.DataAccess.EntityModel;
using DemoBlog.DataAccess.ViewModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace DemoBlog.Service
{
    [ServiceContract]
    public interface IBlogService
    {
        #region Blog
                
        [OperationContract]
        dbActionResult CreateBlog(Blog model);

        [OperationContract]
        bool IsValidSubject(string Subject);

        [OperationContract]
        List<BlogList> GetAllBlogs(int? UserID);

        [OperationContract]
        BlogViewModel GetBlog(int BlogID);

        [OperationContract]
        dbActionResult DeleteBlog(int BlogID);

        #endregion

        #region Comment
                
        [OperationContract]
        List<CommentList> CommentListAll(int BlogID);

        [OperationContract]
        dbActionResult CommentCreate(CommentViewModel model);

        #endregion
    }
}