using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GrantAWish.Business_Logic_Layer.Login;
using GrantAWish.Database_Model;

namespace GrantAWish.Business_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in both code and config file together.
    public class LoginService : ILoginService, IDisposable
    {
        Login loginObj = new Login();
        

        public User doLogin(string username, string password)
        {
           return loginObj.doLogin(username,password);
        }

        public User forgotPassword(string username)
        {
            return loginObj.forgotPassword(username);
        }

        public bool signUp(string username, string password)
        {
            return loginObj.signUp(username, password);
        }




        #region IDisposable Members

        public void Dispose()
        {
            
        }

        #endregion
    }
}
