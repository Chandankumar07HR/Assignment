using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst_EF_CodeBaseTest1.Models;
using System.Data.Entity;

namespace CodeFirst_EF_CodeBaseTest1.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        MoviesDbContext db;
        DbSet<T> dbset;
        public Repository()
        {
            db = new MoviesDbContext();
            dbset = db.Set<T>();
        }

        //Implementation of Interface Methods
        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        

        public T GetById(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            T getModel = dbset.Find(Id);
            dbset.Remove(getModel);
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}