using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDALGenerico<TEntity> where TEntity : class
    {

       
        TEntity Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
       

        bool Add(TEntity entity);
       

        bool Update(TEntity entity);
        bool Remove(TEntity entity);
       



    }
}
