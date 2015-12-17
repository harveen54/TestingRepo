using GrantAWish.Database_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using GrantAWish.Business_Logic_Layer;

namespace GrantAWish.Business_Services.Wish
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WishModule" in both code and config file together.
    public class WishModuleService : IWishModuleService, IDisposable
    {
        WishModule wishLogicObj = new WishModule();
        public void DoWork()
        {
        }
        public List<Wishes> GetWishes()
        {
            return wishLogicObj.GetAllWishes();
        }

        public void ChangeStatusOfWish(int wishId, int userId, int wishStatus)
        {
            wishLogicObj.ChangeWishStatus(wishId, userId, wishStatus);
        }

      public  void EditWish(Wishes wishObj)
        {
            wishLogicObj.EditWish(wishObj);
        }

       public void DeleteWish(int id)
        {
            wishLogicObj.DeleteWish(id);
        }

        void IDisposable.Dispose()
        {

        }
    }
}
