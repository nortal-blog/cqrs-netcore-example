using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore_docker.Domain;
using netcore_docker.Repositories;

namespace netcore_docker.Controllers
{
	[Route("api/products")]
	public class ProductsReadController
	{
		private readonly IReadRepository<Product> repository;

		public ProductsReadController(IReadRepository<Product> repository) {
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IEnumerable<Product>> GetAll() {
			return await repository.GetAsync();
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<Product> SearchById(Guid id) {
			return await repository.GetById(id);
		}
	}
}