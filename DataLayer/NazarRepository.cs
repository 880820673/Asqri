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
    public class NazarRepository
    {

        MyContext db = null;

        public NazarRepository()
        {
            db = new MyContext();
        }
        public bool Add(Nazar entity, bool autoSave = true)
        {
            try
            {
                db.Nazar.Add(entity);
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

  
        public bool Update(Nazar entity, bool autoSave = true)
        {
            try
            {
                db.Nazar.Attach(entity);
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

        public bool Delete(Nazar entity, bool autoSave = true)
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
                var entity = db.Nazar.Find(id);
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

        public Nazar Find(int id)
        {
            try
            {
                return db.Nazar.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Nazar> Where(System.Linq.Expressions.Expression<Func<Nazar, bool>> predicate)
        {
            try
            {
                return db.Nazar.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Nazar> Select()
        {
            try
            {
                return db.Nazar.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Nazar, TResult>> selector)
        {
            try
            {
                return db.Nazar.Select(selector);
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
                if (db.Nazar.Any())
                    return db.Nazar.OrderByDescending(p => p.Id).First().Id;
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

        ~NazarRepository()
        {
            Dispose(false);
        }
    }
}

