using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService:IProductService
    {
        IProductDal _product;

        public ProductService(IProductDal product)
        {
            _product = product;
        }

        public void Add(Product product)
        {
            _product.Add(product);
        }

        public void Delete(Product product)
        {
            _product.Delete(product);
        }

        public List<Product> GetAll(Product product)
        {
            return _product.GetAll();
        }

        public List<Product> GetByCategory(int id)
        {
            return _product.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByProductId(int id)
        {
            return _product.GetAll(p => p.ProductId == id);
        }

        public void Update(Product product)
        {
            _product.Update(product);
        }
    }
}
