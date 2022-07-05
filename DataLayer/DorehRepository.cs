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
    public class DorehRepository
    {

        MyContext db = null;

        public DorehRepository()
        {
            db = new MyContext();
        }

        public bool Add(Doreh entity, bool autoSave = true)
        {
            try
            {
                db.Doreh.Add(entity);
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

        public bool Update(Doreh entity, string imagePath, bool autoSave = true)
        {
            try
            {
                if (imagePath != null)
                {
                    entity.ImageDoreh = imagePath;
                }
                db.Doreh.Attach(entity);
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

        public bool Delete(Doreh entity, bool autoSave = true)
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
                var entity = db.Doreh.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                {
                    bool result = Convert.ToBoolean(db.SaveChanges());
                    if (result)
                    {
                        try
                        {
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.ImageDoreh) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.ImageDoreh);
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

        public Doreh Find(int id)
        {
            try
            {
                return db.Doreh.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Doreh> Where(System.Linq.Expressions.Expression<Func<Doreh, bool>> predicate)
        {
            try
            {
                return db.Doreh.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Doreh> Select()
        {
            try
            {
                return db.Doreh.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Doreh, TResult>> selector)
        {
            try
            {
                return db.Doreh.Select(selector);
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
                if (db.Doreh.Any())
                    return db.Doreh.OrderByDescending(p => p.ID).First().ID;
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

        ~DorehRepository()
        {
            Dispose(false);
        }
    }
}
