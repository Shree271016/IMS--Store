using IMS.infrastructure.IRepository;
using IMS.Infrastructure;
using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.infrastructure.Repository.CRUD
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        private readonly IMSDbContext _context;
        private IMSDbContext context;
        private object p;

        public CrudService(IMSDbContext context)
        {
                _context =context;
        }
        public int Insert(T entity)
        {

            var result = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return result.Entity.Id;
        } 



        public async Task<int> InsertAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
            return result.Entity.Id;


        }
        public int Update(T entity) 
        
        {

            var result = _context.Set<T>().Update(entity).Property(p =>p.Id);
        _context.SaveChanges();
            return entity.Id;

        }
        public  async Task<int>UpdateAsync(T entity)
        {
            var result = _context.Set<T>().Update(entity).Property(p => p.Id);
           await _context.SaveChangesAsync();
            return entity.Id;

        }





        
        
    }
}
