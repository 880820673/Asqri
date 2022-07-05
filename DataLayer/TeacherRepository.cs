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
    public class TeacherRepository
    {

        MyContext db = null;

        public TeacherRepository()
        {
            db = new MyContext();
        }

        public bool Add(Teacher entity, bool autoSave = true)
        {
            try
            {
                db.Teachers.Add(entity);
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

        public bool Update(Teacher entity, string imagePath, string imagePath2, string imagePath3,string imagePath4, bool autoSave = true)
        {
            try
            {
                if (imagePath != null)
                {
                    entity.Image = imagePath;
                }
                if (imagePath2 != null)
                {
                    entity.DegreeImage = imagePath2;
                }
                if (imagePath3 != null)
                {
                    entity.NationalImage = imagePath3;
                }
                if (imagePath3 != null)
                {
                    entity.RozomeImage = imagePath4;
                }
                db.Teachers.Attach(entity);
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
        public bool UpdateTeacher(Teacher entity, bool autoSave = true)
        {
            try
            {
                
                db.Teachers.Attach(entity);
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
        public bool Delete(Teacher entity, bool autoSave = true)
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
                var entity = db.Teachers.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                {
                    bool result = Convert.ToBoolean(db.SaveChanges());
                    if (result)
                    {
                        try
                        {
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.NationalImage) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.NationalImage);
                            }
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.DegreeImage) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.DegreeImage);
                            }
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.Image) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.Image);
                            }
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.RozomeImage) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.RozomeImage);
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

        public Teacher Find(int id)
        {
            try
            {
                return db.Teachers.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Teacher> Where(System.Linq.Expressions.Expression<Func<Teacher, bool>> predicate)
        {
            try
            {
                return db.Teachers.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Teacher> Select()
        {
            try
            {
                return db.Teachers.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Teacher, TResult>> selector)
        {
            try
            {
                return db.Teachers.Select(selector);
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
                if (db.Teachers.Any())
                    return db.Teachers.OrderByDescending(p => p.Id).First().Id;
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

        ~TeacherRepository()
        {
            Dispose(false);
        }
    }
}
