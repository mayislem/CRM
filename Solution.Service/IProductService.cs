﻿using Solution.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> GetProductById(int IdProduct);

        IEnumerable<Product> GetProducts();
    }
}
