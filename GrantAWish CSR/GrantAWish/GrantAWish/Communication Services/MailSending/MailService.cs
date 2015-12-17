using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GrantAWish.Communication_Layer;
using GrantAWish.Database_Model;

namespace GrantAWish.Communication_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MailService" in both code and config file together.
    public class MailService : IMailService,IDisposable
    {
        Mail mailObj=new Mail();

        public bool ForgotPassword(User userObj)
        {
            return mailObj.sendMailForgotPassword(userObj);
        }

        #region IDisposable Members

        void IDisposable.Dispose()
        {
        }

        #endregion
    }
}
