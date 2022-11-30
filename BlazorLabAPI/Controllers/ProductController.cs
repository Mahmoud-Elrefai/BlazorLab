using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Dtos;
using BAL.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorLabAPI.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductServcie productService;

        public ProductController(IProductServcie productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public List<ProductDto> Get()
        {
            return productService.GetAll();
        }

       
    }
}

