using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BAL.Dtos;
using Duende.Bff;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorLabWASM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductController(IHttpClientFactory httpClientFactory , IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        [BffApi]
        public async Task<List<ProductDto>> GetAll()
        {
            var Client = _httpClientFactory.CreateClient();
            var Token = await HttpContext.GetUserAccessTokenAsync();
            Client.SetBearerToken(Token);

            // call remote API
            var Url = _configuration["BaseApiUrl"].ToString() + _configuration["ApisUrls:GetAllProducts"].ToString(); 
            var Response = await Client.GetAsync(Url);
            if (Response.IsSuccessStatusCode)
            {
                var Content = await Response.Content.ReadAsStringAsync();
                var Products = JsonConvert.DeserializeObject<List<ProductDto>>(Content);
                return Products;

            }
            return new List<ProductDto>();
        }
    }
}

