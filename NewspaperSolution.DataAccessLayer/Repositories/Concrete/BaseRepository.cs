using NewspaperSolution.DataAccessLayer.Context;
using NewspaperSolution.DataAccessLayer.Repositories.Interfaces;
using NewspaperSolution.EntityLayer.Entites.Concrete;
using NewspaperSolution.EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.DataAccessLayer.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T:BaseEntity
    {
        private readonly ProjectContext _context; // _context nesnemizi sadece okunabilir yapıldı.
        public BaseRepository()
        {
            _context = new ProjectContext();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = Status.Passive;
            item.PassiveDate = DateTime.Now;
            Save();
        }

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status != Status.Passive).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
           
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }        

        public int Save()
        {
           return _context.SaveChanges();
        }

        public void Update(T item)
        {
            T updatedItem = GetById(item.Id);//Kullanıcıdan gelecek item nesnesinin "Id" propory'si üzerinde tutulan değer üzerinden update edilmek istenilen nesneyi bulduk ve "T" type olan "updatedItem" isimli nesneye doldurduk.
            DbEntityEntry dbEntityEntry = _context.Entry(updatedItem); //"DbContext.cs" sınıfının gömülü bir methodu olan "Entry" vasıtasıyla "updatedItem" nesnesi üzerindeki değerleri aldık "DbEntityEntry.cs" tipinde ki "dbEntityEntry" isimli değişkene doldurdur.
            dbEntityEntry.CurrentValues.SetValues(item); //Son olarak veritabanında bulup getirdiğimiz ve değerlerini "dbEntityEntry" üzerine doldurduğumuz nesnenin var olan değerlerine, kullanıcı tarafından gelen "item" nesnesin üzerinde olan değerleri set ettik yani atadık.
            
            Save();
        }

        public List<T> GetPassive()
        {
            return _context.Set<T>().Where(x => x.Status == Status.Passive).ToList();
        }

    }

}
