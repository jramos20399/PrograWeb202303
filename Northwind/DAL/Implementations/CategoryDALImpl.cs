using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDALImpl : DALGenericoImpl<Category>, ICategoryDAL
    {
        NorthWindContext _context;

        public CategoryDALImpl(NorthWindContext context): base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Category>> GetAll()
        {
                List<Category> categories = new List<Category>();
            List<sp_GetAllCategories_Result> results;
            string sql = "[dbo].[sp_GetAllCategories]";

            results = await _context.Sp_GetAllCategories_Results
                            .FromSqlRaw(sql)
                            .ToListAsync();
            foreach (var item in results)
            {

                categories.Add(
                    new Category
                    {
                        CategoryId = item.CategoryId,
                        CategoryName = item.CategoryName,   
                        Description = item.Description,
                        Picture = item.Picture
                    }

                    );

            }



            return categories;
        }


        public bool Add(Category category)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddCategory] @CategoryName, @Description";
                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@CategoryName",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value= category.CategoryName
                    },
                     new SqlParameter()
                    {
                        ParameterName = "@Description",
                        SqlDbType= System.Data.SqlDbType.VarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value= category.Description
                    }

                };
               

                int resultado = _context.Database.ExecuteSqlRaw(sql, param);


                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
