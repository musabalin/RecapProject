using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        [Authorize()]
        public IActionResult GetList()
        {
            var result = _productService.GetAll();
            if (result.ResultStatus == 0)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int Id)
        {
            var result = _productService.GetByCategory(Id);
            if (result.ResultStatus == 0)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);

        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
            {

                return Ok("Eklendi...");
            }
            else
            {
                return BadRequest(result.Message);
            }


        }

        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.ResultStatus == 0)
            {
                return Ok(result.ResultStatus);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
