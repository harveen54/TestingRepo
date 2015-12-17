using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrantAWish.Data_Access_Layer.User_Related;
using GrantAWish.Database_Model;

namespace GrantAWish.Business_Logic_Layer.Login
{
    public class Login
    {
        GrantAWishEntities context = new GrantAWishEntities();
        UserDAL userDALObj;

        public User doLogin(string username, string password)
        {
            
            User userObj = null;
            if (String.IsNullOrEmpty(username) == false && String.IsNullOrEmpty(password)==false)
            {
                userObj = context.User.FirstOrDefault(e => e.username == username && e.password == password);
            
            }
            return userObj;
        }

        public User forgotPassword(string username)
        {
            User userObj = null;
            if (!String.IsNullOrEmpty(username))
            {
                userObj =  checkIfUserExistsByUsername(username);
            }
            return userObj;
        }

        public bool signUp(string username, string password)
        {
            User userObj = null;
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                userObj = checkIfUserExistsByUsername(username);
                if (userObj == null)
                {
                    userDALObj = new UserDAL();
                    if (userDALObj.addNewUser(username, password)==1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
           
            //password encryption
            //return int to know the error.

        }

        

        public User checkIfUserExistsByUsername(string username)
        {
            return context.User.FirstOrDefault(e => e.username == username);
        }
       
    }
}
