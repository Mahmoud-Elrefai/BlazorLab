using System;
using DAL.IRepos;
using DAL.Models;

namespace DAL.Repos
{
	public class ProductRepo : IProductRepo
	{
        private readonly ApplicationDbContext dbContext;

        public ProductRepo(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        public List<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }
    }
}

