using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GrantAWish.Database_Model;

namespace GrantAWish.Communication_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMailService" in both code and config file together.
    [ServiceContract]
    public interface IMailService
    {
        [OperationContract]
        bool ForgotPassword(User userObj);
    }
}
