using DemoBlog.DataAccess.ViewModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace DemoBlog.Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        dbActionResult CreateUser(RegisterViewModel UserModel);

        [OperationContract]
        UserValidationViewModel IsValidUser(LoginViewModel UserModel);

        [OperationContract]
        List<UserList> UserListSelectAll();

        [OperationContract]
        dbActionResult DeleteUser(int UserID);

        [OperationContract]
        dbActionResult CreateAdminUser(int UserID);

        [OperationContract]
        bool IsUserNameExists(string UserName);
    }
}