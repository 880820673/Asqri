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
    public class GroupRepository
    {

        MyContext db = null;

        public GroupRepository()
        {
            db = new MyContext();
        }
        public bool Add(Group entity, bool autoSave = true)
        {
            try
            {
                db.Group.Add(entity);
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

  
        public bool Update(Group entity, bool autoSave = true)
        {
            try
            {
                db.Group.Attach(entity);
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

        public bool Delete(Group entity, bool autoSave = true)
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
                var entity = db.Group.Find(id);
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

        public Group Find(int id)
        {
            try
            {
                return db.Group.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Group> Where(System.Linq.Expressions.Expression<Func<Group, bool>> predicate)
        {
            try
            {
                return db.Group.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Group> Select()
        {
            try
            {
                return db.Group.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Group, TResult>> selector)
        {
            try
            {
                return db.Group.Select(selector);
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
                if (db.Group.Any())
                    return db.Group.OrderByDescending(p => p.Id).First().Id;
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

        ~GroupRepository()
        {
            Dispose(false);
        }
    }
}

