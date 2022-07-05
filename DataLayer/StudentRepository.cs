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
    public class StudentRepository
    {

    MyContext db = null;

        public StudentRepository()
        {
            db = new MyContext();
        }

        public bool Add(Student entity, bool autoSave = true)
        {
            try
            {
                db.Student.Add(entity);
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

        public bool Update(Student entity, string imagePath, string imagePath2, string imagePath3, bool autoSave = true)
        {
            try
            {
                if (imagePath != null)
                {
                    entity.StudentImage = imagePath;
                }
                if (imagePath2 != null)
                {
                    entity.ShenasnameImage = imagePath2;
                }
                if (imagePath3 != null)
                {
                    entity.NationalImage = imagePath3;
                }
                db.Student.Attach(entity);
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

        public bool Delete(Student entity, bool autoSave = true)
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
                var entity = db.Student.Find(id);
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
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.ShenasnameImage) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.ShenasnameImage);
                            }
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.StudentImage) == true)
                            {
                                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Files\\UploadImages\\" + entity.StudentImage);
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

        public Student Find(int id)
        {
            try
            {
                return db.Student.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Student> Where(System.Linq.Expressions.Expression<Func<Student, bool>> predicate)
        {
            try
            {
                return db.Student.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<Student> Select()
        {
            try
            {
                return db.Student.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<Student, TResult>> selector)
        {
            try
            {
                return db.Student.Select(selector);
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
                if (db.Student.Any())
                    return db.Student.OrderByDescending(p => p.Id).First().Id;
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

        ~StudentRepository()
        {
            Dispose(false);
        }
    }
}
