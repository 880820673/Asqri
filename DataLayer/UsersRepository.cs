using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DominClass;
using DominClass.Context;
using System.Data.Entity;

namespace DataLayer
{
    public class UsersRepository
    {

        MyContext db = null;

        public UsersRepository()
        {
            db = new MyContext();
        }
        public bool Add(Users entity, bool autoSave = true)
        {
            try
            {
                db.Users.Add(entity);
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Exist(string username, string password)
        {
            try
            {
                return db.Users.Where(p => p.Username == username && p.Password == password).Any();
            }
            catch
            {
                return false;
            }
        }
        public bool Exist2(string username)
        {
            try
            {
                return db.Users.Where(p => p.Username == username ).Any();
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Users entity, bool autoSave = true)
        {
            try
            {
                db.Users.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Users entity, bool autoSave = true)
        {
            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id, bool autoSave = true)
        {
            try
            {
                var entity = db.Users.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public Users Find(int id)
        {
            try
            {
                return db.Users.Find(id);
            }
            catch
            {
                return null;
            }
        }
        public Users FindUser(string  Username)
        {
            try
            {
                return db.Users.Find(Username);
            }
            catch
            {
                return null;
            }
        }
        public IQueryable<Users> Where(System.Linq.Expressions.Expression<Func<Users, bool>> predicate)
        {
            try
            {
                return db.Users.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Users> Select()
        {
            try
            {
                return db.Users.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Users, TResult>> selector)
        {
            try
            {
                return db.Users.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        public int GetLastIdentity()
        {
            try
            {
                if (db.Users.Any())
                    return db.Users.OrderByDescending(p => p.Id).First().Id;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        ~UsersRepository()
        {
            Dispose(false);
        }
    }
}

