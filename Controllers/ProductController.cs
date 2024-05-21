using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Interfaces;
using ReviewApp.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ReviewApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProduct()
        {
            var products = _productRepository.GetProducts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(products);
        }
    }
}
