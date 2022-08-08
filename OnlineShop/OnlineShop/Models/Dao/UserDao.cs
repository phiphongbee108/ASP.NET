using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Common;
using OnlineShop.Models.EF;
using PagedList;

namespace OnlineShop.Models.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }

        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);

                user.UserName = entity.UserName; 
                
                user.Password = entity.Password;
                //if(string.IsNullOrEmpty(user.Password))
                //{
                //}

                user.Status = entity.Status;
                user.GroupID = entity.GroupID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }        
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;   //Username does not exist!
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1; //Account is locked or disable
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1; //login success
                            else
                                return -2; //Wrong password
                        }
                    }
                    else
                    {
                        return -3; //Account does not have permission to access
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1; //Account is locked or disable
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1; //login success
                        else
                            return -2; //Wrong password
                    }
                }
            }
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();

            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x=>x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
        public List<UserGroup> ListAll()
        {
            return db.UserGroups.ToList();
        }
    }
}