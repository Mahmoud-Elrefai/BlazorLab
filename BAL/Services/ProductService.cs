using System;
using BAL.Dtos;
using BAL.IServices;
using DAL.IRepos;

namespace BAL.Services
{
	public class ProductService : IProductServcie
	{
        private readonly IProductRepo productRepo;

        public ProductService(IProductRepo productRepo)
		{
            this.productRepo = productRepo;
        }

        public List<ProductDto> GetAll()
        {
            return productRepo.GetAll().Select(p => new ProductDto { Name = p.Name , Price = p.Price}).ToList();
        }
    }
}

