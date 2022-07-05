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
    public class MarketerRepository
    {

        MyContext db = null;

        public MarketerRepository()
        {
            db = new MyContext();
        }

        public bool Add(Marketer entity, bool autoSave = true)
        {
            try
            {
                db.Marketers.Add(entity);
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

        public bool Update(Marketer entity, string imagePath, bool autoSave = true)
        {
            try
            {
                if (imagePath != null)
                {
                    entity.Files = imagePath;
                }
                db.Marketers.Attach(entity);
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

        public bool Delete(Marketer entity, bool autoSave = true)
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
                var entity = db.Marketers.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                {
                    bool result = Convert.ToBoolean(db.SaveChanges());
                    if (result)
                    {
                        try
                        {
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.Files) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.Files);
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

        public Marketer Find(int id)
        {
            try
            {
                return db.Marketers.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Marketer> Where(System.Linq.Expressions.Expression<Func<Marketer, bool>> predicate)
        {
            try
            {
                return db.Marketers.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Marketer> Select()
        {
            try
            {
                return db.Marketers.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Marketer, TResult>> selector)
        {
            try
            {
                return db.Marketers.Select(selector);
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
                if (db.Marketers.Any())
                    return db.Marketers.OrderByDescending(p => p.Id).First().Id;
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

        ~MarketerRepository()
        {
            Dispose(false);
        }
    }
}
