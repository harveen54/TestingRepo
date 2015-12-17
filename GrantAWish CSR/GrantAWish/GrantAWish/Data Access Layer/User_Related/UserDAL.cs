using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrantAWish.Database_Model;

namespace GrantAWish.Data_Access_Layer.User_Related
{    
    public class UserDAL
    {
     
        public int addNewUser(string usernameNewUser, string passwordNewUser)
        {
            User userObj = null;
            if (!String.IsNullOrEmpty(usernameNewUser) && !String.IsNullOrEmpty(passwordNewUser))
            {
                userObj = new User()
                {
                    username = usernameNewUser,
                    password = passwordNewUser,
                    signup_Date = DateTime.Now
                };

                using (var context = new GrantAWishEntities())
                {
                    context.User.Add(userObj);
                    context.SaveChanges();
                    return 1;
                }
            }
            else
                return 0;
        }
    }
}
