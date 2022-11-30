using System;
using DAL.Models;

namespace DAL.IRepos
{
	public interface IProductRepo
	{
		List<Product> GetAll();
	}
}

