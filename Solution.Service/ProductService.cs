﻿using Service.Pattern;
using Solution.Data;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
   public  class ProductService : Service<Product>, IProductService
    {

        MyContext db = new MyContext();
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public ProductService() : base(UTK)
        {

        }

         IEnumerable<Product> IProductService.GetProducts()
        {
            return db.Products.ToList();

        }

        IEnumerable<Product> IProductService.GetProductByOffer(int IdProduct)
        {
            return GetMany(o => o.ProductId == IdProduct);
        }
    }
}
