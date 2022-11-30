using System;
using BAL.Dtos;
using BlazorLabWASM.Client.IServices;
using Newtonsoft.Json;

namespace BlazorLabWASM.Client.Services
{
	public class ProductServiceApi : IProductServiceApi
	{
        private readonly HttpClient httpClient;

        public ProductServiceApi(HttpClient httpClient)
		{
            this.httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var Response = await httpClient.GetAsync("/api/product");
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

