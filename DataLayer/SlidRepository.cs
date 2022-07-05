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
    public class SlidRepository
    {

        MyContext db = null;

        public SlidRepository()
        {
            db = new MyContext();
        }

        public bool Add(Slid entity, bool autoSave = true)
        {
            try
            {
                db.Slid.Add(entity);
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

        public bool Update(Slid entity, string imagePath, bool autoSave = true)
        {
            try
            {
                if (imagePath != null)
                {
                    entity.File = imagePath;
                }
                db.Slid.Attach(entity);
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

        public bool Delete(Slid entity, bool autoSave = true)
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
                var entity = db.Slid.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                {
                    bool result = Convert.ToBoolean(db.SaveChanges());
                    if (result)
                    {
                        try
                        {
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.File) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.File);
                            }
                        }
                        catch { }
                    }
                    return result;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public Slid Find(int id)
        {
            try
            {
                return db.Slid.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Slid> Where(System.Linq.Expressions.Expression<Func<Slid, bool>> predicate)
        {
            try
            {
                return db.Slid.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Slid> Select()
        {
            try
            {
                return db.Slid.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Slid, TResult>> selector)
        {
            try
            {
                return db.Slid.Select(selector);
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
                if (db.Slid.Any())
                    return db.Slid.OrderByDescending(p => p.Id).First().Id;
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

        ~SlidRepository()
        {
            Dispose(false);
        }
    }
}
