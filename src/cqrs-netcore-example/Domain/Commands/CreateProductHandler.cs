using System.Threading;
using System.Threading.Tasks;
using MediatR;
using netcore_docker.Domain.Notifications;
using netcore_docker.Domain.UnitOfWork;

namespace netcore_docker.Domain.Commands
{
	public class CreateProductRequest : IRequest
	{
		public string Code { get; set; }
		public string Description { get; set; }
	}

	public class CreateProductHandler : AsyncRequestHandler<CreateProductRequest>
	{
		private readonly IMediator mediator;
		private readonly IUnitOfWork unitOfWork;

		public CreateProductHandler(IUnitOfWork unitOfWork, IMediator mediator) {
			this.unitOfWork = unitOfWork;
			this.mediator = mediator;
		}


		protected override async Task Handle(CreateProductRequest request, CancellationToken cancellationToken) {
			var product = new Product {
				Description = request.Description,
				Code = request.Code
			};

			await unitOfWork.ProductRepository.Add(product);
			await unitOfWork.CommitAsync();

			await mediator.Publish(new ProductCreatedNotification {
				Code = product.Code
			}, cancellationToken);
		}
	}
}