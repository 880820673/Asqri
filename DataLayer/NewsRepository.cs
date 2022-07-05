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
    public class NewsRepository
    {

        MyContext db = null;

        public NewsRepository()
        {
            db = new MyContext();
        }

        public bool Add(News entity, bool autoSave = true)
        {
            try
            {
                db.News.Add(entity);
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

        public bool Update(News entity, string imagePath, bool autoSave = true)
        {
            try
            {
                if (imagePath != null)
                {
                    entity.Image = imagePath;
                }
                db.News.Attach(entity);
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

        public bool Delete(News entity, bool autoSave = true)
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
                var entity = db.News.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                {
                    bool result = Convert.ToBoolean(db.SaveChanges());
                    if (result)
                    {
                        try
                        {
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.Image) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.Image);
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

        public News Find(int id)
        {
            try
            {
                return db.News.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<News> Where(System.Linq.Expressions.Expression<Func<News, bool>> predicate)
        {
            try
            {
                return db.News.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<News> Select()
        {
            try
            {
                return db.News.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<News, TResult>> selector)
        {
            try
            {
                return db.News.Select(selector);
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
                if (db.News.Any())
                    return db.News.OrderByDescending(p => p.Id).First().Id;
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

        ~NewsRepository()
        {
            Dispose(false);
        }
    }
}
