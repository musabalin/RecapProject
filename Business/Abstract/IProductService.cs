using Core.Utilities.Results;
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
        IDataResult<List<Product>> GetByCategory(int id);
        IDataResult<List<Product>> GetByProductId(int id);
        IDataResult<List<Product>> GetAll();
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);



    }
}
