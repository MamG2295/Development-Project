using Interview.Web.Common;
using Interview.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // NOTE: Sample Action
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await _productRepository.GetAllProducts());
        }

        [HttpPost]
        [Route("product")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (await _productRepository.AddProduct(product))
            {
                return Created("", product);
            }
            return new StatusCodeResult(500);
        }
    }
}
