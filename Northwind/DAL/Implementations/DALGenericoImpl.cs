using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        protected readonly NorthWindContext _Context;


        public DALGenericoImpl(NorthWindContext context)
        {
            _Context = context;
        }



        public bool Add(TEntity entity)
        {

            try
            {
                _Context.Add(entity);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            try
            {


                return _Context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await _Context.Set<TEntity>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TEntity entity)
        {

            try
            {
                _Context.Set<TEntity>().Attach(entity);
                _Context.Set<TEntity>().Remove(entity);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {

            try
            {
                _Context.Entry(entity).State = EntityState.Modified;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
