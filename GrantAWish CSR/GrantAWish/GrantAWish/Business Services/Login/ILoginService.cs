using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GrantAWish.Database_Model;

namespace GrantAWish.Business_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        
        [OperationContract]
        User doLogin(string username, string password);
        
        [OperationContract]
        User forgotPassword(string username);

        [OperationContract]
        bool signUp(string username,string password);

    }
}
