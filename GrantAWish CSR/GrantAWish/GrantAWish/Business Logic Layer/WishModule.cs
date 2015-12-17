using GrantAWish.Database_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrantAWish.Business_Logic_Layer
{
    class WishModule
    {
        GrantAWishEntities context = new GrantAWishEntities();
        public List<Wishes> GetAllWishes()
        {
            return context.Wishes.AsEnumerable().ToList();
        }

        public void ChangeWishStatus(int wishId, int userId, int status)
        {
            Wishes wish=context.Wishes.FirstOrDefault(e => e.wishId == wishId);
            if(wish!=null)
            {
                
                wish.wishStatus = status;
                wish.grantedBy = userId;
                context.SaveChanges();
            }
        }

        public void AddNewWish(string wisherName,int age, string gender,string wish,int? addedBy)
        {
            Wishes wishobj = new Wishes
            {
                wisherName = wisherName,
                wisherAge = age,
                wisherGender = gender,
                wish = wish,
                addedBy = addedBy,
                wishDate = DateTime.Now,
                wishStatus = 1,
                grantedBy = null
            };
            context.Wishes.Add(wishobj);
            context.SaveChanges();
        }//edit //delete

        public void EditWish(Wishes wishObj)
        {
            Wishes wishLocal = context.Wishes.FirstOrDefault(e => e.wishId == wishObj.wishId);
            if(wishLocal!=null)
            {
                wishLocal.addedBy = wishObj.addedBy;
                wishLocal.grantedBy = wishObj.grantedBy;
                wishLocal.wish = wishObj.wish;
                wishLocal.wishDate = wishObj.wishDate;
                wishLocal.wisherAge = wishObj.wisherAge;
                wishLocal.wisherGender = wishObj.wisherGender;
                wishLocal.wisherName = wishObj.wisherName;
                wishLocal.wishId = wishObj.wishId;
                wishLocal.wishStatus = wishObj.wishStatus;
                context.Entry(wishLocal).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteWish(int id)
        {
            Wishes wishLocal = context.Wishes.FirstOrDefault(e => e.wishId == id);
            if (wishLocal != null)
            {
                context.Wishes.Remove(wishLocal);
                context.SaveChanges();
            }
        }

    }
}
