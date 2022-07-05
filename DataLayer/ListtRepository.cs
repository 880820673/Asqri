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
    public class ListtRepository
    {

        MyContext db = null;

        public ListtRepository()
        {
            db = new MyContext();
        }
        public bool Add(Listt entity, bool autoSave = true)
        {
            try
            {
                db.Listts.Add(entity);
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

  
        public bool Update(Listt entity, bool autoSave = true)
        {
            try
            {
                db.Listts.Attach(entity);
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

        public bool Delete(Listt entity, bool autoSave = true)
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
                var entity = db.Listts.Find(id);
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

        public Listt Find(int id)
        {
            try
            {
                return db.Listts.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Listt> Where(System.Linq.Expressions.Expression<Func<Listt, bool>> predicate)
        {
            try
            {
                return db.Listts.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Listt> Select()
        {
            try
            {
                return db.Listts.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Listt, TResult>> selector)
        {
            try
            {
                return db.Listts.Select(selector);
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
                if (db.Listts.Any())
                    return db.Listts.OrderByDescending(p => p.Id).First().Id;
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

        ~ListtRepository()
        {
            Dispose(false);
        }
    }
}

