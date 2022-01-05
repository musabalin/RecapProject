using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetByCategory(int id);
        List<Product> GetByProductId(int id);
        List<Product> GetAll(Product product);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);



    }
}
