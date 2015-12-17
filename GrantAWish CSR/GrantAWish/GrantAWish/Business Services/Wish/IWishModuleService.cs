using GrantAWish.Database_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GrantAWish.Business_Services.Wish
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWishModule" in both code and config file together.
    [ServiceContract]
    public interface IWishModuleService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<Wishes> GetWishes();

        [OperationContract]
        void ChangeStatusOfWish(int wishId, int userId,int wishStatus);

        [OperationContract]
        void EditWish(Wishes wishObj);

        [OperationContract]
        void DeleteWish(int id);
    }
}
