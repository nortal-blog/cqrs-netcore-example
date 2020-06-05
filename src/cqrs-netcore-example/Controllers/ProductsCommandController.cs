using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using netcore_docker.Domain.Commands;

namespace netcore_docker.Controllers
{
	[Route("api/products")]
	public class ProductsCommandController
	{
		private readonly IMediator mediator;

		public ProductsCommandController(IMediator mediator) {
			this.mediator = mediator;
		}

		[HttpPost]
		public async Task<Unit> Post(CreateProductRequest createProductRequest) {
			var result = await mediator.Send(createProductRequest);
			return result;
		}
	}
}