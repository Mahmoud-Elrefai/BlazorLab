using System;
using BAL.Dtos;

namespace BlazorLabWASM.Client.IServices
{
	public interface IProductServiceApi
	{
		Task<List<ProductDto>> GetAll();
	}
}

