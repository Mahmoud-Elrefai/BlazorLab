using System;
using BAL.Dtos;

namespace BAL.IServices
{
	public interface IProductServcie
	{
		List<ProductDto> GetAll();
	}
}

