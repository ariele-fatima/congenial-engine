using System.Collections.Generic;
using System.Linq;
using GJJA.Repository.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GJJA.Repository.Common.Entity
{
    public abstract class EntityRepositoryBase<TDomain, TKey> : ICrudRepository<TDomain, TKey>
        where TDomain : class
    {
        private DbContext _context;
        public EntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public virtual List<TDomain> Select() => _context.Set<TDomain>().ToList();

        public virtual TDomain SelectById(TKey id) => _context.Set<TDomain>().Find(id);

        public virtual void Insert(TDomain domain)
        {
            _context.Set<TDomain>().Add(domain);
            _context.SaveChanges();
        }

        public virtual void Update(TDomain domain)
        {
            _context.Entry(domain).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delele(TDomain domain)
        {
            _context.Entry(domain).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual void DeletetById(TKey id)
        {
            TDomain domain = SelectById(id);
            Delele(domain);
        }
    }
}