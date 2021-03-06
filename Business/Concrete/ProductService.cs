using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.CacheAspect;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _product;

        public ProductService(IProductDal product)
        {
            _product = product;
        }
        [ValidationAspect(typeof(ProductValidator),Priority =1)]
        [CacheRemoveAspect("IProductService.Get")]//Silinmesi gereken operasyonları
        public IResult Add(Product product)
        {
            _product.Add(product);
            return new Result(ResultStatus.Success);
        }

        public IResult Delete(Product product)
        {
            _product.Delete(product);
            return new Result(ResultStatus.Success);
        }

        public IDataResult<List<Product>> GetAll()
        {

            return new DataResult<List<Product>>(ResultStatus.Success, _product.GetAll());
        }
        [CacheAspect(duration:10)]
        public IDataResult<List<Product>> GetByCategory(int id)
        {

            return new DataResult<List<Product>>(ResultStatus.Success, _product.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByProductId(int id)
        {
            return new DataResult<List<Product>>(ResultStatus.Success, _product.GetAll(p => p.ProductId == id));
        }

        public IResult Update(Product product)
        {
            _product.Update(product);
            return new Result(ResultStatus.Success);
        }
    }
}
