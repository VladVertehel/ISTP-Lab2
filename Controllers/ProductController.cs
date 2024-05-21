using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Interfaces;
using ReviewApp.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using AutoMapper;
using ReviewApp.Dto;

namespace ReviewApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper) 
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProduct()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(products);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProducts(int productId) 
        {
            if(!_productRepository.ProductExists(productId))
                return NotFound();

            var product = _mapper.Map<ProductDto>(_productRepository.GetProductId(productId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

    }
}
