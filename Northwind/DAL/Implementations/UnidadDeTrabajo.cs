﻿using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public ICategoryDAL _categoryDAL { get;  }
        public ISupplierDAL _supplierDAL { get; }

       

        private readonly NorthWindContext _context;

        public UnidadDeTrabajo(NorthWindContext context,
                                ICategoryDAL categoryDAL,
                                ISupplierDAL supplierDAL)
        {
            _context = context;
            _categoryDAL = categoryDAL;
            _supplierDAL = supplierDAL;
        }


        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
